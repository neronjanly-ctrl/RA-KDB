using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace DockingDataModels;

[Owned]
[DataContract]
public class UniProtEntry
{
    [DataMember]
    public string Id { get; set; }
    public string Url => Id == null ? null : $"https://www.uniprot.org/uniprot/{Id}";
    public string InterProUrl => Id == null ? null : $"https://www.ebi.ac.uk/interpro/{Id}";
    public string PDBeUrl => Id == null ? null : $"https://www.ebi.ac.uk/pdbe/searchResults.html?display=both&term={Id}";
}
