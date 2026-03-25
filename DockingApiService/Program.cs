using DockingApiService;
using DockingApiService.DataModels;
using DockingApiService.Hubs;
using DockingApiService.Jobs;
using DockingApiService.Services;
using Hangfire;
using Hangfire.SQLite;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NJsonSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;


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

// Use custom antiforgery cookie/formfield names
builder.Services.AddAntiforgery(options =>
{
    options.Cookie.Name = builder.Configuration["Antiforgery:Cookie"];
    options.FormFieldName = builder.Configuration["Antiforgery:FormFieldName"];
});

builder.Services
    // Configure MVC services with controllers for WebApi
    .AddControllers()
    // Configure the options for using System.Text.Json in WebApi
    .AddJsonOptions(options =>
    {
        // CamelCase is actually the default policy for json property naming in (de)serialization
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

        // Ignore readonly properties and fields in json serialization
        // By far, NSwag does not respect these settings, so [JsonIgnore] or a custom schema processor must be used
        options.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
        options.JsonSerializerOptions.IgnoreReadOnlyFields = true;

        // Use $ref and $id in the json payload to refer to objects so that cycle references are properly maintained
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

// Register the OpenApi services
IEnumerable<IConfigurationSection> openApiEndpoints = builder.Configuration.GetSection("OpenApi:Endpoints").GetChildren();
string clientUrl = builder.Configuration["ClientUrl"];

foreach (IConfigurationSection ep in openApiEndpoints)
{
    builder.Services.AddOpenApiDocument(settings =>
    {
        // Get the version defined in the project file
        settings.Version = Assembly.GetExecutingAssembly()
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
            ?.InformationalVersion;

        settings.DocumentName = ep["DocumentName"];
        settings.Title = ep["Title"];
        settings.Description = string.Format(ep["Description"], clientUrl);

        // Enable Xml docs from comments
        settings.UseXmlDocumentation = true;

        // By default enums are handled in integers only
        settings.SchemaType = SchemaType.OpenApi3;
        settings.GenerateEnumMappingDescription = true;

        // By default base classes are standalone schemas
        settings.FlattenInheritanceHierarchy = true;

        // Add a filter to the front of the processor list
        settings.SchemaProcessors.Add(new ReadOnlyPropertyFilterSchemaProcessor(JsonNamingPolicy.CamelCase));
    });
}

// Add the database context
builder.Services.AddDbContext<ComputationContext>(options =>
{
    const string connStringName = "Computation";
    options.UseSqlite(builder.Configuration.GetConnectionString(connStringName)
        ?? throw new InvalidOperationException($"Connection string '{connStringName}' not found."));
});

// Add SignalR service
builder.Services.AddSignalR();

// Add Hangfire services
builder.Services.AddHangfire(options =>
{
    options.UseSQLiteStorage(builder.Configuration.GetConnectionString("Hangfire"));
});

builder.Services.AddHangfireServer(options =>
{
    options.WorkerCount = 1;
});

// Add computing service
builder.Services.AddTransient<ComputingService>();


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

string routeTmpl = builder.Configuration["OpenApi:RouteTemplate"]!; // Must start with '/'
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

// Apache already has X-Forwarded-Host and X-Forwarded-For set
// Add additional settings in conf to help ASP.NET manage the forwarded proxy.
//   ProxyPreserveHost On: the external requested host is sent to the internal application.
//   RequestHeader set "X-Forwarded-Proto" expr=%{REQUEST_SCHEME}: the external requested scheme is set
app.UseForwardedHeaders();

// Register the OpenAPI specification generator
app.UseOpenApi(settings =>
{
    // Set the url to the openapi.json specification (must be a raw application level path)
    settings.Path = routeTmpl;
});

// Register the Swagger UI middleware
app.UseSwaggerUi3(settings =>
{
    settings.Path = builder.Configuration["ServiceUrls:SwaggerUi"]; // Path prefix for hosting Swagger UI
    settings.DocumentPath = routeTmpl; // Url to the openapi.json specification (must be a public path)
    settings.DocumentTitle = builder.Configuration["Manifest:AppName"]; // SwaggerUI page title
    settings.CustomInlineStyles = ".swagger-ui .topbar-wrapper .link {display: none;}"; // Hide the SwaggerUI logo
});

// Register the ReDoc UI middleware
app.UseReDoc(settings =>
{
    settings.Path = builder.Configuration["ServiceUrls:RedocUi"]; // Path prefix for hosting Redoc UI
    settings.DocumentPath = routeTmpl; // Url to the openapi.json specification (must be a public path)
});

// Configure cross-site requester whitelist
string[] origins = builder.Configuration
    .GetSection("AllowedOrigins")
    .GetChildren()
    .Select(o => o.Value)
    .ToArray();

app.UseCors(config => config
    .WithOrigins(origins)
    .AllowAnyHeader()
    .AllowCredentials());

// Map endpoints
app.MapControllers();
app.MapHub<JobHub>(builder.Configuration["ServiceUrls:JobHub"]);

app.UseHangfireDashboard(
    builder.Configuration["ServiceUrls:Hangfire"], // Path prefix for hosting Hangfire UI
    new DashboardOptions()
    {
        AppPath = clientUrl,
        IgnoreAntiforgeryToken = true,

        // Allow access to Hangfire dashboard from the public
        // By default, Hangfire only allows access from local
        // When hosted behind Apache reverse proxy, the requested ip is always local
        // But with UseForwardedHeaders(), the real client ip is set
        Authorization = new[] { new PublicHangfireAuthorizationFilter() },
    }
);

app.EnsureMigrationOfContext<ComputationContext>();

app.Run();
