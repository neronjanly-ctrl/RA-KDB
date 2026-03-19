using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DockingDataModels;

[DataContract]
public class JobLigand
{
    /// <summary>
    /// The numeric job identifier in the relationship.
    /// </summary>
    [Key]
    [DataMember]
    public int JobId { get; set; }

    /// <summary>
    /// The numeric ligand identifier in the relationship.
    /// </summary>
    [Key]
    [DataMember]
    public long LigandId { get; set; }


    /// <summary>
    /// The mnemonic ligand name given by the creator.
    /// </summary>
    [Required]
    [DataMember]
    public string LigandName { get; set; }

    #region Navigation Properties

    /// <summary>
    /// The job in the relationship.
    /// </summary>
    [Required]
    [DataMember]
    public Job Job { get; set; }

    /// <summary>
    /// The ligand in the relationship.
    /// </summary>
    [Required]
    [DataMember]
    public Ligand Ligand { get; set; }

    #endregion
}
