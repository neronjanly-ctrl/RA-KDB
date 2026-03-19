using System.Linq;
using System.Runtime.Serialization;

namespace DockingDataModels;

[DataContract]
public sealed class CavityIntegrity
{
    public bool IsDataComplete(bool strict)
    {
        if (strict)
            return Structures.Length > 0 && Structures.All(o => o.IsDataComplete());
        return Structures.All(o => o.IsDataComplete());
    }

    public bool IsManualDataComplete(bool strict)
    {
        if (strict)
            return Structures.Length > 0 && Structures.All(o => o.IsManualDataComplete());
        return Structures.All(o => o.IsManualDataComplete());
    }

    public bool IsAutomaticDataComplete(bool strict)
    {
        if (strict)
            return Structures.Length > 0 && Structures.All(o => o.IsAutomaticDataComplete());
        return Structures.All(o => o.IsAutomaticDataComplete());
    }

    public bool IsReadyForDocking()
    {
        return Structures.Length > 0 && Structures.All(o => o.IsReadyForComputation());
    }

    public bool IsReadyForVisualization()
    {
        return Structures.Length > 0 && Structures.All(o => o.IsReadyForVisualization());
    }

    [DataMember]
    public long CavityId { get; set; }

    [DataMember]
    public string BindingSite { get; set; }

    [DataMember]
    public StructureIntegrity[] Structures { get; set; }
}
