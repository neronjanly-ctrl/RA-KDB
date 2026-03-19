using ChemicalFunctions;
using CommonTools;
using DockingApiService.DataModels;
using DockingApiService.Hubs;
using DockingApiService.Services;
using DockingDataModels;
using Hangfire;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DockingApiService.Jobs;

public sealed class ComputationBackgroundJob
{
    private readonly IWebHostEnvironment _env;
    private readonly IHubContext<JobHub> _hubContext;
    private readonly ComputationContext _dbContext;
    private readonly ComputingService _computingService;
    private readonly ILogger _log;
    private readonly IConfiguration _config;

    private const string LigandName = "ligand.pdbqt";

    public ComputationBackgroundJob(IWebHostEnvironment env, IHubContext<JobHub> hubContext, ComputationContext dbContext, ComputingService computingService, ILogger<ComputationBackgroundJob> logger, IConfiguration config)
    {
        _env = env;
        _hubContext = hubContext;
        _dbContext = dbContext;
        _computingService = computingService;
        _log = logger;
        _config = config;
    }

    #region Notifications

    private IClientProxy GetProxy(Job job)
    {
        return _hubContext.Clients.Group($"Job{job.Id}");
    }

    private async Task NotifyClientResult(Result result)
    {
        object[] args = new object[]
        {
            result.CavityId.StringifyId(), // cavityId: string
            result.LigandId.StringifyId(), // ligandId: string
            result.Cavity.ProteinId, // proteinId: string
            result.DockingScores, // dockingScores: (float | null)[]
            result.DockedModelHashes, // hashes: (string | null)[]
            result.MostSimilarActiveCompound, // mostSimilarChemblCompound: SimilarChemblCompound
            result.MostSimilarCompound, // mostSimilarCompound: SimilarChemblCompound
            result.Prediction, // prediction: Prediction
        };

        await GetProxy(result.Job).SendCoreAsync("SetResult", args);
    }

    private async Task NotifyClientProgress(Job job)
    {
        object[] args = new object[]
        {
            job.Progress,
            job.TimeRemainingString,
            job.Updated.UtcToUnixTimeMilliseconds(),
        };

        await GetProxy(job).SendCoreAsync("SetProgress", args);
    }

    private async Task NotifyClientStatus(Job job)
    {
        object[] args = new object[]
        {
            job.Status.ToString(),
            job.Updated.UtcToUnixTimeMilliseconds(),
        };

        await GetProxy(job).SendCoreAsync("SetStatus", args);
    }
    #endregion

    #region Initialization

    public async Task InitJob(int jobId)
    {
        // Prior to calling InitJob:
        // Job must have been created
        // Domains and ligands with smiles must have been added to job

        // Fetch the job
        Job job = await _dbContext.Jobs
            .FirstOrDefaultAsync(o => o.Id == jobId) ?? throw new Exception($"Cannot find job id {jobId}");

        // Set the job status to Initializing
        job.Init();
        await _dbContext.SaveChangesAsync();

        // Notify client the status
        await NotifyClientStatus(job);

        // Get ligand ids
        long[] lids = await _dbContext.GetJobLigands(jobId)
            .Select(o => o.Id)
            .ToArrayAsync();

        // Get all cavity ids for the job
        Dictionary<long, Cavity> cavities = await (await _dbContext.GetJobCavities(job.Id))
            .ToDictionaryAsync(o => o.Id, o => o);

        // May throw exception
        Dictionary<long, List<(long, RunningJob)>> unfinishedLigandIds = await CreateResults(job, lids, cavities);

        // Notify clients the latest progress
        await NotifyClientProgress(job);

        // Notify client the result
        await NotifyClientStatus(job);

        // Complete information of ligands
        Ligand[] ligands = await CompleteLigands(lids);

        // Check if finished
        if (job.IsComplete)
        {
            job.Finish();
        }
        else
        {
            CreateDirsForJob(jobId, ligands, cavities, unfinishedLigandIds);
            job.Run();
        }

        await _dbContext.SaveChangesAsync();

        // Notify clients the latest progress
        await NotifyClientProgress(job);

        // Notify clients the status
        await NotifyClientStatus(job);
    }

    private async Task<Dictionary<long, List<(long, RunningJob)>>> CreateResults(Job job, long[] ligandIds, Dictionary<long, Cavity> cavities)
    {
        using IDbContextTransaction tx = await _dbContext.Database.BeginTransactionAsync();

        Debug.Assert(job.Status == RunningStatus.Initializing);

        Dictionary<long, List<(long, RunningJob)>> unfinishedLigandCavities = new();
        long[] cavityIds = cavities.Keys.ToArray();

        foreach (long ligandId in ligandIds)
        {
            // get existing protein cavity ids into a dict
            Dictionary<long, Result> cavityDict = await _dbContext.Results
                .Include(o => o.Cavity)
                .ThenInclude(o => o.Protein)
                .Where(o => o.JobId == job.Id && o.LigandId == ligandId && cavityIds.Contains(o.CavityId))
                .ToDictionaryAsync(o => o.CavityId);

            foreach (long cavityId in cavityIds)
            {
                // add non existing cavities to results
                if (!cavityDict.ContainsKey(cavityId))
                {
                    Result result = new();
                    result.Init(job.Id, ligandId, cavityId, cavities[cavityId]);
                    _dbContext.Results.Add(result);
                    cavityDict[cavityId] = result;
                }
            }

            foreach ((long cavityId, Result result) in cavityDict)
            {
                int num = result.DockingScores.Length;
                Debug.Assert(result.Cavity.StructureObtainingMethods.Length == num);
                Debug.Assert(result.Cavity.StructureCount == num);

                Debug.Assert(result.Cavity.Protein.HasActiveChemblCompounds == (result.MostSimilarActiveCompound != null));
                Debug.Assert(result.Cavity.Protein.HasTrainedModels == (result.Prediction != null));

                RunningJob rjob = new()
                {
                    AccruedStructures = Array.Empty<int>(),
                    IsHuntingAccrued = !result.Cavity.Protein.HasActiveChemblCompounds,
                    IsPredictionAccrued = !result.Cavity.Protein.HasTrainedModels,
                };
                _dbContext.RunningJobs.Add(rjob);

                unfinishedLigandCavities.TryAdd(ligandId, new List<(long, RunningJob)>());
                unfinishedLigandCavities[ligandId].Add((cavityId, rjob));
            }
        }

        await _dbContext.SaveChangesAsync();

        await tx.CommitAsync();

        return unfinishedLigandCavities;
    }

    /// <summary>
    /// Create sub-directories for unfinished sub-jobs and push the unfinished sub-jobs to the background queue.
    /// A main ligand directory contains multiple protein directories.
    /// Only disk I/O, no database access.
    /// </summary>
    /// <param name="jobId"></param>
    /// <param name="ligands"></param>
    /// <param name="cachedCavities"></param>
    /// <param name="unfinishedLigandCavities"></param>
    private void CreateDirsForJob(int jobId, Ligand[] ligands, Dictionary<long, Cavity> cachedCavities, IDictionary<long, List<(long, RunningJob)>> unfinishedLigandCavities)
    {
        foreach (Ligand ligand in ligands)
        {
            if (!unfinishedLigandCavities.ContainsKey(ligand.Id))
                continue;

            string ligandId = ligand.Id.StringifyId();

            // Create work directory for ligand
            string workdir = Path.Combine(_env.ContentRootPath, "Workspace", "Output", ligandId);
            if (!Directory.Exists(workdir))
                Directory.CreateDirectory(workdir);

            // Create ligand.pdbqt
            string ligandPath = Path.Combine(workdir, LigandName);

            if (!File.Exists(ligandPath))
            {
                string pdbqt;
                if (_config.GetValue<bool>("ExternalPrograms:UseVegaForPdbqt"))
                    pdbqt = ligand.Smiles.SmilesToPdbqtVega();
                else
                    pdbqt = ligand.Smiles.SmilesToModel("pdbqt");

                if (pdbqt != null)
                {
                    File.WriteAllText(ligandPath, pdbqt);
                }
                else
                {
                    throw new Exception($"Cannot convert ligand {ligandId} from smiles to pdbqt.");
                }
            }

            // Create work directory for each protein
            foreach (string proteinId in cachedCavities.Values.Select(o => o.ProteinId))
            {
                string subworkdir = Path.Combine(workdir, proteinId);
                if (!Directory.Exists(subworkdir))
                    Directory.CreateDirectory(subworkdir);
            }

            // Create background jobs for unfinished proteins
            foreach ((long proteinId, RunningJob rjob) in unfinishedLigandCavities[ligand.Id])
            {
                BackgroundJob.Enqueue<ComputationBackgroundJob>(o => o.RunJob(rjob.Id, jobId, ligandId, cachedCavities[proteinId].ProteinId, cachedCavities[proteinId].Id.StringifyId()));
            }
        }
    }

    private static void FillLigandFingerprints(Ligand ligand)
    {
        foreach (Fingerprint fptype in FingerprintExtensions.All)
        {
            if (ligand.Fingerprints[fptype] == null)
            {
                ligand.Fingerprints[fptype] = ligand.Smiles.ComputeFingerprint(fptype.GetArgumentName())
                    ?? throw new Exception($"Cannot get fingerprint {fptype.GetName()} for ligand {ligand.Id.StringifyId()}.");
            }
        }
    }

    private async Task<Ligand[]> CompleteLigands(long[] ligandIds)
    {
        Ligand[] ligands = await _dbContext.Ligands
            .Where(o => ligandIds.Contains(o.Id))
            .ToArrayAsync();

        foreach (Ligand ligand in ligands)
        {
            FillLigandFingerprints(ligand);
        }

        await _dbContext.SaveChangesAsync();

        return ligands;
    }

    #endregion

    #region Running

    public async Task RunJob(int rjobId, int jobId, string ligandId, string _, string cavityId)
    {
        // Must have running job and result record created prior to calling this method otherwise an exception will be thrown
        RunningJob rjob;

        await using (IDbContextTransaction tx = await _dbContext.Database.BeginTransactionAsync())
        {
            rjob = await _dbContext.RunningJobs
                .SingleOrDefaultAsync(o => o.Id == rjobId);

            if (rjob == null)
            {
                throw new Exception($"RunningJob #{rjobId} for job #{jobId} doesn't exist");
            }

            if (rjob.IsRunning)
            {
                _log.LogDebug("RunningJob #{RunningJobId} for job #{JobId} is already running", rjobId, jobId);
                // Currently there is only one background worker so the thread protection is redundant.
                //return;
            }

            rjob.Start();
            await _dbContext.SaveChangesAsync();
            await tx.CommitAsync();
        }

        // Fetch the protein result for ligand
        long ligandIdl = ligandId.ParseId(), cavityIdl = cavityId.ParseId();

        Result result = _dbContext
            .Results
            .Include(o => o.Job)
            .Include(o => o.Ligand)
            .Include(o => o.Cavity)
            .Single(o => o.JobId == jobId && o.LigandId == ligandIdl && o.CavityId == cavityIdl);

        // Run docking
        await RunJobStage0(rjob, result);

        // Run hunting
        await RunJobStage1(rjob, result);

        // Run predicting
        await RunJobStage2(rjob, result);

        using (IDbContextTransaction tx = await _dbContext.Database.BeginTransactionAsync())
        {
            rjob.Stop();
            await _dbContext.SaveChangesAsync();
            await tx.CommitAsync();
        }

        // Check if finished
        if (result.Job.IsComplete)
        {
            result.Job.Finish();
            await _dbContext.SaveChangesAsync();

            // Notify client the result
            await NotifyClientStatus(result.Job);
        }
    }

    private async Task RunJobStage0(RunningJob rjob, Result result)
    {
        Debug.Assert(rjob.AccruedStructures.Length <= result.DockingScores.Length);

        if (rjob.AccruedStructures.Length == result.DockingScores.Length)
        {
            _log.LogDebug("No docking is required for RunningJob #{RunningJobId} of job #{JobId}", rjob.Id, result.JobId);
            return;
        }

        int[] modelIds = Enumerable
        .Range(0, result.Cavity.StructureCount)
        .Except(rjob.AccruedStructures)
        .ToArray();

        int[] precompletedModelIds = modelIds
            .Where(o => result.DockingScores[o] != null)
            .ToArray();

        if (precompletedModelIds.Any())
        {
            result.Job.PrecompleteStage(0, precompletedModelIds.Length);
            rjob.AccruedStructures = rjob.AccruedStructures.Union(precompletedModelIds).ToArray();
            await _dbContext.SaveChangesAsync();

            // Notify clients the result
            await NotifyClientResult(result);
            await NotifyClientProgress(result.Job);
        }

        if (modelIds.Length == precompletedModelIds.Length)
            return;

        string ligandId = result.LigandId.StringifyId();
        string proteinId = result.Cavity.ProteinId;

        // Compute docking scores
        string outputdir = Path.Combine(_env.ContentRootPath, "Workspace", "Output", ligandId);
        string proteindir = Path.Combine(_env.ContentRootPath, "Workspace", "Receptors", proteinId);
        string ligandPath = Path.Combine(outputdir, LigandName);

        foreach (int modelId in modelIds)
        {
            Stopwatch sw = Stopwatch.StartNew();

            string modeldir = Path.Combine(proteindir, result.Cavity.BindingSite, $"model_{modelId + 1}");
            string receptorPath = Path.Combine(modeldir, "AminoAcids.pdbqt");
            string receptorFixedPath = Path.Combine(modeldir, "AminoAcids_fixed.pdbqt");

            bool useFixed = File.Exists(receptorFixedPath);
            if (useFixed)
                receptorPath = receptorFixedPath;
            else if (!File.Exists(receptorPath))
                throw new FileNotFoundException($"Cannot find receptor {receptorPath}", receptorPath);

            long receptorHash = File.ReadAllText(receptorPath).ComputeHashInt64();
            long ligandHash = File.ReadAllText(ligandPath).ComputeHashInt64();

            // Prepare arguments for jdock and run it
            string confname = $"Pocket.conf";
            string confpath = Path.Combine(modeldir, confname);

            Docking docking = new();
            float[] space = ComputingService.ParseSearchingSpace(confpath);
            docking.Init(receptorHash, ligandHash, result.Ligand.Smiles, _computingService.GetDockerName(), space);

            Docking docking2 = await _dbContext.Dockings.FirstOrDefaultAsync(o => o.Id == docking.Id);
            float dockingScore;
            bool precompleted;

            if (docking2 != null)
            {
                dockingScore = docking2.Score;
                precompleted = true;
            }
            else
            {
                string dockingDir = Path.Combine(outputdir, proteinId, docking.Id.StringifyId());
                if (!Directory.Exists(dockingDir))
                    Directory.CreateDirectory(dockingDir);

                string outputpath = Path.Combine(dockingDir, $"{(useFixed ? "fixed_" : "")}{LigandName}");

                float? dockingScoreN = _computingService.ComputeDockingScore(confpath, receptorPath, ligandPath, outputpath)
                    ?? throw new Exception($"Fatal error while calling docking service for receptor:{receptorPath}, conf:{confname} and ligand:{ligandId}.");

                dockingScore = dockingScoreN.Value;
                precompleted = false;

                docking.Score = dockingScore;
                docking.Smiles = result.Ligand.Smiles;
                docking.ProteinId = proteinId;
                docking.BindingCavity = result.Cavity.BindingSite;
                docking.StructureIndex = modelId;

                _dbContext.Dockings.Add(docking);
            }

            // Update score and progress and save to database
            if (result.DockingScoreMetric == DockingScoreMetric.Unknown || result.DockingScoreMetric == DockingScoreMetric.Vina)
                result.SetDockingScore(modelId, DockingScoreMetric.Vina, dockingScore, docking.Id.StringifyId());
            else if (result.DockingScoreMetric == DockingScoreMetric.Sybyl)
                result.SetDockingScore(modelId, DockingScoreMetric.Sybyl, dockingScore.ToSybylScore(), docking.Id.StringifyId());
            else
                Debug.Fail($"Unknown score metric {result.DockingScoreMetric} found in result for job {result.JobId}, ligand {result.LigandId.StringifyId()} and cavity {result.CavityId.StringifyId()}");

            if (precompleted)
            {
                result.Job.PrecompleteStage(0);
            }
            else
            {
                result.Job.CompleteStage(0, sw.Elapsed);
            }
            rjob.AccruedStructures = rjob.AccruedStructures.Append(modelId).Distinct().ToArray();

            await _dbContext.SaveChangesAsync();

            // Notify clients the result
            await NotifyClientResult(result);
            await NotifyClientProgress(result.Job);
        }
    }

    private async Task RunJobStage1(RunningJob rjob, Result result)
    {
        // No hunting is required.
        if (rjob.IsHuntingAccrued || result.MostSimilarActiveCompound == null && result.MostSimilarCompound == null)
        {
            _log.LogDebug("No hunting is required for RunningJob #{RunningJobId} of job #{JobId}", rjob.Id, result.JobId);
            return;
        }

        if (result.MostSimilarActiveCompound != null && result.MostSimilarActiveCompound.Activity != BioActivity.Unknown
            || result.MostSimilarCompound != null && result.MostSimilarCompound.Activity != BioActivity.Unknown)
        {
            result.Job.PrecompleteStage(1);
            rjob.IsHuntingAccrued = true;
            await _dbContext.SaveChangesAsync();

            // Notify clients the result
            await NotifyClientResult(result);
            await NotifyClientProgress(result.Job);
            return;
        }

        Stopwatch sw = Stopwatch.StartNew();

        // Compute similarity score
        SimilarChemblCompound[] simResult = _computingService.ComputeSimilarityScore(result.Cavity.ProteinId, result.Ligand.FingerprintFP2)
            ?? throw new Exception("Fatal error while computing similarity score.");

        Debug.Assert(simResult.Length == 2);
        SimilarChemblCompound bestComp = simResult[0];
        SimilarChemblCompound bestActiveComp = simResult[1];

        // Update the score and the progress and save to the database
        if (bestComp?.Smiles != null)
        {
            await PutSimilarActiveCompound(bestComp.Smiles);
            result.SetSimilarCompound(bestComp);
        }

        if (bestActiveComp?.Smiles != null)
        {
            await PutSimilarActiveCompound(bestActiveComp.Smiles);
            result.SetSimilarActiveCompound(bestActiveComp);
        }

        result.Job.CompleteStage(1, sw.Elapsed);
        rjob.IsHuntingAccrued = true;

        await _dbContext.SaveChangesAsync();

        // Notify clients the result
        await NotifyClientResult(result);
        await NotifyClientProgress(result.Job);
    }

    private async Task RunJobStage2(RunningJob rjob, Result result)
    {
        // No prediction is required.
        if (rjob.IsPredictionAccrued || result.Prediction == null)
        {
            _log.LogDebug("No prediction is required for RunningJob #{RunningJobId} of job #{JobId}", rjob.Id, result.JobId);
            return;
        }

        if (result.Prediction.Activity != BioActivity.Unknown)
        {
            result.Job.PrecompleteStage(2);
            rjob.IsPredictionAccrued = true;
            await _dbContext.SaveChangesAsync();

            // Notify clients the result
            await NotifyClientResult(result);
            await NotifyClientProgress(result.Job);
            return;
        }

        Stopwatch sw = Stopwatch.StartNew();

        // Compute SVM prediction
        float? averageScore = result.AverageDockingScore;

        int structureCount = result.DockingScores.Length;
        Debug.Assert(structureCount > 0 && result.DockingScores.All(o => o != null));
        Debug.Assert(result.MostSimilarActiveCompound != null && result.MostSimilarActiveCompound.Activity != BioActivity.Unknown);

        if (averageScore == null)
            throw new ArgumentNullException($"Null docking score found for RunningJob #{rjob.Id} (job {result.JobId}, cavity {result.CavityId.StringifyId()}, ligand {result.LigandId.StringifyId()})");

        bool toSybyl = result.DockingScoreMetric == DockingScoreMetric.Vina;
        float[] scores = Enumerable.Range(0, 3)
            .Select
            (i => i < structureCount && result.DockingScores[i] != null
                ? (toSybyl ? result.DockingScores[i].Value.ToSybylScore() : result.DockingScores[i].Value)
                : (toSybyl ? averageScore.Value.ToSybylScore() : averageScore.Value)
            )
            .ToArray();

        Prediction prediction = _computingService.ComputePrediction(
            result.Cavity.ProteinId,
            scores[0],
            scores[1],
            scores[2],
            result.MostSimilarActiveCompound?.Similarity ?? 1f
        ) ?? throw new Exception("Fatal error while invoking Prediction.");

        // Update prediction and progress and save to database
        result.SetPrediction(prediction);
        result.Job.CompleteStage(2, sw.Elapsed);
        rjob.IsPredictionAccrued = true;

        await _dbContext.SaveChangesAsync();

        // Notify clients the result
        await NotifyClientResult(result);
        await NotifyClientProgress(result.Job);
    }

    private async Task<Ligand> PutSimilarActiveCompound(string smiles)
    {
        long ligandId = smiles.ComputeHashInt64();
        Ligand ligand = await _dbContext.Ligands
            .FirstOrDefaultAsync(o => o.Id == ligandId);

        if (ligand == null)
        {
            ligand = new Ligand
            {
                Id = ligandId,
                Smiles = smiles,
            };

            FillLigandFingerprints(ligand);
            _dbContext.Add(ligand);
            await _dbContext.SaveChangesAsync();
        }

        return ligand;
    }

    #endregion
}
