using System.Collections.Generic;
using DockingDataModels;

namespace GenericComputationPlatform.Analytics;

public class JobAnalyticsSummary
{
    public string DomainId { get; set; }
    public Job Job { get; set; }
    public int TotalRows { get; set; }
    public int AnalyzableRows { get; set; }
    public int ExcludedByMissingDocking { get; set; }
    public int ExcludedByMissingSimilarity { get; set; }
    public float? MeanDocking { get; set; }
    public float? MedianDocking { get; set; }
    public int HighPriorityCount { get; set; }
    public List<JobAnalyticsRow> Rows { get; set; } = new();
    public List<JobAnalyticsRow> TopCandidates { get; set; } = new();
    public List<JobAnalyticsGroupSummary> GroupedByProtein { get; set; } = new();
    public List<JobAnalyticsGroupSummary> GroupedByGene { get; set; } = new();
    public List<JobAnalyticsGroupSummary> GroupedByLigand { get; set; } = new();
    public Dictionary<string, object> DistributionStats { get; set; } = new();
    public JobAnalyticsFigures Figures { get; set; } = new();
    public JobAnalyticsConfig AppliedConfig { get; set; } = new();
    public JobAnalyticsValidationResult Validation { get; set; } = new();
}

public class JobAnalyticsGroupSummary
{
    public string GroupKey { get; set; }
    public int TotalRows { get; set; }
    public int AnalyzableRows { get; set; }
    public float? MeanPriorityScore { get; set; }
    public float? MeanDocking { get; set; }
}
