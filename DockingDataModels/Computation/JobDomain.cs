using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DockingDataModels;

[DataContract]
public class JobDomain
{
    /// <summary>
    /// The numeric job identifier of the domain.
    /// </summary>
    [Key]
    [DataMember]
    public int JobId { get; set; }

    /// <summary>
    /// The string domain identifier of the job.
    /// </summary>
    [Key]
    [DataMember]
    public string DomainId { get; set; }


    #region Navigation Properties

    /// <summary>
    /// The job in the relationship.
    /// </summary>
    [Required]
    [DataMember]
    public Job Job { get; set; }

    /// <summary>
    /// The domain in the relationship.
    /// </summary>
    [Required]
    [DataMember]
    public Domain Domain { get; set; }

    #endregion
}
