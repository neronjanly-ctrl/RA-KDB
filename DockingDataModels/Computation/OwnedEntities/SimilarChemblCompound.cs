using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DockingDataModels;

[Owned]
[DataContract]
public class SimilarChemblCompound
{
    /// <summary>
    /// The identifier of the compound in the ChEMBL db.
    /// </summary>
    [DataMember]
    public string Id { get; set; }

    /// <summary>
    /// The SMILES of the compound in the ChEMBL db.
    /// </summary>
    [DataMember]
    public string Smiles { get; set; }

    /// <summary>
    /// The bioactivity of the compound toward the target in the ChEMBL db.
    /// </summary>
    [DataMember]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public BioActivity Activity { get; set; }

    /// <summary>
    /// The computed molecular fingerprint (typically in FP2 type) of the compound in ChEMBL db.
    /// </summary>
    [DataMember]
    public byte[] Fingerprint { get; set; }

    /// <summary>
    /// The similarity between this compound and the input compound.
    /// </summary>
    [DataMember]
    public float Similarity { get; set; }

    public string Url => Id == null ? null : $"https://www.ebi.ac.uk/chembl/compound_report_card/{Id}/";
}
