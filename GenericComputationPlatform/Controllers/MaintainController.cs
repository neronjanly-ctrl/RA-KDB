using DockingApiClient;
using DockingDataModels;
using GenericComputationPlatform.Extensions;
using GenericComputationPlatform.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericComputationPlatform.Controllers;

[Authorize]
[Route("maintain")]
public partial class MaintainController : Controller
{
    private readonly JobClient _jobClient;
    private readonly DomainClient _domainClient;
    private readonly ProteinClient _proteinClient;
    private readonly ResultClient _resultClient;
    private readonly LigandClient _ligandClient;

    public MaintainController(
        JobClient jobClient,
        DomainClient domainClient,
        ProteinClient proteinClient,
        ResultClient resultClient,
        LigandClient ligandClient)
    {
        _jobClient = jobClient;
        _domainClient = domainClient;
        _proteinClient = proteinClient;
        _resultClient = resultClient;
        _ligandClient = ligandClient;
    }

    [HttpGet]
    public virtual async Task<IActionResult> Index()
    {
        IReadOnlyList<Job> jobs = await _jobClient.List2Async();
        ViewBag.Jobs = jobs;

        IReadOnlyList<Domain> domains = await _domainClient.ListAsync();
        ViewBag.Domains = domains;

        IReadOnlyList<Protein> proteins = await _proteinClient.ListAsync();
        ViewBag.Proteins = proteins;

        return View();
    }

    [HttpGet("jobs")]
    public virtual async Task<IActionResult> Jobs()
    {
        IReadOnlyList<Job> jobs = await _jobClient.List2Async();
        return View(jobs);
    }

    [HttpGet("domains")]
    public virtual async Task<IActionResult> Domains()
    {
        IReadOnlyList<Domain> domains = await _domainClient.ListDetailedAsync();
        return View(domains);
    }

    [HttpGet("proteins")]
    public virtual async Task<IActionResult> Proteins()
    {
        IReadOnlyList<Protein> proteins = await _proteinClient.ListDetailedAsync();

        IReadOnlyList<TargetIntegrity> targets = await _proteinClient.IntegrityAsync();

        bool hideExistingFiles = false, hideOptionalFiles = true, useStrictMode = true;

        ViewBag.TargetReportDict = targets
            .SelectMany(o => o.Cavities
                .Select(p => new
                {
                    CavityId = p.CavityId,
                    Report = CreateTargetReport(o, p, hideExistingFiles, hideOptionalFiles, useStrictMode)
                })
            )
            .ToDictionary(o => o.CavityId, o => o.Report);

        return View(proteins);
    }

    [HttpGet("publish")]
    public virtual IActionResult Publish()
    {
        return View();
    }

    private static TargetReport CreateTargetReport(
        TargetIntegrity targetInt,
        CavityIntegrity cavityInt,
        bool hideExistingFiles,
        bool hideOptionalFiles,
        bool useStrictMode)
    {
        return new TargetReport
        {
            ProteinId = targetInt.Protein.Id,
            ProteinName = targetInt.Protein.ProteinName,
            BindingSite = cavityInt?.BindingSite,
            Structures = cavityInt?.Structures
                .Select(si => new FileReportSet(si.GetFiles(hideExistingFiles, hideOptionalFiles))
                {
                    IsDataComplete = si.IsDataComplete(),
                    IsManualDataComplete = si.IsManualDataComplete(),
                    IsAutomaticDataComplete = si.IsAutomaticDataComplete(),
                })
                .ToList() ?? new(),
            ChemblCompounds = targetInt.ChemblCompounds == null ? null :
                new FileReportSet(targetInt.ChemblCompounds.GetFiles(hideExistingFiles, hideOptionalFiles))
                {
                    IsDataComplete = targetInt.ChemblCompounds.IsDataComplete(),
                    IsManualDataComplete = targetInt.ChemblCompounds.IsManualDataComplete(),
                    IsAutomaticDataComplete = targetInt.ChemblCompounds.IsAutomaticDataComplete(),
                },
            TrainedModels = targetInt.TrainedModels == null ? null :
                new FileReportSet(targetInt.TrainedModels.GetFiles(hideExistingFiles, hideOptionalFiles))
                {
                    IsDataComplete = targetInt.TrainedModels.IsDataComplete(),
                    IsManualDataComplete = targetInt.TrainedModels.IsManualDataComplete(),
                    IsAutomaticDataComplete = targetInt.TrainedModels.IsAutomaticDataComplete(),
                },
            IsDataComplete = cavityInt?.IsDataComplete(useStrictMode) ?? false,
            IsManualDataComplete = cavityInt?.IsManualDataComplete(useStrictMode) ?? false,
            IsAutomaticDataComplete = cavityInt?.IsAutomaticDataComplete(useStrictMode) ?? false,
        };
    }

    // h: no-header
    // g: no-good-files
    // o: no-optional-files
    // b: no-blank-rows
    // s: strict mode
    private const string ViewCodes = "hgobs";

    [HttpGet("domain/{domainId:required}/integrity")]
    [HttpGet("domain/{domainId:required}/integrity/{viewMask}")]
    public virtual async Task<IActionResult> DomainIntegrity(string domainId, string viewMask)
    {
        DomainIntegrityViewModel model = new()
        {
            DomainId = domainId
        };

        if (viewMask != null && viewMask.All(o => ViewCodes.Contains(o)))
        {
            model.ViewMask = viewMask;
            foreach (char c in viewMask)
            {
                if (c == 'h') model.HideHeaders = true;
                else if (c == 'g') model.HideExistingFiles = true;
                else if (c == 'o') model.HideOptionalFiles = true;
                else if (c == 'b') model.HideBlankRows = true;
                else if (c == 's') model.UseStrictMode = true;
            }
            HttpContext.SetIntegrityView(viewMask);
        }
        else
        {
            model.ViewMask = "";
            HttpContext.SetIntegrityView("");
        }

        IReadOnlyList<TargetIntegrity> targets = await _domainClient.IntegrityAsync(domainId);

        model.TargetReports = targets.SelectMany(o => (o.Cavities.Length == 0 ? new CavityIntegrity[] { null } : o.Cavities)
            .Select(p => CreateTargetReport(o, p, model.HideExistingFiles, model.HideOptionalFiles, model.UseStrictMode)))
            .ToList();

        model.TotalCount = model.TargetReports.Count;
        model.HasReportsCount = model.TargetReports.Count(o => o.HasReports);
        model.DataCompleteCount = model.TargetReports.Count(o => o.IsDataComplete);
        model.ManualDataCompleteCount = model.TargetReports.Count(o => o.IsManualDataComplete);
        model.AutomaticDataCompleteCount = model.TargetReports.Count(o => o.IsAutomaticDataComplete);
        model.MaxStructureCount = model.TargetReports.Count > 0 ? model.TargetReports.Max(o => o.Structures.Count) : 0;

        model.ReadyForDockingCount = targets.Sum(o => o.Cavities.Count(p => p.IsReadyForDocking()));
        model.TotalDockingCount = targets.Sum(o => o.Cavities.Count(p => p.Structures.Length > 0));
        model.ReadyForHuntingCount = targets.Count(o => o.IsReadyForHunting());
        model.TotalHuntingCount = targets.Count(o => o.ChemblCompounds != null);
        model.ReadyForClassifyingCount = targets.Count(o => o.IsReadyForClassifying());
        model.TotalClassifyingCount = targets.Count(o => o.TrainedModels != null);
        model.ReadyForComputationCount = targets.Sum(o => o.Cavities.Count(p => p.IsReadyForDocking() && o.IsReadyForHunting() && o.IsReadyForClassifying()));
        model.TotalComputationCount = targets.Sum(o => o.Cavities.Count(p => p.Structures.Length > 0 || o.ChemblCompounds != null || o.TrainedModels != null));
        model.ReadyForVisualizationCount = targets.Sum(o => o.Cavities.Count(p => p.IsReadyForVisualization()));
        model.TotalVisualizationCount = targets.Sum(o => o.Cavities.Count(p => p.Structures.Length > 0));

        IReadOnlyList<Protein> proteins = await _proteinClient.ListAsync();

        ViewBag.Proteins = proteins
            .Where(o => !o.ProteinDomains.Any(p => p.DomainId == domainId))
            .ToArray();

        return View(model);
    }

    private void SetMessage(string msg, bool error = false)
    {
        Response.Cookies.Append("maintain-message", error ? $"<span style='color: red'>{msg}</span>" : msg, new CookieOptions { IsEssential = true });
    }

    [HttpPost("create-domain")]
    public virtual async Task<IActionResult> CreateDomain([FromForm] string domainId, [FromForm] string domainName)
    {
        if (string.IsNullOrWhiteSpace(domainId) || string.IsNullOrWhiteSpace(domainName))
        {
            SetMessage($"Arguments cannot be empty", true);
            return RedirectToAction(nameof(Domains));
        }

        domainId = domainId.Trim().ToLower();
        domainName = domainName.Trim();

        try
        {
            await _domainClient.CreateAsync(new() { Id = domainId, Name = domainName });
            SetMessage($"Created domain {domainId}.");
            return Redirect($"{Url.Action(nameof(Domains))}#{domainId}");
        }
        catch (ApiException)
        {
            SetMessage($"ERROR: Failed to create domain {domainId}.", true);
            return RedirectToAction(nameof(Domains));
        }
    }

    [HttpPost("publish-domain/{domainId:required}")]
    public virtual async Task<IActionResult> PublishDomain(string domainId)
    {
        try
        {
            await _domainClient.PublishAsync(domainId);
            SetMessage($"Published domain {domainId}.");
        }
        catch (ApiException)
        {
            SetMessage($"ERROR: Must go to 'Manage Proteins' and resolve all errors in domain {domainId}.", true);
        }
        return RedirectToAction(nameof(Domains));
    }

    [HttpPost("delete-domain/{domainId:required}")]
    public virtual async Task<IActionResult> DeleteDomain(string domainId)
    {
        try
        {
            await _domainClient.DeleteAsync(domainId);
            SetMessage($"Deleted domain {domainId}.");
        }
        catch (ApiException)
        {
            SetMessage($"ERROR: No such domain {domainId} or it has proteins.", true);
        }
        return RedirectToAction(nameof(Domains));
    }

    [HttpPost("update-domain/{domainId:required}")]
    public virtual async Task<IActionResult> UpdateDomain(string domainId, [FromForm] string name, [FromForm] string keywords, [FromForm] string description, [FromForm] string citations)
    {
        try
        {
            string[] keywordArray = keywords?
                .Split("\r\n".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries)
                .Select(o => o.Trim())
                .Where(o => !string.IsNullOrEmpty(o))
                .Distinct()
                .ToArray();

            await _domainClient.UpdateAsync(domainId, new()
            {
                Name = name,
                Keywords = keywordArray,
                Description = description,
                Citations = citations
            });
            SetMessage($"Updated domain {domainId}.");
        }
        catch (ApiException)
        {
            SetMessage($"ERROR: No such domain {domainId}.", true);
        }
        return RedirectToAction(nameof(Domains));
    }

    [HttpPost("add-domain-proteins/{domainId:required}")]
    public virtual async Task<IActionResult> AddDomainProteins(string domainId, [FromForm] string proteinIds)
    {
        try
        {
            string[] proteinIdArray = proteinIds?
                .Split("\r\n".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries)
                .Select(o => o.Trim().ToUpper())
                .Where(o => !string.IsNullOrEmpty(o))
                .Distinct()
                .ToArray();

            await _domainClient.AddProteinsAsync(domainId, proteinIdArray);
            SetMessage($"Added proteins to domain {domainId}.");
        }
        catch (ApiException)
        {
            SetMessage($"ERROR: Failed to add proteins to domain {domainId}. Check the protein IDs and resolve all errors first.", true);
        }
        return RedirectToAction(nameof(DomainIntegrity), new { domainId });
    }

    [HttpPost("delete-domain-protein/{domainId:required}/{proteinId:required}")]
    public virtual async Task<IActionResult> DeleteDomainProtein(string domainId, string proteinId)
    {
        try
        {
            await _domainClient.DeleteProteinAsync(domainId, proteinId);
            SetMessage($"Deleted {proteinId} from domain {domainId}.");
        }
        catch (ApiException)
        {
            SetMessage($"ERROR: Failed to delete {proteinId} from domain {domainId}.", true);
        }
        return RedirectToAction(nameof(DomainIntegrity), new { domainId });
    }

    [HttpPost("reissue-job/{jobId:required}")]
    public virtual async Task<IActionResult> ReissueJob(int jobId)
    {
        try
        {
            await _jobClient.ReissueAsync(jobId);
            SetMessage($"Reissued job for job #{jobId}.");
        }
        catch (ApiException)
        {
            SetMessage($"ERROR: No such job #{jobId} or not created.", true);
        }
        return RedirectToAction(nameof(Jobs));
    }

    [HttpPost("delete-job/{jobId:required}")]
    public virtual async Task<IActionResult> DeleteJob(int jobId)
    {
        try
        {
            await _jobClient.DeleteAsync(jobId);
            SetMessage($"Deleted job #{jobId}.");
        }
        catch (ApiException)
        {
            SetMessage($"ERROR: No such job #{jobId} or it is not finished.", true);
        }
        return RedirectToAction(nameof(Jobs));
    }

    [HttpPost("clear-result/{jobId:required}")]
    public virtual async Task<IActionResult> ClearResult(int jobId)
    {
        try
        {
            await _resultClient.DeleteAsync(jobId);
            SetMessage($"Cleared results for job #{jobId}.");
        }
        catch (ApiException)
        {
            SetMessage($"ERROR: No such job #{jobId} or not finished.", true);
        }
        return RedirectToAction(nameof(Jobs));
    }

    [HttpPost("erase-cache/{jobId:required}")]
    public virtual async Task<IActionResult> EraseCache(int jobId)
    {
        try
        {
            await _resultClient.DeleteCacheAsync(jobId);
            SetMessage($"Erased iDock cache for job #{jobId}.");
        }
        catch (ApiException)
        {
            SetMessage($"ERROR: Failed to erase iDock cache for job #{jobId}", true);
        }
        return RedirectToAction(nameof(Jobs));
    }

    [HttpPost("rename-job/{jobId:required}")]
    public virtual async Task<IActionResult> RenameJob(int jobId, [FromForm] string name)
    {
        try
        {
            await _jobClient.RenameAsync(jobId, new() { NewName = name });
            SetMessage($"Job #{jobId} renamed to '{name}'.");
        }
        catch (ApiException)
        {
            SetMessage($"ERROR: No such job #{jobId}.", true);
        }
        return RedirectToAction(nameof(Jobs));
    }

    [HttpPost("fail/{jobId:required}")]
    public virtual async Task<IActionResult> FailJob(int jobId)
    {
        try
        {
            await _jobClient.FailAsync(jobId);
            SetMessage($"Set job #{jobId} to failed.");
        }
        catch (ApiException)
        {
            SetMessage($"ERROR: Failed to set job #{jobId} to failed.", true);
        }
        return RedirectToAction(nameof(Jobs));
    }
}