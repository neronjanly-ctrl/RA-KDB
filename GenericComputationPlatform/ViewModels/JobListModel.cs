using DockingDataModels;
using System.Collections.Generic;

namespace GenericComputationPlatform.ViewModels;

public class JobListModel : Paginated
{
    public string DomainId { get; set; }
    public IReadOnlyList<Job> Jobs { get; set; }
    public int RunningCount { get; set; }
}
