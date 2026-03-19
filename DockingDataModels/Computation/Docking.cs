using CommonTools;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DockingDataModels;

public class Docking
{
    /// <summary>
    /// Hash computed with ReceptorPdbqtHash|Smiles|Arguments
    /// </summary>
    [Key]
    public long Id { get; set; }

    /// <summary>
    /// The 64-bit hash of the receptor pdbqt file
    /// </summary>
    public long ReceptorPdbqtHash { get; set; }

    /// <summary>
    /// The 64-bit hash of the ligand pdbqt file
    /// </summary>
    public long LigandPdbqtHash { get; set; }

    /// <summary>
    /// Ligand smiles
    /// </summary>
    public string Smiles { get; set; }

    /// <summary>
    /// i.e 5HT2A_HUMAN
    /// </summary>
    public string ProteinId { get; set; }

    /// <summary>
    /// i.e orthosteric
    /// </summary>
    public string BindingCavity { get; set; }

    /// <summary>
    /// The numeric index of the structure docked towards
    /// </summary>
    public int StructureIndex { get; set; }

    /// <summary>
    /// i.e jdock 2.3.3a
    /// </summary>
    public string DockingProgram { get; set; }

    /// <summary>
    /// 3.68,0.12,18.98,20,20,20
    /// center_x,center_y,center_z,size_x,size_y,size_z
    /// </summary>
    public float[] SearchingSpace { get; set; }

    /// <summary>
    /// The docking score
    /// </summary>
    public float Score { get; set; }

    /// <summary>
    /// The date and time when the score is computed
    /// </summary>
    public DateTime Created { get; set; }

    public void Init(string receptorPdbqt, string ligandPdbqt, string smiles, string dockingProgram, float[] searchingSpace)
    {
        Init(receptorPdbqt.ComputeHashInt64(), ligandPdbqt.ComputeHashInt64(), smiles, dockingProgram, searchingSpace);
    }

    public void Init(long receptorPdbqtHash, long ligandPdbqtHash, string smiles, string dockingProgram, float[] searchingSpace)
    {
        if (searchingSpace.Length != 6)
            throw new ArgumentException($"Length of argument {nameof(searchingSpace)} should be 6.", nameof(searchingSpace));
        ReceptorPdbqtHash = receptorPdbqtHash;
        LigandPdbqtHash = ligandPdbqtHash;
        Smiles = smiles;
        DockingProgram = dockingProgram;
        SearchingSpace = searchingSpace;
        Id = $"{receptorPdbqtHash}|{smiles}|{string.Join(',', searchingSpace.Select(o => o.ToString("f5")))}".ComputeHashInt64();
        Created = DateTime.UtcNow;
    }

    public void SetScore(float score)
    {
        Score = score;
    }
}
