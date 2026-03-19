using DockingApiClient;
using DockingDataModels;
using GenericComputationPlatform.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

namespace GenericComputationPlatform.Controllers;

[Route("user")]
public partial class UserController : Controller
{
    private readonly AppSettings _appSettings;
    private readonly JobClient _jobClient;
    private readonly DomainClient _domainClient;

    public UserController(
        IOptions<AppSettings> appSettings,
        JobClient jobClient,
        DomainClient domainClient)
    {
        _appSettings = appSettings.Value;
        _jobClient = jobClient;
        _domainClient = domainClient;
    }

    [HttpGet("signin")]
    public virtual IActionResult LogIn(string redirectUrl)
    {
        return Challenge(
            new AuthenticationProperties { RedirectUri = redirectUrl },
            OpenIdConnectDefaults.AuthenticationScheme); // jump to Microsoft to sign the user in
    }

    [HttpGet("signout")]
    public virtual IActionResult LogOut(string redirectUrl)
    {
        return SignOut(
            new AuthenticationProperties { RedirectUri = redirectUrl },
            CookieAuthenticationDefaults.AuthenticationScheme, // clear cookie
            OpenIdConnectDefaults.AuthenticationScheme); // jump to Microsoft to sign the user out
    }

    [HttpGet("/{domainId:required}/my-jobs/{pageNum:int=1}")]
    [Authorize]
    public virtual async Task<IActionResult> MyJobs(string domainId, int pageNum)
    {
        Domain domain = await _domainClient.GetOneAsync(domainId);
        if (domain == null || !domain.IsPublic && User.Identity?.IsAuthenticated != true)
            return NotFound();

        ViewBag.Keywords = domain.Keywords;

        System.Collections.Generic.IDictionary<RunningStatus, int> stat = await _jobClient.StatsForUserAsync(User.Identity.Name);

        int pageSize = _appSettings.PageSize.JobList;

        JobListModel model = new()
        {
            DomainId = domainId,
            PageSize = pageSize,
            PageNum = pageNum,
            Jobs = await _jobClient.ListForUserAsync(User.Identity.Name, (pageNum - 1) * pageSize, pageSize),
            RunningCount = stat.Sum(o => o.Value) - stat[RunningStatus.Finished] - stat[RunningStatus.Failed],
            TotalCount = stat.Sum(o => o.Value),
        };

        return View(model);
    }
}
