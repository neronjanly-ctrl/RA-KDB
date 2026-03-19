using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DockingDataModels;

[DataContract]
public class ProteinTag
{
    [Key]
    [DataMember]
    public string Id { get; set; }

    [DataMember]
    public string Name { get; set; }

    [DataMember]
    public List<Protein> Proteins { get; set; }
}
