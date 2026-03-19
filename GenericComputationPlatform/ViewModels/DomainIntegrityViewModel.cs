using DockingDataModels;
using System.Collections.Generic;

namespace GenericComputationPlatform.ViewModels;

public class DomainIntegrityViewModel
{
    public string DomainId { get; set; }

    public bool UseStrictMode { get; set; }
    public bool HideHeaders { get; set; }
    public bool HideExistingFiles { get; set; }
    public bool HideOptionalFiles { get; set; }
    public bool HideBlankRows { get; set; }
    public string ViewMask { get; set; }

    public int MaxStructureCount { get; set; }
    public int DataCompleteCount { get; set; }
    public int ManualDataCompleteCount { get; set; }
    public int AutomaticDataCompleteCount { get; set; }
    public int HasReportsCount { get; set; }
    public int TotalCount { get; set; }

    public int ReadyForDockingCount { get; set; }
    public int TotalDockingCount { get; set; }
    public int ReadyForHuntingCount { get; set; }
    public int TotalHuntingCount { get; set; }
    public int ReadyForClassifyingCount { get; set; }
    public int TotalClassifyingCount { get; set; }
    public int ReadyForComputationCount { get; set; }
    public int TotalComputationCount { get; set; }
    public int ReadyForVisualizationCount { get; set; }
    public int TotalVisualizationCount { get; set; }

    public List<TargetReport> TargetReports { get; set; }
}
