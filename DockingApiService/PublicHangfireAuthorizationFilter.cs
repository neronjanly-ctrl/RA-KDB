using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace DockingApiService;

public class PublicHangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize([NotNull] DashboardContext context)
    {
        return true;
    }
}
