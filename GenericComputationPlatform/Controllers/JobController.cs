using CommonTools;
using DockingApiClient;
using DockingDataModels;
using GenericComputationPlatform.DataModels;
using GenericComputationPlatform.Extensions;
using GenericComputationPlatform.Mocks;
using GenericComputationPlatform.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericComputationPlatform.Controllers;

[Route("/{domainId:required}/job")]
public partial class JobController : Controller
{
    private readonly AppSettings _appSettings;
    private readonly JobClient _jobClient;
    private readonly DomainClient _domainClient;
    private readonly ResultClient _resultClient;
    private readonly LigandClient _ligandClient;
    private readonly DrugModelMock _mock;

    public JobController(
        IOptions<AppSettings> appSettings,
        JobClient jobClient,
        DomainClient domainClient,
        ResultClient resultClient,
        LigandClient ligandClient,
        DrugModelMock mock)
    {
        _appSettings = appSettings.Value;
        _jobClient = jobClient;
        _domainClient = domainClient;
        _resultClient = resultClient;
        _ligandClient = ligandClient;
        _mock = mock;
    }

    // For specifications, see https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing
    [HttpGet("list")]
    public virtual async Task<IActionResult> List(string domainId)
    {
        Domain domain = await _domainClient.GetOneAsync(domainId);
        if (domain == null || !domain.IsPublic && User.Identity?.IsAuthenticated != true)
            return NotFound();

        ViewBag.Keywords = domain.Keywords;

        IDictionary<RunningStatus, int> stat = await _jobClient.StatsForDomainAsync(domainId);
        IReadOnlyList<Job> jobs = await _jobClient.ListForDomain2Async(domainId);

        JobListModel model = new()
        {
            DomainId = domainId,
            PageSize = Math.Max(1, jobs.Count),
            PageNum = 1,
            Jobs = jobs,
            RunningCount = stat.RunningCount(),
            TotalCount = stat.Sum(o => o.Value),
        };

        return View(model);
    }

    [HttpGet("new")]
    public virtual async Task<IActionResult> New(string domainId)
    {
        Domain domain = await _domainClient.GetOneAsync(domainId);
        if (domain == null || !domain.IsPublic && User.Identity?.IsAuthenticated != true)
            return NotFound();

        ViewBag.Keywords = domain.Keywords;

        return View(domain);
    }

    [HttpPost("create")]
    public virtual async Task<ActionResult<int?>> Create(string domainId, [FromForm] string jobName, [FromForm] JobLigandInputModel[] ligands, [FromForm] bool isPrivate)
    {
        if (ligands.Length < 1)
            return BadRequest();

        Domain domain = await _domainClient.GetOneAsync(domainId);
        if (domain == null || !domain.IsPublic && User.Identity?.IsAuthenticated != true)
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var job = await _jobClient.CreateAsync(new CreateJobModel
        {
            DomainIds = new[] { domainId },
            JobName = jobName,
            LigandNames = ligands.Select(o => o.Name).ToArray(),
            Smiles = ligands.Select(o => o.Smiles).ToArray(),
            IsPrivate = isPrivate,
            UserId = User.Identity.Name?.ToLower(),
        });

        return job.Id;
    }

    [HttpGet("w{jobId:int}")]
    public virtual async Task<IActionResult> Details(string domainId, int jobId)
    {
        Domain domain = await _domainClient.GetOneAsync(domainId);
        if (domain == null || !domain.IsPublic && User.Identity?.IsAuthenticated != true)
            return NotFound();

        Job job = await _jobClient.GetOneAsync(jobId);

        if (job == null || job.IsPrivate && (!User.Identity.IsAuthenticated || job.UserId != User.Identity.Name?.ToLower()))
            return NotFound();

        ViewBag.Keywords = domain.Keywords;

        JobDetailsModel model = new()
        {
            DomainId = domainId,
            Job = job,
            PreviewLigandModels = _appSettings.Display.PreviewLigandModels,
            PreviewLigandFingerprints = _appSettings.Display.PreviewLigandFingerprints,
        };

        return View(model);
    }

    [HttpGet("w{jobId:int}/bbb")]
    public virtual async Task<IActionResult> Bbb(string domainId, int jobId)
    {
        Domain domain = await _domainClient.GetOneAsync(domainId);
        if (domain == null || !domain.IsPublic && User.Identity?.IsAuthenticated != true)
            return NotFound();

        Job job = await _jobClient.GetOneAsync(jobId);

        if (job == null || job.IsPrivate && (!User.Identity.IsAuthenticated || job.UserId != User.Identity.Name?.ToLower()))
            return NotFound();

        ViewBag.Keywords = domain.Keywords;

        JobDetailsModel model = new()
        {
            DomainId = domainId,
            Job = job,
            PreviewLigandModels = _appSettings.Display.PreviewLigandModels,
            PreviewLigandFingerprints = _appSettings.Display.PreviewLigandFingerprints,
        };

        return View(model);
    }

    [HttpGet("w{jobId:int}/output-card/all")]
    public virtual async Task<IActionResult> CardViewAll(string domainId, int jobId) => await OutputAction(domainId, jobId, -1, true);

    [HttpGet("w{jobId:int}/output-card/{pageNum:int=1}")]
    public virtual async Task<IActionResult> CardView(string domainId, int jobId, int pageNum) => await OutputAction(domainId, jobId, pageNum, true);

    [HttpGet("w{jobId:int}/output-table")]
    public virtual async Task<IActionResult> TableViewAll(string domainId, int jobId) => await OutputAction(domainId, jobId, -1, false);

    //[HttpGet("w{jobId:int}/output-table/{pageNum:int=1}")]
    //public IActionResult TableView(string domainId, int jobId, int pageNum) => OutputAction(domainId, jobId, pageNum, false);

    private async Task<IActionResult> OutputAction(string domainId, int jobId, int pageNum, bool cardView)
    {
        Domain domain = await _domainClient.GetOneAsync(domainId);
        if (domain == null || !domain.IsPublic && User.Identity?.IsAuthenticated != true)
            return NotFound();

        Job job = await _jobClient.GetOneAsync(jobId);

        if (job == null || job.IsPrivate && (!User.Identity.IsAuthenticated || job.UserId != User.Identity.Name?.ToLower()))
            return NotFound();

        ViewBag.Keywords = domain.Keywords;

        int pageSize = _appSettings.PageSize.JobOutput;
        IReadOnlyList<Result> data = pageNum >= 1 && pageSize >= 1
            ? await _resultClient.ListAsync(jobId, (pageNum - 1) * pageSize, pageSize)
            : await _resultClient.List2Async(jobId);

        JobOutputModel model = new()
        {
            DomainId = domainId,
            Job = job,
            Results = data.ToArray(),
            PageNum = pageNum,
            PageSize = pageSize,
            TotalCount = job.ResultCount,
            UseCardOutputDisplay = cardView,
            UseGeneSymbolForTargetDisplay = HttpContext.UseGeneSymbolForTargetDisplay(),
            MaxStructureCount = data.Count > 0 ? data.Max(o => o.DockingScores.Length) : 0,
            HasPrediction = data.Any(o => o.Prediction != null),
            SameGeneProteinSymbol = data.All(o => o.Cavity.Protein.GeneSymbol == o.Cavity.Protein.ProteinSymbol),
        };

        HttpContext.SetUseCardOutputDisplay(cardView);

        return View("Output", model);
    }

    [HttpGet("w{jobId:int}/plot")]
    public virtual async Task<IActionResult> Plot(string domainId, int jobId)
    {
        Domain domain = await _domainClient.GetOneAsync(domainId);
        if (domain == null || !domain.IsPublic && User.Identity?.IsAuthenticated != true)
            return NotFound();

        Job job = await _jobClient.GetOneAsync(jobId);
        if (job == null || job.IsPrivate && (!User.Identity.IsAuthenticated || job.UserId != User.Identity.Name?.ToLower()) || job.JobLigands.Count == 0)
            return NotFound();

        ViewBag.Keywords = domain.Keywords;

        string[][] data;

        if (!_appSettings.Test.UseMockDataForPlotting)
        {
            IReadOnlyList<Result> results = await _resultClient.List2Async(jobId);
            bool hasPrediction = results.Any(o => o.Prediction != null);
            float dockingThresholdInteraction = _appSettings.Plotting.DockingThresholdInteraction;
            float thresholdInteraction = _appSettings.Plotting.ThresholdForInteraction;
            float thresholdKnown = _appSettings.Plotting.ThresholdForKnown;

            ViewBag.SameGeneProteinSymbol = results.All(o => o.Cavity.Protein.GeneSymbol == o.Cavity.Protein.ProteinSymbol);

            data = results
                .Where(o => hasPrediction ? o.Prediction?.Activity == BioActivity.Active
                    : o.MostSimilarCompound?.Similarity >= thresholdInteraction ? o.MostSimilarCompound?.Activity == BioActivity.Active : o.AverageDockingScore <= dockingThresholdInteraction)
                .Select(o => new[]
                {
                    o.Cavity.Protein.ProteinName,
                    null,
                    o.GetFormattedVinaScore(),
                    job.JobLigands.FirstOrDefault(p => p.LigandId == o.LigandId).LigandName,
                    o.LigandId.StringifyId(),
                    HttpContext.UseGeneSymbolForTargetDisplay() ? o.Cavity.Protein.GeneSymbol : o.Cavity.Protein.ProteinSymbol,
                    o.Cavity.Protein.OrganismSymbol,
                    (!hasPrediction ? o.MostSimilarCompound?.Similarity ?? 0
                    : o.MostSimilarActiveCompound != null && o.MostSimilarActiveCompound.Activity != BioActivity.Unknown ? o.MostSimilarActiveCompound.Similarity
                    : 0) >= thresholdKnown ? "1" : "0",
                })
                .ToArray();

            foreach (JobLigand item in job.JobLigands)
            {
                string ligandId = item.LigandId.StringifyId();
                if (!data.Any(o => o[4] == ligandId))
                    data = data.Append(new[]
                    {
                        null,
                        null,
                        null,
                        item.LigandName,
                        item.LigandId.StringifyId(),
                        null,
                        null,
                        null
                    }).ToArray();
            }
        }
        else
        {
            ViewBag.SameGeneProteinSymbol = false;

            data = await _mock
                .GetDataRaw(domainId, _appSettings.Test.PlottingMockDataSize)
                .Skip(1)
                .ToArrayAsync();
        }

        DrugModel model = DrugModel.FromRows(data, 2, 3, 4, 5, 6, 7);

        ViewBag.Data = JsonConvert.SerializeObject(model);

        return View(job);
    }

    [HttpGet("w{jobId:int}/compare/{cavityId:length(16)}/{ligandId:length(16)}")]
    public virtual async Task<IActionResult> Compare(string domainId, int jobId, string cavityId, string ligandId)
    {
        Domain domain = await _domainClient.GetOneAsync(domainId);
        if (domain == null || !domain.IsPublic && User.Identity?.IsAuthenticated != true)
            return NotFound();

        Job job = await _jobClient.GetOneAsync(jobId);
        if (job == null || job.IsPrivate && (!User.Identity.IsAuthenticated || job.UserId != User.Identity.Name?.ToLower()))
            return NotFound();

        Result result = await _resultClient.GetOneAsync(jobId, cavityId, ligandId);
        if (result == null)
            return NotFound();
        if (result.MostSimilarActiveCompound.Id == null)
            return NotFound();

        ViewBag.Keywords = domain.Keywords;

        CompareLigandsModel model = new()
        {
            DomainId = domainId,
            Result = result,
            Job = job,
        };

        // Sciently put a potentially missing ligand
        await _ligandClient.PutAsync(new() { Smiles = result.MostSimilarActiveCompound.Smiles });

        return View(model);
    }

    [HttpGet("w{jobId:int}/report")]
    public virtual async Task<IActionResult> Report(string domainId, int jobId)
    {
        Domain domain = await _domainClient.GetOneAsync(domainId);
        if (domain == null || !domain.IsPublic && User.Identity?.IsAuthenticated != true)
            return NotFound();

        Job job = await _jobClient.GetOneAsync(jobId);
        if (job == null || job.IsPrivate && (!User.Identity.IsAuthenticated || job.UserId != User.Identity.Name?.ToLower()))
            return NotFound();

        IReadOnlyList<Result> results = await _resultClient.List2Async(jobId);
        if (results == null)
            return NotFound();

        int maxStructureCount = results.Max(o => o.DockingScores.Length);
        bool hasPrediction = results.Any(o => o.Prediction != null);

        string[] headers = new[]
        {
            "Ligand",
            "SMILES",
            "Protein Symbol",
            "Gene Symbol",
            "Organism Symbol",
            "Approved Name",
            "Organism",
            "Synonyms",
        }
        .Concat(Enumerable.Range(0, maxStructureCount).Select(i => $"Docking Score Model {i + 1}"))
        .Concat(new[]
        {
            "Similarity Score",
            $"Best{(hasPrediction ? " Active" : "")} Match",
            $"Best{(hasPrediction ? " Active" : "")} Match Url",
            $"Best{(hasPrediction ? " Active" : "")} Match SMILES",
            $"Best{(hasPrediction ? " Active" : "")} Match Compare Url",
        })
        .Concat(hasPrediction ? new[]
        {
            "Prediction Result",
            "Confidence Level",
        } : Array.Empty<string>())
        .Append(
            "Source Url"
        )
        .ToArray();

        string hosting = _appSettings.ExternalUrls.Hosting.TrimEnd('/');
        IEnumerable<IEnumerable<string>> content = results.Select(o =>
        {
            List<string> list = new()
            {
                job.JobLigands.First(p=>p.LigandId == o.LigandId).LigandName,
                o.Ligand.Smiles,
                o.Cavity.Protein.ProteinSymbol,
                o.Cavity.Protein.GeneSymbol,
                o.Cavity.Protein.OrganismSymbol,
                o.Cavity.Protein.ProteinName,
                o.Cavity.Protein.Organism,
                string.Join(',', o.Cavity.Protein.Properties.Synonyms),
            };

            for (int i = 0; i < maxStructureCount; i++)
                list.Add(o.GetFormattedVinaScore(i));

            SimilarChemblCompound comp = hasPrediction ? o.MostSimilarActiveCompound : o.MostSimilarCompound;
            if (comp == null)
            {
                list.AddRange(new[] { "N/A", "N/A", "N/A", "N/A" });
            }
            else if (comp.Activity == BioActivity.Unknown)
            {
                list.AddRange(new[] { "?", "?", "?", "?" });
            }
            else
            {
                list.AddRange(new[]
                {
                    comp.Similarity.ToString(),
                    comp.Id,
                    comp.Url,
                    comp.Smiles,
                });
            }

            list.Add(hosting + Url.Action("Compare", "Job", new
            {
                domainId = domainId,
                jobId = job.Id,
                cavityId = o.CavityId.StringifyId(),
                ligandId = o.LigandId.StringifyId()
            }));

            if (hasPrediction)
            {
                list.Add(o.GetFormattedActivity());
                list.Add(o.GetFormattedConfidenceLevel());
            }

            list.Add(hosting + Url.Action("JobDetails", "Protein", new
            {
                domainId = domainId,
                jobId = job.Id,
                cavityId = o.CavityId.StringifyId()
            }));

            return list.AsEnumerable();
        });

        IEnumerable<string> rows = CsvHelper.FormatCsvRows(content, headers);
        StringBuilder sb = new();
        foreach (string row in rows)
        {
            sb.AppendLine(row);
        }

        byte[] bytes = Encoding.UTF8.GetBytes(sb.ToString());
        return File(bytes, "text/csv", $"job#{jobId}-{job.Name.EscapePath()}-output.csv");
    }
}