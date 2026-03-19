namespace DockingDataModels;

/// <summary>
/// The input model for creating a job.
/// </summary>
public class CreateJobModel
{
    /// <summary>
    /// The identifiers for target domains that the creating job will use.
    /// </summary>
    public string[] DomainIds { get; set; }

    /// <summary>
    /// The mnemonic name for the creating job.
    /// </summary>
    public string JobName { get; set; }

    /// <summary>
    /// The name list of the ligands to be docked and predicted against the targets in the specified domains.
    /// The number of ligand names must be the same as the number of Smiles.
    /// </summary>
    public string[] LigandNames { get; set; }

    /// <summary>
    /// The list of the ligands in SMILES format to be docked and predicted against the targets in the specified domains.
    /// The number of ligand Smiles must be the same as the number of ligand names.
    /// </summary>
    public string[] Smiles { get; set; }

    /// <summary>
    /// A boolean value indicating if the job is private to the creator.
    /// </summary>
    public bool IsPrivate { get; set; }

    /// <summary>
    /// The email of the user who is creating this job. Null for anonymous users.
    /// </summary>
    public string UserId { get; set; }
}
