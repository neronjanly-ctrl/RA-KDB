using DockingApiClient;
using DockingDataModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GenericComputationPlatform.Controllers;

public partial class ProteinController : Controller
{
    private readonly JobClient _jobClient;
    private readonly DomainClient _domainClient;
    private readonly CavityClient _cavityClient;

    public ProteinController(
        JobClient jobClient,
        DomainClient domainClient,
        CavityClient cavityClient)
    {
        _jobClient = jobClient;
        _domainClient = domainClient;
        _cavityClient = cavityClient;
    }

    [HttpGet("/{domainId:required}/protein/{cavityId:length(16)}")]
    public virtual async Task<IActionResult> Details(string domainId, string cavityId)
    {
        Domain domain = await _domainClient.GetOneAsync(domainId);
        if (domain == null || !domain.IsPublic && User.Identity?.IsAuthenticated != true)
            return NotFound();

        Cavity cavity = await _cavityClient.GetOneAsync(cavityId);
        if (cavity == null)
            return NotFound();

        ViewBag.Keywords = domain.Keywords;

        return View(cavity);
    }

    [HttpGet("/{domainId:required}/job/w{jobId:int}/protein/{cavityId:length(16)}")]
    public virtual async Task<IActionResult> JobDetails(string domainId, int jobId, string cavityId)
    {
        Domain domain = await _domainClient.GetOneAsync(domainId);
        if (domain == null || !domain.IsPublic && User.Identity?.IsAuthenticated != true)
            return NotFound();

        Job job = await _jobClient.GetOneAsync(jobId);
        if (job == null || job.IsPrivate && (!User.Identity.IsAuthenticated || job.UserId != User.Identity.Name?.ToLower()))
            return NotFound();

        Cavity cavity = await _cavityClient.GetOneAsync(cavityId);
        if (cavity == null)
            return NotFound();

        ViewBag.Keywords = domain.Keywords;

        return View("Details", cavity);
    }
}