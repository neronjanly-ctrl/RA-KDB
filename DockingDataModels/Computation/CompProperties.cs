using System.Runtime.Serialization;

namespace DockingDataModels;

[DataContract]
public class CompProperties
{
    /// <summary>
    /// A boolean configuration entry indicating if has active ChEMBL experimented compounds.
    /// </summary>
    [DataMember]
    public bool HasActiveChemblCompounds { get; set; }

    /// <summary>
    /// A boolean configuration entry indicating if has ChEMBL experimented compounds.
    /// </summary>
    [DataMember]
    public bool HasChemblCompounds { get; set; }

    /// <summary>
    /// A boolean configuration entry indicating if has trained machine learning models.
    /// </summary>
    [DataMember]
    public bool HasTrainedModels { get; set; }
}
