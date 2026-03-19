using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace DockingDataModels;

[Owned]
[DataContract]
public class GenBankEntry
{
    [DataMember]
    public string Id { get; set; }
    public string Url => Id == null ? null : $"https://www.ncbi.nlm.nih.gov/nuccore/{Id}";
    public string ENAUrl => Id == null ? null : $"https://www.ebi.ac.uk/ena/data/view/{Id}";
    public string DDBJUrl => Id == null ? null : $"http://getentry.ddbj.nig.ac.jp/getentry/na/{Id}";
}
