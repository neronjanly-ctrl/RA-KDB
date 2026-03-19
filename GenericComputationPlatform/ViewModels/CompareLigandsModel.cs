using CommonTools;
using DockingDataModels;

namespace GenericComputationPlatform.ViewModels;

public class CompareLigandsModel
{
    public string DomainId { get; set; }
    public Job Job { get; set; }
    public string GetLigandId(int index) => Job.GetLigands()[index].Id.StringifyId();
    public Result Result { get; set; }
}
