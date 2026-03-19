using System.Linq;
using System.Runtime.Serialization;

namespace DockingDataModels;

[DataContract]
public sealed class TargetIntegrity : IIntegrity
{
    public bool IsDataComplete(bool strict)
    {
        if (strict)
            return Cavities.Length > 0 && Cavities.All(p => p.IsDataComplete(strict))
                && ChemblCompounds != null && ChemblCompounds.IsDataComplete()
                && TrainedModels != null && TrainedModels.IsDataComplete();
        return Cavities.All(p => p.Structures.All(o => o.IsDataComplete()))
            && (ChemblCompounds == null || ChemblCompounds.IsDataComplete())
            && (TrainedModels == null || TrainedModels.IsDataComplete());
    }

    public bool IsManualDataComplete(bool strict)
    {
        if (strict)
            return Cavities.Length > 0 && Cavities.All(p => p.IsManualDataComplete(strict))
                && ChemblCompounds != null && ChemblCompounds.IsManualDataComplete()
                && TrainedModels != null && TrainedModels.IsManualDataComplete();
        return Cavities.All(p => p.Structures.All(o => o.IsManualDataComplete()))
            && (ChemblCompounds == null || ChemblCompounds.IsManualDataComplete())
            && (TrainedModels == null || TrainedModels.IsManualDataComplete());
    }

    public bool IsAutomaticDataComplete(bool strict)
    {
        if (strict)
            return Cavities.Length > 0 && Cavities.All(p => p.IsAutomaticDataComplete(strict))
                && ChemblCompounds != null && ChemblCompounds.IsAutomaticDataComplete()
                && TrainedModels != null && TrainedModels.IsAutomaticDataComplete();
        return Cavities.All(p => p.Structures.All(o => o.IsAutomaticDataComplete()))
            && (ChemblCompounds == null || ChemblCompounds.IsAutomaticDataComplete())
            && (TrainedModels == null || TrainedModels.IsAutomaticDataComplete());
    }

    public bool IsReadyForDocking()
    {
        return Cavities.Length > 0 && Cavities.All(o => o.IsReadyForDocking());
    }

    public bool IsReadyForHunting()
    {
        return ChemblCompounds != null && ChemblCompounds.IsReadyForComputation();
    }

    public bool IsReadyForClassifying()
    {
        return TrainedModels != null && TrainedModels.IsReadyForComputation();
    }

    public bool IsReadyForComputation()
    {
        return IsReadyForDocking() && IsReadyForHunting() && IsReadyForClassifying();
    }

    public bool IsReadyForVisualization()
    {
        return Cavities.Length > 0 && Cavities.All(o => o.IsReadyForVisualization());
    }


    [DataMember]
    public Protein Protein { get; set; }

    [DataMember]
    public CavityIntegrity[] Cavities { get; set; }

    [DataMember]
    public ChemblCompoundsIntegrity ChemblCompounds { get; set; }

    [DataMember]
    public TrainedModelsIntegrity TrainedModels { get; set; }
}
