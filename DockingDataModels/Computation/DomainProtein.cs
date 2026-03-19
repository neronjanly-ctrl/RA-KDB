using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DockingDataModels;

[DataContract]
public class DomainProtein
{
    /// <summary>
    /// The string domain identifier in the relationship.
    /// </summary>
    [Key]
    [DataMember]
    public string DomainId { get; set; }

    /// <summary>
    /// The numeric protein identifier in the relationship.
    /// </summary>
    [Key]
    [DataMember]
    public string ProteinId { get; set; }


    #region Navigation Properties

    /// <summary>
    /// The domain in the relationship.
    /// </summary>
    [Required]
    [DataMember]
    public Domain Domain { get; set; }

    /// <summary>
    /// The protein in the relationship.
    /// </summary>
    [Required]
    [DataMember]
    public Protein Protein { get; set; }

    #endregion
}
