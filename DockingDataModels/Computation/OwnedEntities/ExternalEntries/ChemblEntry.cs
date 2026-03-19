using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace DockingDataModels;

[Owned]
[DataContract]
public class ChemblEntry
{
    [DataMember]
    public string Id { get; set; }
    public string TargetUrl => Id == null ? null : $"https://www.ebi.ac.uk/chembl/target_report_card/{Id}/";
}
