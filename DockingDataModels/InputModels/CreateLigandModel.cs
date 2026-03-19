using CommonTools;

namespace DockingDataModels;

/// <summary>
/// The input model for creating a ligand.
/// </summary>
public class CreateLigandModel
{
    /// <summary>
    /// The SMILES depicting the ligand.
    /// </summary>
    public string Smiles { get; set; }

    public long GetLigandId()
    {
        return Smiles.ComputeHashInt64();
    }
}
