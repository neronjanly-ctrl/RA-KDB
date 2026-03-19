using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DockingDataModels;

[DataContract]
public class ProteinProperties
{
    /// <summary>
    /// The numeric identifier of the protein.
    /// </summary>
    [Key]
    [DataMember]
    public string ProteinId { get; set; }


    /// <summary>
    /// The synonyms of the protein.
    /// </summary>
    /// <remarks>
    /// in csv:
    /// Synonyms
    /// </remarks>
    [DataMember]
    public string[] Synonyms { get; set; }

    /// <summary>
    /// The locus type of the protein.
    /// </summary>
    /// <remarks>
    /// in csv:
    /// Locus type
    /// </remarks>
    [DataMember]
    public string LocusType { get; set; }

    /// <summary>
    /// The chromosomal location of the protein.
    /// </summary>
    /// <remarks>
    /// in csv:
    /// Chromosomal location
    /// </remarks>
    [DataMember]
    public string ChromosomalLocation { get; set; }

    /// <summary>
    /// The gene family of the protein.
    /// </summary>
    /// <remarks>
    /// in csv:
    /// Gene family
    /// </remarks>
    [DataMember]
    public string GeneFamily { get; set; }

    /// <summary>
    /// The identifier for the HUGO Gene Nomenclature Committee (HGNC).
    /// </summary>
    [DataMember]
    public HgncEntry Hgnc { get; set; }

    /// <summary>
    /// The UniProt entry of the protein.
    /// </summary>
    [DataMember]
    public UniProtEntry UniProt { get; set; }

    /// <summary>
    /// The Ensembl entry of the protein.
    /// </summary>
    [DataMember]
    public EnsemblEntry Ensembl { get; set; }

    /// <summary>
    /// The GenBank entry of the protein.
    /// </summary>
    [DataMember]
    public GenBankEntry GenBank { get; set; }

    /// <summary>
    /// The entry for the National Center for Biotechnology Information (NCBI)
    /// </summary>
    [DataMember]
    public NcbiEntry Ncbi { get; set; }

    /// <summary>
    /// The entry for chemical database of the European Molecular Biology Laboratory (EMBL)
    /// </summary>
    [DataMember]
    public ChemblEntry Chembl { get; set; }

    #region Navigation Properties

    /// <summary>
    /// The protein of which the properties are.
    /// </summary>
    [Required]
    [DataMember]
    public Protein Protein { get; set; }

    #endregion
}
