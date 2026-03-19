using CommonTools;
using DockingDataModels;

namespace GenericComputationPlatform.ViewModels;

public class JobOutputModel : Paginated
{
    public string DomainId { get; set; }

    public Job Job { get; set; }

    public string GetLigandId(int index) => Job.GetLigands()[index].Id.StringifyId();

    public Result[] Results { get; set; }

    public bool UseCardOutputDisplay { get; set; }

    public bool UseGeneSymbolForTargetDisplay { get; set; }

    public int MaxStructureCount { get; set; }

    public bool HasPrediction { get; set; }

    public bool SameGeneProteinSymbol { get; set; }
}
