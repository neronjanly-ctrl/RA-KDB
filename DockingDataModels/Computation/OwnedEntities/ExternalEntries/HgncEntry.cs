using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace DockingDataModels;

[Owned]
[DataContract]
public class HgncEntry
{
    [DataMember]
    public int Id { get; set; }
    public string GeneNamesUrl => Id == 0 ? null : $"https://www.genenames.org/data/gene-symbol-report/#!/hgnc_id/{Id}";
}
