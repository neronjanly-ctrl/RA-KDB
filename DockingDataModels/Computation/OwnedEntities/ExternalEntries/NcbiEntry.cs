using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace DockingDataModels;

[Owned]
[DataContract]
public class NcbiEntry
{
    [DataMember]
    public string Id { get; set; }
    public string RefSeqUrl => Id == null ? null : $"https://www.ncbi.nlm.nih.gov/nuccore/{Id}";
    public string NCBISequenceViewerUrl => Id == null ? null : $"https://www.ncbi.nlm.nih.gov/projects/sviewer/?id={Id}";
}
