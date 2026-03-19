using System.Runtime.Serialization;

namespace DockingDataModels;

/// <summary>
/// The integrity information of the trained models
/// [Manually Collated]
///   N/A
/// [Automatically Generated]
///   HasScoreSummary, *HasTrainedModelLR, HasTrainedModelMLP, *HasTrainedModelRF, *HasTrainedModelSVM
/// *required for computation
/// #required for visualization
/// %preferred if exists
/// </summary>
[DataContract]
public sealed class TrainedModelsIntegrity : IIntegrity
{
    [DataMember]
    [IntegrityMeta("Model_LR.m", RequiredForComputation = true)]
    public bool HasTrainedModelLR { get; set; }

    [DataMember]
    [IntegrityMeta("Model_MLP.m")]
    public bool HasTrainedModelMLP { get; set; }

    [DataMember]
    [IntegrityMeta("Model_RF.m", RequiredForComputation = true)]
    public bool HasTrainedModelRF { get; set; }

    [DataMember]
    [IntegrityMeta("Model_SVM.m", RequiredForComputation = true)]
    public bool HasTrainedModelSVM { get; set; }
}
