using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DockingDataModels;

[DataContract]
public partial class Structure
{
    /// <summary>
    /// The protein cavity identifier that the structure references.
    /// </summary>
    [Key]
    [DataMember]
    public long CavityId { get; set; }

    /// <summary>
    /// The 0 based structure index.
    /// </summary>
    [Key]
    [DataMember]
    public int Index { get; set; }


    /// <summary>
    /// The date and time when the structure was created.
    /// </summary>
    [Required]
    [DataMember]
    public DateTime Created { get; set; }

    /// <summary>
    /// The date and time when the structure was last updated.
    /// </summary>
    [DataMember]
    public DateTime Updated { get; set; }


    /// <summary>
    /// A enum value indicating the method for structure obtaining.
    /// </summary>
    [DataMember]
    public StructureObtainingMethod ObtainingMethod { get; set; }

    /// <summary>
    /// A boolean configuration entry indicating if the structure has a binding ligand.
    /// </summary>
    [DataMember]
    public bool HasBindingLigand { get; set; }

    /// <summary>
    /// A subobject that indicates the PDB id of the structure if available.
    /// </summary>
    [DataMember]
    public PdbEntry Pdb { get; set; }

    /// <summary>
    /// The hash value of the pdbqt file for the structure.
    /// </summary>
    [DataMember]
    public long? PdbqtHash { get; set; }

    /// <summary>
    /// The hash value of the fixed pdbqt file for the structure.
    /// </summary>
    [DataMember]
    public long? PdbqtFixedHash { get; set; }

    #region Navigation Properties

    /// <summary>
    /// The protein cavity of which the structure is.
    /// </summary>
    [Required]
    [DataMember]
    public Cavity Cavity { get; set; }

    #endregion

    public void Init(long cavityId, int index)
    {
        CavityId = cavityId;
        Index = index;
        Created = DateTime.UtcNow;
        Update();
    }

    public void Update()
    {
        Updated = DateTime.UtcNow;
    }
}
