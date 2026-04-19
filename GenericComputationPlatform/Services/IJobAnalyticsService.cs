using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GenericComputationPlatform.Analytics;

namespace GenericComputationPlatform.Services;

public interface IJobAnalyticsService
{
    Task<JobAnalyticsSummary> BuildSummaryAsync(string domainId, int jobId, JobAnalyticsConfig config, CancellationToken ct = default);
    JobAnalyticsConfigMeta BuildRuntimeConfigMeta();
    JobAnalyticsConfig ApplyUserParams(JobAnalyticsConfig config);
    JobAnalyticsValidationResult ValidateConfig(JobAnalyticsConfig config, JobAnalyticsConfigMeta meta);
    JobAnalyticsValidationResult ValidateDataQuality(IReadOnlyCollection<JobAnalyticsRow> rows, JobAnalyticsPolicy policy);
    object BuildFrontendPayload(JobAnalyticsSummary summary, JobAnalyticsConfigMeta meta);
    string BuildSummaryCsv(JobAnalyticsSummary summary);
    string BuildFullAnalysisCsv(JobAnalyticsSummary summary);
}
