using DockingDataModels;
using System.Collections.Generic;

namespace GenericComputationPlatform.ViewModels;

public class TargetListModel : Paginated
{
    public Domain Domain { get; set; }
    public IReadOnlyList<Protein> Targets { get; set; }
    public int RunningCount { get; set; }
    public bool HasDocument { get; set; }
    public string TagId { get; set; }
    public string TagName { get; set; }
}
