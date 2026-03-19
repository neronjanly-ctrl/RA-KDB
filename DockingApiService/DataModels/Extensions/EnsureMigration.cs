using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DockingApiService.DataModels;

public static class EnsureMigration
{
    public static void EnsureMigrationOfContext<TContext>(this IApplicationBuilder app) where TContext : DbContext
    {
        using IServiceScope serviceScope = app.ApplicationServices.CreateScope();
        TContext context = serviceScope.ServiceProvider.GetService<TContext>();
        context.Database.Migrate();
    }
}
