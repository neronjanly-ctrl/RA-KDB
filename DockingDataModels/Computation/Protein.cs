using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DockingDataModels;

/// <summary>
/// A species-specific protein. Homologous protein for different species should be two different <see cref="Protein"/> objects.
/// </summary>
[DataContract(IsReference = true)]
public partial class Protein
{
    /// <summary>
    /// The unique identifier of the protein in the format of {ProteinSymbol}_{OrganismSymbol}.
    /// </summary>
    [Key]
    [DataMember]
    public string Id { get; set; }


    /// <summary>
    /// The date and time when the protein was created.
    /// </summary>
    [Required]
    [DataMember]
    public DateTime Created { get; set; }

    /// <summary>
    /// The date and time when the protein was last updated.
    /// </summary>
    [DataMember]
    public DateTime Updated { get; set; }


    /// <summary>
    /// The unique gene name of the protein. e.g. 5HT1B
    /// </summary>
    /// <remarks>
    /// in Properties.txt: [ProteinSymbol]
    /// </remarks>
    [Required]
    [DataMember]
    public string ProteinSymbol { get; set; }

    /// <summary>
    /// The short species (organism) symbol for the protein species. e.g. CAVPO
    /// </summary>
    /// <remarks>
    /// in Properties.txt: [OrganismSymbol]
    /// </remarks>
    [Required]
    [DataMember]
    public string OrganismSymbol { get; set; }

    /// <summary>
    /// The unique gene name of the protein. e.g. HTR1B
    /// </summary>
    /// <remarks>
    /// in Properties.txt: [Approved symbol]
    /// </remarks>
    [Required]
    [DataMember]
    public string GeneSymbol { get; set; }


    /// <summary>
    /// The full name of the protein. e.g. 5-hydroxytryptamine receptor 1B
    /// </summary>
    /// <remarks>
    /// in Properties.txt: [Approved Name]
    /// </remarks>
    [DataMember]
    public string ProteinName { get; set; }

    /// <summary>
    /// The species (organism) where the protein originated from. e.g. Cavia porcellus (Guinea pig)
    /// </summary>
    /// <remarks>
    /// in Properties.txt: [Species]
    /// </remarks>
    [DataMember]
    public string Organism { get; set; }

    #region Settings

    /// <summary>
    /// A boolean configuration entry indicating if the protein has active ChEMBL experimented compounds.
    /// </summary>
    [DataMember]
    public bool HasActiveChemblCompounds { get; set; }

    /// <summary>
    /// A boolean configuration entry indicating if the protein has ChEMBL experimented compounds.
    /// </summary>
    [DataMember]
    public bool HasChemblCompounds { get; set; }

    /// <summary>
    /// A boolean configuration entry indicating if the protein has trained machine learning models.
    /// </summary>
    [DataMember]
    public bool HasTrainedModels { get; set; }

    #endregion

    #region Snapshot Properties

    /// <summary>
    /// The snapshot number of structures the protein has.
    /// </summary>
    [DataMember]
    public int StructureCount { get; set; }

    /// <summary>
    /// The snapshot number of domains this protein included in.
    /// </summary>
    [DataMember]
    public int DomainCount { get; set; }

    /// <summary>
    /// The number of compound bioactivities in Chembl database.
    /// </summary>
    [DataMember]
    public int RawBioactivityCount { get; set; }

    /// <summary>
    /// The number of filtered compound bioactivities in Chembl database.
    /// </summary>
    [DataMember]
    public int BioactivityCount { get; set; }

    #endregion

    #region Navigation Properties

    /// <summary>
    /// The properties of the protein.
    /// </summary>
    [Required]
    [DataMember]
    public ProteinProperties Properties { get; set; }

    /// <summary>
    /// A list of domains that contains this protein.
    /// </summary>
    [DataMember]
    public List<DomainProtein> ProteinDomains { get; set; }

    /// <summary>
    /// A list of cavities / binding sites of this protein.
    /// </summary>
    [DataMember]
    public List<Cavity> Cavities { get; set; }

    /// <summary>
    /// A list of tags of this protein.
    /// </summary>
    [DataMember]
    public List<ProteinTag> Tags { get; set; }

    #endregion

    public void Init(string proteinSymbol, string organismSymbol, string geneSymbol)
    {
        ProteinSymbol = proteinSymbol;
        OrganismSymbol = organismSymbol;
        GeneSymbol = geneSymbol;
        Id = $"{proteinSymbol}_{OrganismSymbol}";
        Created = DateTime.UtcNow;
        Update();
    }

    public void Update()
    {
        Updated = DateTime.UtcNow;
    }
}
