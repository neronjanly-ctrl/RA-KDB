using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace DockingDataModels;

[Owned]
[DataContract]
public class PdbEntry
{
    [DataMember]
    public string Id { get; set; }
    public string RcsbUrl => Id == null ? null : $"https://www.rcsb.org/structure/{Id}";
    public string RcsbPdbDownloadUrl => Id == null ? null : $"https://files.rcsb.org/download/{Id}.pdb";
    public string RcsbCifDownloadUrl => Id == null ? null : $"https://files.rcsb.org/download/{Id}.cif";
}
