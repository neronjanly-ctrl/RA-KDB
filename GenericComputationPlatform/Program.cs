using DockingApiClient;
using GenericComputationPlatform;
using GenericComputationPlatform.Mocks;
using GenericComputationPlatform.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using System;
using System.Net.Http;
using WebMarkupMin.AspNetCore7;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

/***********************************************
 *         Add and Configure Services
 **********************************************/

// By default, the HttpLogging middleware only logs headers and properties but not the body
builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.All;
    options.RequestHeaders.Add("X-Forwarded-For");
    options.RequestHeaders.Add("X-Forwarded-Host");
    options.RequestHeaders.Add("X-Forwarded-Server");
    options.RequestHeaders.Add("X-Forwarded-Proto");
});

// Set the remote ip address, request scheme and host using forwarded headers
// See https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/proxy-load-balancer?view=aspnetcore-7.0#forwarded-headers
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.All;
});

// Configure ASP.NET to allow the use of IHttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Register a named http client for connecting the api service
builder.Services.AddHttpClient("DockingApiHttpClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration.Get<AppSettings>()!.ExternalUrls.DockingApi);
});

// The named http client is registered to be scoped (i.e., one per http request)
// This way the http client is shared by all logic clients (like ProteinClient, LigandClient) in a request
builder.Services.AddScoped(provider =>
{
    HttpClient httpClient = provider.GetRequiredService<IHttpClientFactory>().CreateClient("DockingApiHttpClient");
    HttpContext context = provider.GetRequiredService<IHttpContextAccessor>().HttpContext;

    if (context != null)
    {
        // Use the end user's IP address while requesting an API
        string userIpAddress = context.Connection.RemoteIpAddress?.ToString();
        if (!string.IsNullOrEmpty(userIpAddress))
        {
            httpClient.DefaultRequestHeaders.Add("X-Forwarded-For", userIpAddress);
        }

        // Use the end user's requesting scheme
        string scheme = context.Request.Scheme;
        if (!string.IsNullOrEmpty(scheme))
        {
            httpClient.DefaultRequestHeaders.Add("X-Forwarded-Proto", scheme);
        }

        // Use the end user's requesting domain
        string host = context.Request.Host.Value;
        if (!string.IsNullOrEmpty(host))
        {
            httpClient.DefaultRequestHeaders.Add("X-Forwarded-Host", host);
        }
    }

    return httpClient;
});

// Add the logic clients
builder.Services.AddScoped<CavityClient>();
builder.Services.AddScoped<DomainClient>();
builder.Services.AddScoped<JobClient>();
builder.Services.AddScoped<LigandClient>();
builder.Services.AddScoped<ProteinClient>();
builder.Services.AddScoped<ResultClient>();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
    options.Secure = CookieSecurePolicy.Always;
    options.ConsentCookie.Name = builder.Configuration["CookieConsent:CookieName"];
});

builder.Services.AddAntiforgery(options =>
{
    options.Cookie.Name = builder.Configuration["Antiforgery:Cookie"];
    options.FormFieldName = builder.Configuration["Antiforgery:FormFieldName"];
});

builder.Services.AddMicrosoftIdentityWebAppAuthentication(builder.Configuration);
builder.Services.Configure<MicrosoftIdentityOptions>(options =>
{
    options.Scope.Add("email");
    options.Scope.Add("User.Read");
});

builder.Services.AddControllersWithViews(options =>
{
    // see https://docs.microsoft.com/en-us/aspnet/core/security/anti-request-forgery
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

builder.Services.AddHsts(options =>
{
    options.Preload = true;
    options.IncludeSubDomains = true;
    options.MaxAge = TimeSpan.FromDays(60);
});

builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
});

builder.Services.AddWebMarkupMin(options =>
{
    options.AllowCompressionInDevelopmentEnvironment = true;
    options.AllowMinificationInDevelopmentEnvironment = true;
    options.DisablePoweredByHttpHeaders = true;
})
.AddHtmlMinification(options =>
{
    options.MinificationSettings.RemoveRedundantAttributes = true;
    options.MinificationSettings.RemoveHttpProtocolFromAttributes = true;
    options.MinificationSettings.RemoveHttpsProtocolFromAttributes = true;
    options.MinificationSettings.MinifyEmbeddedCssCode = true;
    options.MinificationSettings.MinifyEmbeddedJsCode = true;
    options.MinificationSettings.MinifyInlineCssCode = true;
    options.MinificationSettings.MinifyInlineJsCode = true;
})
.AddHttpCompression();

builder.Services.AddTransient<DrugModelMock>();

builder.Services.Configure<AppSettings>(builder.Configuration);


/***********************************************
 *              Configure Hosting
 **********************************************/

// Remove the "Server: Kestrel" header
builder.WebHost.ConfigureKestrel(options =>
{
    options.AddServerHeader = false;
});


/***********************************************
 *             Configure Web App
 **********************************************/

WebApplication app = builder.Build();

string proxyPathBase = builder.Configuration["ServiceUrls:ProxyPathBase"]!; // Must not end with '/'; must start with '/' if not empty

// When the application is hosted behind an Apache reverse proxy, it is best practice for the application to work with a path base
// Which means, a form of path /pathbase/controller/action will be processed in both the request and the response.
// To allow this, in Apache conf, ProxyPass and ProxyPassReverse forwards to the internal host with the path base intact
// For example, ProxyPass /dockapi http://localhost:5080/dockapi
// In this way, ASP.NET takes care of the path base, and no html rewrite, redirect location rewrite, or app level url mapping is needed.
// Even if no path base present, ASP.NET will route the request to the correct endpoint.
app.UsePathBase(proxyPathBase);

if (app.Environment.IsDevelopment())
{
    // Enable payload logging
    app.UseHttpLogging();

    // Show detailed error info on exception thrown
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error");

    // HSTS module appends headers for enforcing HTTPS
    // see https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl
    app.UseHsts();
}

// Apache already has X-Forwarded-Host and X-Forwarded-For set
// Add additional settings in conf to help ASP.NET manage the forwarded proxy.
//   ProxyPreserveHost On: the external requested host is sent to the internal application.
//   RequestHeader set "X-Forwarded-Proto" expr=%{REQUEST_SCHEME}: the external requested scheme is set
app.UseForwardedHeaders();

// HttpsRedirection module redirect all HTTP requests to HTTPS
// see https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl
//app.UseHttpsRedirection();

// StaticFiles module deals with requests to css/js/image files etc.
app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = new ChemicalContentTypeProvider(),
});

// Runs matching. An endpoint is selected and set on the HttpContext if a match is found.
app.UseRouting();

// EU General Data Protection Regulation - Enforcement date: 25 May 2018
// see https://www.eugdpr.org/
// CookiePolicy module limits the use of non essential cookies like TempData and session state.
// see https://docs.microsoft.com/en-us/aspnet/core/security/gdpr
app.UseCookiePolicy();

app.UseAuthentication();
app.UseAuthorization();

// If the app uses Session or TempData based on Session:
// app.UseSession();

//app.UseWebMarkupMin();

// Executes the endpoint that was selected by routing.
app.MapControllers();

app.Run();
