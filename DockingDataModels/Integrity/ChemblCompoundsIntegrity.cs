using System.Runtime.Serialization;

namespace DockingDataModels;

/// <summary>
/// The integrity information of the chembl compounds
/// [Manually Collated]
///   N/A
/// [Automatically Generated]
///   chembBioactivityTxt, chemblBioactivityCsv, provisionedCompoundsCsv, *fingerprintDb
/// *required for computation
/// #required for visualization
/// %preferred if exists
/// </summary>
[DataContract]
public sealed class ChemblCompoundsIntegrity : IIntegrity
{
    [DataMember]
    [IntegrityMeta("{0}_Bioactivities.txt")]
    public bool HasChemblBioactivityTxt { get; set; }

    [DataMember]
    [IntegrityMeta("{0}_Bioactivities.csv")]
    public bool HasChemblBioactivityCsv { get; set; }

    [DataMember]
    [IntegrityMeta("{0}_ProvisionedCompounds.csv")]
    public bool HasProvisionedCompoundsCsv { get; set; }

    [DataMember]
    [IntegrityMeta("{0}_ChemblCompounds.fp2", RequiredForComputation = true)]
    public bool HasFp2FingerprintDb { get; set; }
}
