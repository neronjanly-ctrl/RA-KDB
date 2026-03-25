using CommonTools;
using DockingApiService.DataModels;
using DockingApiService.Jobs;
using DockingDataModels;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockingApiService.Controllers;

[Route("job")]
[ApiController]
public class JobController : ControllerBase
{
    private readonly ComputationContext _ctx;

    public JobController(ComputationContext ctx)
    {
        _ctx = ctx;
    }

    #region Job Infomation

    /// <summary>
    /// Gets a job for a given <paramref name="jobId"/>.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/job/5
    /// 
    /// </remarks>
    /// <param name="jobId">The numberic identifier to fetch a job with.</param>
    /// <returns>A <see cref="Job"/> object that represents the requested job.</returns>
    /// <response code="200">Sucessful operation.</response>
    /// <response code="404">If the job does not exist.</response>            
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [HttpGet("{jobId:int}")]
    public async Task<ActionResult<Job>> GetOne(int jobId)
    {
        if (!await _ctx.Jobs.AnyAsync(o => o.Id == jobId))
            return NotFound();

        Job jobs = await _ctx.GetJobs()
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == jobId);

        return jobs;
    }

    /// <summary>
    /// Gets a job for a given <paramref name="jobId"/>.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/job/5/ligands
    /// 
    /// </remarks>
    /// <param name="jobId">The numberic identifier to fetch the ligands with.</param>
    /// <returns>A list of <seealso cref="JobLigand"/> for the query job.</returns>
    /// <response code="200">Sucessful operation.</response>
    /// <response code="404">If the job does not exist.</response>
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [HttpGet("{jobId:int}/ligands")]
    public async Task<ActionResult<IEnumerable<JobLigand>>> GetLigands(int jobId)
    {
        JobLigand[] jobLigands = await _ctx.Jobs
            .Where(o => o.Id == jobId)
            .SelectMany(o => o.JobLigands)
            .AsNoTracking()
            .ToArrayAsync();

        return jobLigands;
    }

    /// <summary>
    /// Gets a partial list of docking jobs for a given <paramref name="offset"/> and job <paramref name="count"/>.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/job/list/0/20
    /// 
    /// </remarks>
    /// <param name="offset">The zero-based starting position in all jobs.</param>
    /// <param name="count">The number of jobs to retrieve.</param>
    /// <returns>A list of jobs.</returns>
    /// <response code="200">Sucessful operation.</response>
    [ProducesResponseType(200)]
    [HttpGet("list/{offset:int}/{count:int}")]
    public async Task<ActionResult<IEnumerable<Job>>> List(int offset, int count)
    {
        Job[] jobs = await _ctx.GetJobs()
            .OrderBy(o => o.Status == RunningStatus.Finished)
            .ThenByDescending(o => o.Created)
            .Skip(offset)
            .Take(count)
            .AsNoTracking()
            .ToArrayAsync();

        return jobs;
    }

    /// <summary>
    /// Gets a full list of docking jobs.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/job/list
    /// 
    /// </remarks>
    /// <returns>A list of jobs</returns>
    /// <response code="200">Sucessful operation.</response>
    [ProducesResponseType(200)]
    [HttpGet("list")]
    public async Task<ActionResult<IEnumerable<Job>>> List()
    {
        Job[] jobs = await _ctx.GetJobs()
            .OrderBy(o => o.Status == RunningStatus.Finished)
            .ThenByDescending(o => o.Created)
            .AsNoTracking()
            .ToArrayAsync();

        return jobs;
    }

    /// <summary>
    /// Get the number of jobs in every statuses.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/job/stats
    /// 
    /// </remarks>
    /// <returns>A dictionary mapping a status to the number of jobs in such status.</returns>
    /// <response code="200">Sucessful operation.</response>
    [ProducesResponseType(200)]
    [HttpGet("stats")]
    public async Task<ActionResult<IDictionary<RunningStatus, int>>> Stats()
    {
        Dictionary<RunningStatus, int> stats = await _ctx.Jobs
            .GroupBy(o => o.Status)
            .Select(o => new { status = o.Key, count = o.Count() })
            .AsNoTracking()
            .ToDictionaryAsync(o => o.status, o => o.count);

        RunningStatus[] enums = EnumAnnotationHelper<RunningStatus>.Enums;
        foreach (RunningStatus e in enums)
        {
            if (!stats.ContainsKey(e))
                stats[e] = 0;
        }

        return stats;
    }

    /// <summary>
    /// Gets a partial list of user accessible docking jobs for a given <paramref name="offset"/> and job <paramref name="count"/>.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/job/list/for-domain-dakb-gpcrs/0/20
    /// 
    /// </remarks>
    /// <param name="domainId">The identifier of the domain to search jobs within</param>
    /// <param name="offset">The zero-based starting position in all jobs.</param>
    /// <param name="count">The number of jobs to retrieve.</param>
    /// <returns>A list of jobs.</returns>
    /// <response code="200">Sucessful operation.</response>
    [ProducesResponseType(200)]
    [HttpGet("list/for-domain-{domainId:required}/{offset:int}/{count:int}")]
    public async Task<ActionResult<IEnumerable<Job>>> ListForDomain(string domainId, int offset, int count)
    {
        Job[] jobs = await _ctx.GetJobs(domainId)
            .OrderBy(o => o.Status == RunningStatus.Finished)
            .ThenByDescending(o => o.Created)
            .Skip(offset)
            .Take(count)
            .AsNoTracking()
            .ToArrayAsync();

        return jobs;
    }

    /// <summary>
    /// Gets a full list of docking jobs.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/job/list/for-domain-dakb-gpcrs
    /// 
    /// </remarks>
    /// <param name="domainId">The identifier of the domain to search jobs within</param>
    /// <returns>A list of jobs</returns>
    /// <response code="200">Sucessful operation.</response>
    [ProducesResponseType(200)]
    [HttpGet("list/for-domain-{domainId:required}")]
    public async Task<ActionResult<IEnumerable<Job>>> ListForDomain(string domainId)
    {
        Job[] jobs = await _ctx.GetJobs(domainId)
            .OrderBy(o => o.Status == RunningStatus.Finished)
            .ThenByDescending(o => o.Created)
            .AsNoTracking()
            .ToArrayAsync();

        return jobs;
    }

    /// <summary>
    /// Get the number of jobs in every statuses.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/job/stats/for-domain-dakb-gpcrs
    /// 
    /// </remarks>
    /// <param name="domainId">The identifier of the domain to get jobs statistics within</param>
    /// <returns>A dictionary mapping a status to the number of jobs in such status.</returns>
    /// <response code="200">Sucessful operation.</response>
    [ProducesResponseType(200)]
    [HttpGet("stats/for-domain-{domainId:required}")]
    public async Task<ActionResult<IDictionary<RunningStatus, int>>> StatsForDomain(string domainId)
    {
        Dictionary<RunningStatus, int> stats = await _ctx.Domains
            .Where(o => o.Id == domainId)
            .SelectMany(o => o.DomainJobs)
            .Select(o => o.Job)
            .GroupBy(o => o.Status)
            .Select(o => new { status = o.Key, count = o.Count() })
            .AsNoTracking()
            .ToDictionaryAsync(o => o.status, o => o.count);

        RunningStatus[] enums = EnumAnnotationHelper<RunningStatus>.Enums;
        foreach (RunningStatus e in enums)
        {
            if (!stats.ContainsKey(e))
                stats[e] = 0;
        }

        return stats;
    }

    /// <summary>
    /// Gets a partial list of docking jobs for a given <paramref name="offset"/> and job <paramref name="count"/>.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/job/list/for-user-ryan%40imozo.cn/0/20
    /// 
    /// </remarks>
    /// <param name="userId">The user identifier for querying jobs.</param>
    /// <param name="offset">The zero-based starting position in all jobs.</param>
    /// <param name="count">The number of jobs to retrieve.</param>
    /// <returns>A list of jobs.</returns>
    /// <response code="200">Sucessful operation.</response>
    [ProducesResponseType(200)]
    [HttpGet("list/for-user-{userId:required}/{offset:int}/{count:int}")]
    public async Task<ActionResult<IEnumerable<Job>>> ListForUser(string userId, int offset, int count)
    {
        userId = userId?.Trim()?.ToLower();
        if (string.IsNullOrWhiteSpace(userId))
            return Array.Empty<Job>();

        Job[] jobs = await _ctx.GetUserJobs(userId)
            .OrderBy(o => o.Status == RunningStatus.Finished)
            .ThenByDescending(o => o.Created)
            .Skip(offset)
            .Take(count)
            .AsNoTracking()
            .ToArrayAsync();

        return jobs;
    }

    /// <summary>
    /// Gets a full list of docking jobs.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/job/list/for-user-ryan%40imozo.cn
    /// 
    /// </remarks>
    /// <param name="userId">The user identifier for querying jobs.</param>
    /// <returns>A list of jobs</returns>
    /// <response code="200">Sucessful operation.</response>
    [ProducesResponseType(200)]
    [HttpGet("list/for-user-{userId:required}")]
    public async Task<ActionResult<IEnumerable<Job>>> ListForUser(string userId)
    {
        userId = userId?.Trim()?.ToLower();
        if (string.IsNullOrWhiteSpace(userId))
            return Array.Empty<Job>();

        Job[] jobs = await _ctx.GetUserJobs(userId)
            .OrderBy(o => o.Status == RunningStatus.Finished)
            .ThenByDescending(o => o.Created)
            .AsNoTracking()
            .ToArrayAsync();

        return jobs;
    }

    /// <summary>
    /// Get the number of jobs in every statuses.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/job/stats/for-user-ryan%40imozo.cn
    /// 
    /// </remarks>
    /// <param name="userId">The user identifier for querying jobs.</param>
    /// <returns>A dictionary mapping a status to the number of jobs in such status.</returns>
    /// <response code="200">Sucessful operation.</response>
    [ProducesResponseType(200)]
    [HttpGet("stats/for-user-{userId:required}")]
    public async Task<ActionResult<IDictionary<RunningStatus, int>>> StatsForUser(string userId)
    {
        RunningStatus[] enums = EnumAnnotationHelper<RunningStatus>.Enums;

        userId = userId?.Trim()?.ToLower();
        if (string.IsNullOrWhiteSpace(userId))
            return enums.ToDictionary(o => o, o => 0);

        Dictionary<RunningStatus, int> stats = await _ctx.Jobs
            .Where(o => o.UserId == userId)
            .GroupBy(o => o.Status)
            .Select(o => new { status = o.Key, count = o.Count() })
            .AsNoTracking()
            .ToDictionaryAsync(o => o.status, o => o.count);

        foreach (RunningStatus e in enums)
        {
            if (!stats.ContainsKey(e))
                stats[e] = 0;
        }

        return stats;
    }

    #endregion

    #region Job Create/Update/Delete
    /// <summary>
    /// Adds and queues a new job for docking and prediction.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST api/job
    ///     {
    ///       "DomainIds": [
    ///         "dakb-gpcrs"
    ///       ],
    ///       "JobName": "Test Aspirin on Drug Abuse",
    ///       "LigandNames": [
    ///         "Aspirin"
    ///       ],
    ///       "Smiles": [
    ///         "O=C(C)Oc1ccccc1C(=O)O"
    ///       ],
    ///       "IsPrivate": false,
    ///       "UserId": "john.smith@example.com",
    ///     }
    /// 
    /// </remarks>
    /// <param name="model">Parameters as defined in <seealso cref="CreateJobModel"/>. See sample request for more.</param>
    /// <returns>The newly created numberic job idenfitier.</returns>
    /// <response code="201">Sucessful created.</response>
    /// <response code="400">If the arguments are incorrect.</response>
    /// <response code="409">If the job failed to queue.</response>
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(409)]
    [HttpPost]
    public async Task<ActionResult<Job>> Create([FromBody] CreateJobModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // validate smiles list
        if (model.Smiles.Length == 0 || model.LigandNames.Length != model.Smiles.Length)
            return BadRequest();

        // detect duplicate smiles
        if (model.Smiles.Length != model.Smiles.Distinct().Count())
            return BadRequest();

        // validate user id
        if (model.UserId != null)
        {
            User user = await _ctx.Users.FirstOrDefaultAsync(o => o.Email == model.UserId);
            if (user == null)
            {
                user = new User();
                user.Init(model.UserId.Trim().ToLower(), null);
                await _ctx.Users.AddAsync(user);
                await _ctx.SaveChangesAsync();
            }
        }

        (string name, long id)[] ligandIds = model.LigandNames.Zip(model.Smiles.Select(o => o.ComputeHashInt64())).ToArray();

        // remove duplicate domains
        model.DomainIds = model.DomainIds.Distinct().ToArray();
        Domain[] domains = await _ctx.Domains
            .Where(o => model.DomainIds.Contains(o.Id))
            .ToArrayAsync();

        for (int i = 0; i < model.Smiles.Length; i++)
        {
            Ligand ligand = await _ctx.Ligands
                .SingleOrDefaultAsync(o => o.Id == ligandIds[i].id);

            if (ligand == null)
            {
                ligand = new Ligand
                {
                    Id = ligandIds[i].id,
                    Smiles = model.Smiles[i],
                };
                await _ctx.Ligands.AddAsync(ligand);
            }
        }

        int proteinCount = await _ctx.GetDomainProteins(model.DomainIds).CountAsync();
        int[] stages = await _ctx.CalcStagesForDomains(model.DomainIds);
        int resultCount = await _ctx.GetDomainCativies(model.DomainIds).CountAsync() * ligandIds.Length;

        Job job = new()
        {
            Name = model.JobName,

            DomainCount = model.DomainIds.Length,
            ProteinCount = proteinCount,
            LigandCount = ligandIds.Length,
            ResultCount = resultCount,

            Stage0 = new StageStat { TargetCount = stages[0] * ligandIds.Length },
            Stage1 = new StageStat { TargetCount = stages[1] * ligandIds.Length },
            Stage2 = new StageStat { TargetCount = stages[2] * ligandIds.Length },
            AllStages = new StageStat { TargetCount = stages.Sum() * ligandIds.Length },

            IpAddress = HttpContext.Connection.RemoteIpAddress.ToString(),
            UserId = model.UserId,
            IsPrivate = model.IsPrivate,

            JobDomains = model.DomainIds.Select(o => new JobDomain { DomainId = o }).ToList(),
            JobLigands = ligandIds.Select(o => new JobLigand { LigandId = o.id, LigandName = o.name }).ToList(),
        };

        job.Create();
        await _ctx.Jobs.AddAsync(job);

        try
        {
            await _ctx.SaveChangesAsync();

            BackgroundJob.Enqueue<ComputationBackgroundJob>(o => o.InitJob(job.Id));

            return CreatedAtAction(nameof(GetOne), new { jobId = job.Id }, job);
        }
        catch (Exception ex)
        {
            return Conflict(ex);
        }
    }

    /// <summary>
    /// Renames a job.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     PUT api/job/5/name
    ///     {
    ///       "NewName: "Aspirin"
    ///     }
    /// 
    /// </remarks>
    /// <param name="jobId">The numeric identifier to rename the job with.</param>
    /// <param name="model">Parameters as defined in <seealso cref="RenameJobModel"/>. See sample request for more.</param>
    /// <returns>No return value.</returns>
    /// <response code="204">Sucessful operation.</response>
    /// <response code="404">If the job does not exist.</response>
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    [HttpPut("{jobId:int}/name")]
    public async Task<ActionResult> Rename(int jobId, [FromBody] RenameJobModel model)
    {
        Job job = await _ctx.Jobs.FirstOrDefaultAsync(o => o.Id == jobId);
        if (job == null)
            return NotFound();

        job.Name = model.NewName;
        await _ctx.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Enqueues again the job specified by <paramref name="jobId"/>.
    /// </summary>
    /// <remarks>
    /// The job must be in the Created status.
    /// 
    /// Sample request:
    /// 
    ///     POST api/job/5/issue
    /// 
    /// </remarks>
    /// <param name="jobId">The numeric identifier to enqueue the job with.</param>
    /// <returns>No return value.</returns>
    /// <response code="204">Sucessful operation.</response>
    /// <response code="400">If the job is not in the Created status.</response>
    /// <response code="404">If the job does not exist.</response>
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [HttpPut("{jobId:int}/issue")]
    public async Task<ActionResult> Reissue(int jobId)
    {
        Job job = await _ctx.Jobs.FirstOrDefaultAsync(o => o.Id == jobId);
        if (job == null)
            return NotFound();

        if (job.Status != RunningStatus.Created)
            return ValidationProblem();

        BackgroundJob.Enqueue<ComputationBackgroundJob>(o => o.InitJob(job.Id));
        return NoContent();
    }

    /// <summary>
    /// Permanently deletes a job while keeping the related job results for future reuse.
    /// </summary>
    /// <remarks>
    /// The job must be in the Finished or Failed status.
    /// 
    /// Sample request:
    /// 
    ///     DELETE api/job/5
    /// 
    /// </remarks>
    /// <param name="jobId">The numeric identifier of the job to be deleted permanently.</param>
    /// <returns>No return value.</returns>
    /// <response code="204">Sucessful operation.</response>
    /// <response code="400">If the job is not in the Finished or Failed status.</response>
    /// <response code="404">If the job does not exist.</response>
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [HttpDelete("{jobId:int}")]
    public async Task<ActionResult> Delete(int jobId)
    {
        Job job = await _ctx.Jobs.FirstOrDefaultAsync(o => o.Id == jobId);
        if (job == null)
            return NotFound();

        if (job.Status != RunningStatus.Finished && job.Status != RunningStatus.Failed)
            return ValidationProblem();

        _ctx.Jobs.Remove(job);
        await _ctx.SaveChangesAsync();
        return NoContent();
    }

    /// <summary>
    /// Fails a job.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     PUT api/job/5/failure
    /// 
    /// </remarks>
    /// <param name="jobId">The numeric identifier to fail the job with.</param>
    /// <returns>No return value.</returns>
    /// <response code="204">Sucessful operation.</response>
    /// <response code="400">If the job is not in the Initializing, Running or Failed status.</response>
    /// <response code="404">If the job does not exist.</response>
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [HttpPut("{jobId:int}/failure")]
    public async Task<ActionResult> Fail(int jobId)
    {
        Job job = await _ctx.Jobs.FirstOrDefaultAsync(o => o.Id == jobId);
        if (job == null)
            return NotFound();

        if (job.Status != RunningStatus.Initializing && job.Status != RunningStatus.Running && job.Status != RunningStatus.Failed)
            return BadRequest();

        if (job.Status != RunningStatus.Failed)
        {
            job.Fail();
            await _ctx.SaveChangesAsync();
        }

        return NoContent();
    }
    #endregion
}
