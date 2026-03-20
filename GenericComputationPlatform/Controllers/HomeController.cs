using CommonTools;
using DockingApiClient;
using DockingDataModels;
using GenericComputationPlatform.Extensions;
using GenericComputationPlatform.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GenericComputationPlatform.Controllers;

[Route("/{domainId:required}")]
public partial class HomeController : Controller
{
    private readonly JobClient _jobClient;
    private readonly DomainClient _domainClient;
    private readonly ProteinClient _proteinClient;
    private readonly IHostEnvironment _env;

    public HomeController(
        JobClient jobClient,
        DomainClient domainClient,
        ProteinClient proteinClient,
        IHostEnvironment env)
    {
        _jobClient = jobClient;
        _domainClient = domainClient;
        _proteinClient = proteinClient;
        _env = env;
    }

    [HttpGet("/")]
    public virtual async Task<IActionResult> PlatformIndex()
    {
        IDictionary<RunningStatus, int> stat = await _jobClient.StatsAsync();
        ViewData["Badge"] = stat.RunningCount();

        IReadOnlyList<Domain> domains = await _domainClient.ListAsync();
        Domain raDomain = domains.FirstOrDefault(o =>o.IsPublic &&
            string.Equals(o.Id, "RA", System.StringComparison.OrdinalIgnoreCase));

        List<FeaturedProteinCardViewModel> featuredProteins = new();
        if (raDomain != null)
        {
            IReadOnlyList<Protein> proteins = await _proteinClient.ListByDomainAsync(raDomain.Id, null);

            featuredProteins = proteins
                .SelectMany(o => o.Cavities ?? new List<Cavity>())
                .Where(o => o.Protein != null)
                .OrderBy(o => o.Protein.ProteinName)
                .ThenBy(o => o.BindingSite)
                .Take(6)
                .Select(o => new FeaturedProteinCardViewModel
                {
                    DomainId = raDomain.Id,
                    CavityId = o.Id.StringifyId(),
                    ProteinId = o.ProteinId,
                    ProteinName = o.Protein.ProteinName,
                    Organism = o.Protein.Organism?.Replace(";", "; "),
                    Symbol = $"{o.Protein.ProteinSymbol}_{o.Protein.OrganismSymbol}",
                    Gene = o.Protein.GeneSymbol,
                    BindingSite = o.BindingSite,
                    ImageUrl = $"/images/s/{o.ProteinId}-{o.BindingSite}-model_1.png",
                    UniProtId = o.Protein.Properties?.UniProt?.Id,
                    UniProtUrl = o.Protein.Properties?.UniProt?.Url,
                    ChemblId = o.Protein.Properties?.Chembl?.Id,
                    ChemblUrl = o.Protein.Properties?.Chembl?.TargetUrl,
                })
                .ToList();
        }

        PlatformIndexViewModel model = new()
        {
            Domains = domains,
            FeaturedProteins = featuredProteins,
        };

        return View(model);
    }

    [HttpGet]
    public virtual async Task<IActionResult> Index(string domainId)
    {
        Domain domain = await _domainClient.GetOneAsync(domainId);
        if (domain == null || !domain.IsPublic && User.Identity?.IsAuthenticated != true)
            return NotFound();

        ViewBag.Keywords = domain.Keywords;

        IDictionary<RunningStatus, int> stat = await _jobClient.StatsForDomainAsync(domainId);
        ViewData["Badge"] = stat.RunningCount();
        ViewBag.Props = await _domainClient.PropertiesAsync(domainId);

        IReadOnlyList<ProteinTag> tags = await _proteinClient.GetTagsAsync(domainId);
        ViewBag.Tags = tags;

        IReadOnlyList<Protein> proteins = await _proteinClient.ListByDomainAsync(domainId, null);

        var allCavities = proteins
            .SelectMany(o => o.Cavities ?? new List<Cavity>())
            .Where(o => o.Protein != null)
            .ToList();

        ViewBag.WorkspaceProteinCount = proteins.Count;
        ViewBag.WorkspaceModuleCount = 4;
        ViewBag.WorkspaceStepCount = 3;

        List<FeaturedProteinCardViewModel> featuredWorkspaceProteins = allCavities
            .OrderBy(o => o.Protein.ProteinName)
            .ThenBy(o => o.BindingSite)
            .Take(6)
            .Select(o => new FeaturedProteinCardViewModel
            {
                DomainId = domainId,
                CavityId = o.Id.StringifyId(),
                ProteinId = o.ProteinId,
                ProteinName = o.Protein.ProteinName,
                Organism = o.Protein.Organism?.Replace(";", "; "),
                Symbol = $"{o.Protein.ProteinSymbol}_{o.Protein.OrganismSymbol}",
                Gene = o.Protein.GeneSymbol,
                BindingSite = o.BindingSite,
                ImageUrl = $"/images/s/{o.ProteinId}-{o.BindingSite}-model_1.png",
                UniProtId = o.Protein.Properties?.UniProt?.Id,
                UniProtUrl = o.Protein.Properties?.UniProt?.Url,
                ChemblId = o.Protein.Properties?.Chembl?.Id,
                ChemblUrl = o.Protein.Properties?.Chembl?.TargetUrl,
            })
            .ToList();

        ViewBag.FeaturedWorkspaceProteins = featuredWorkspaceProteins;

        return View(domain);
    }

    [HttpGet("targets/{tagId?}")]
    public virtual async Task<IActionResult> Targets(string domainId, string tagId)
    {
        Domain domain = await _domainClient.GetOneAsync(domainId);
        if (domain == null || !domain.IsPublic && User.Identity?.IsAuthenticated != true)
            return NotFound();

        ViewBag.Keywords = domain.Keywords;

        IDictionary<RunningStatus, int> stat = await _jobClient.StatsForDomainAsync(domainId);

        IReadOnlyList<Protein> proteins = await _proteinClient.ListByDomainAsync(domainId, tagId);
        TargetListModel model = new()
        {
            Domain = domain,
            Targets = proteins,
            PageNum = 1,
            PageSize = proteins.Count,
            TotalCount = proteins.Count,
            RunningCount = stat.RunningCount(),
            TagId = tagId,
            TagName = string.IsNullOrEmpty(tagId) ? null : await _proteinClient.GetTagNameAsync(tagId),
            HasDocument = System.IO.File.Exists(Path.Combine(_env.ContentRootPath, "wwwroot", $"{domainId}.docx")),
        };

        return View(model);
    }

    [HttpGet("help")]
    public virtual async Task<IActionResult> Help(string domainId)
    {
        Domain domain = await _domainClient.GetOneAsync(domainId);
        if (domain == null || !domain.IsPublic && User.Identity?.IsAuthenticated != true)
            return NotFound();

        ViewBag.Keywords = domain.Keywords;

        IDictionary<RunningStatus, int> stat = await _jobClient.StatsForDomainAsync(domainId);
        ViewData["Badge"] = stat.RunningCount();

        return View(domain);
    }

    [HttpGet("guestbook/new")]
    public async Task<IActionResult> NewPost(string domainId)
    {
        Domain domain = await _domainClient.GetOneAsync(domainId);
        if (domain == null || !domain.IsPublic)
            return NotFound();

        ViewBag.Keywords = domain.Keywords;

        return View();
    }

    [HttpGet("/error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public virtual IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}