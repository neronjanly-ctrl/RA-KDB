using DockingApiClient;
using DockingDataModels;
using GenericComputationPlatform.Extensions;
using GenericComputationPlatform.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        return View(domains);
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