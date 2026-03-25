using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace DockingDataModels;

[DataContract(IsReference = true)]
public class Domain
{
    /// <summary>
    /// The mnemonic keyword / identifier of the domain, used in the url.
    /// </summary>
    [Key]
    [DataMember]
    public string Id { get; set; }


    /// <summary>
    /// The date and time when the domain was created.
    /// </summary>
    [Required]
    [DataMember]
    public DateTime Created { get; set; }

    /// <summary>
    /// The date and time when the domain was last updated.
    /// </summary>
    [DataMember]
    public DateTime Updated { get; set; }


    /// <summary>
    /// The display name of the domain.
    /// </summary>
    [Required]
    [DataMember]
    public string Name { get; set; }

    /// <summary>
    /// The informatic description of the domain.
    /// </summary>
    [DataMember]
    public string Description { get; set; }

    /// <summary>
    /// The citation section of the domain.
    /// </summary>
    [DataMember]
    public string Citation { get; set; }

    /// <summary>
    /// The keywords of the domain.
    /// </summary>
    [DataMember]
    public string[] Keywords { get; set; }

    /// <summary>
    /// A boolean value indicating if the domain is available for the public.
    /// </summary>
    [DataMember]
    public bool IsPublic { get; set; }


    #region Snapshot Properties

    /// <summary>
    /// The snapshot number of proteins included in the domain.
    /// </summary>
    [DataMember]
    public int ProteinCount { get; set; }

    #endregion

    #region Navigation Properties

    /// <summary>
    /// A list of the proteins included in the domain. Could be empty if the API doesn't make use of it.
    /// </summary>
    [DataMember]
    public List<DomainProtein> DomainProteins { get; set; }

    /// <summary>
    /// A list of jobs that uses this domain. Could be empty if the API doesn't make use of it.
    /// </summary>
    [DataMember]
    public List<JobDomain> DomainJobs { get; set; }

    #endregion

    #region Store Procedures

    public void Init(string id, string name, bool isPublic)
    {
        Id = id;
        Name = name;
        IsPublic = isPublic;
        Created = DateTime.UtcNow;
        Update();
    }

    public void Update()
    {
        Updated = DateTime.UtcNow;
    }

    public Protein[] GetProteins()
    {
        return DomainProteins.Select(o => o.Protein).OrderBy(o => o.ProteinSymbol).ToArray();
    }

    public Job[] GetJobs()
    {
        return DomainJobs.Select(o => o.Job).ToArray();
    }

    #endregion
}
