using System.Collections.Generic;
using System.Linq;

namespace DockingDataModels;

public class FileReport
{
    public string FileName { get; set; }
    public bool Manual { get; set; }
    public bool RequiredForComputation { get; set; }
    public bool RequiredForVisualization { get; set; }
    public bool Exists { get; set; }
}

public class FileReportSet : List<FileReport>
{
    public bool IsDataComplete { get; set; }
    public bool IsManualDataComplete { get; set; }
    public bool IsAutomaticDataComplete { get; set; }

    public FileReportSet(IEnumerable<FileReport> data)
    {
        AddRange(data);
    }
}

public class TargetReport
{
    public List<FileReportSet> Structures { get; set; }
    public FileReportSet ChemblCompounds { get; set; }
    public FileReportSet TrainedModels { get; set; }
    public string ProteinName { get; set; }
    public string ProteinId { get; set; }
    public string BindingSite { get; set; }
    public bool IsDataComplete { get; set; }
    public bool IsManualDataComplete { get; set; }
    public bool IsAutomaticDataComplete { get; set; }
    public bool HasReports => Structures.Any(o => o.Count > 0) || ChemblCompounds?.Count > 0 || TrainedModels?.Count > 0;
}
