using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace DockingDataModels;

[Owned]
[DataContract]
public class EnsemblEntry
{
    [DataMember]
    public string Id { get; set; }
    public string Url => Id == null ? null : $"https://www.ensembl.org/Homo_sapiens/Gene/Summary?g={Id}";
    public string RegionDetailUrl => Id == null ? null : $"https://www.ensembl.org/Homo_sapiens/Location/View?db=core;g={Id}";
    public string SequenceUrl => Id == null ? null : $"https://www.ensembl.org/Homo_sapiens/Gene/Sequence?g={Id}";
}
