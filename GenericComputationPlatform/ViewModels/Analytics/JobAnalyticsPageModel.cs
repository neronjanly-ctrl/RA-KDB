using GenericComputationPlatform.Analytics;

namespace GenericComputationPlatform.ViewModels.Analytics;

public class JobAnalyticsPageModel
{
    public string DomainId { get; set; }
    public JobAnalyticsSummary Summary { get; set; }
    public JobAnalyticsConfigMeta ConfigMeta { get; set; }
    public object FrontendPayload { get; set; }
}
