using System.Runtime.Serialization;

namespace DockingDataModels;

/// <summary>
/// The integrity information of a structure
/// [Manually Collated]
///   structurePdb, ligandPdb,
///   #structureMol2, #pocketMol2, #renderingPng
/// [Automatically Generated]
///   propertiesTxt, fixedStructurePdb, *structurePdbqt, %fixedStructurePdbqt,
///   ligandPdbqt, %ligandPka, *pocketConf
/// *required for computation
/// #required for visualization
/// %preferred if exists
/// </summary>
[DataContract]
public sealed class StructureIntegrity : IIntegrity
{
    [DataMember]
    [IntegrityMeta("AminoAcids.pdb", true)]
    public bool HasStructurePdb { get; set; }

    [DataMember]
    [IntegrityMeta("AminoAcids.mol2", true, RequiredForVisualization = true)]
    public bool HasStructureMol2 { get; set; }

    [DataMember]
    [IntegrityMeta("AminoAcids.pdbqt", AlternativeFileName = "AminoAcids_fixed.pdbqt", RequiredForComputation = true)]
    public bool HasStructurePdbqt { get; set; }

    [DataMember]
    [IntegrityMeta("AminoAcids_fixed.pdb")]
    public bool HasFixedStructurePdb { get; set; }


    [DataMember]
    [IntegrityMeta("Ligand.pdb", true)]
    public bool HasLigandPdb { get; set; }

    [DataMember]
    [IntegrityMeta("Ligand.pdbqt")]
    public bool HasLigandPdbqt { get; set; }

    [DataMember]
    [IntegrityMeta("Ligand.pka")]
    public bool HasLigandPka { get; set; }


    [DataMember]
    [IntegrityMeta("Pocket.mol2", true, RequiredForVisualization = true)]
    public bool HasPocketMol2 { get; set; }

    [DataMember]
    [IntegrityMeta("Pocket.conf", RequiredForComputation = true)]
    public bool HasPocketConf { get; set; }


    [DataMember]
    [IntegrityMeta("Rendering.png", true, RequiredForVisualization = true)]
    public bool HasRenderingPng { get; set; }

    [DataMember]
    [IntegrityMeta("Properties.txt")]
    public bool HasPropertiesTxt { get; set; }
}
