using CommonTools;
using DockingDataModels;
using System.Collections.Generic;

namespace GenericComputationPlatform.ViewModels;

public class JobDetailsModel
{
    public string DomainId { get; set; }
    public Job Job { get; set; }
    public string GetLigandId(int index) => Job.GetLigands()[index].Id.StringifyId();

    public IEnumerable<BbbModel> BbbModels { get; } = BbbModel.GetModels();
    public IEnumerable<Fingerprint> FingerprintTypes { get; } = FingerprintExtensions.All;
    public IReadOnlyDictionary<string, string> ModelFormats { get; } = OpenBabelHelper.ModelFormats;

    public bool PreviewLigandModels { get; set; }
    public bool PreviewLigandFingerprints { get; set; }
}
