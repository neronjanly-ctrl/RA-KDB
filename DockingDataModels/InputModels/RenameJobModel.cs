namespace DockingDataModels;

/// <summary>
/// The input model for renaming a job.
/// </summary>
public class RenameJobModel
{
    /// <summary>
    /// A new mnemonic name for the job
    /// </summary>
    public string NewName { get; set; }
}
