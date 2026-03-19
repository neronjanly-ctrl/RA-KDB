using CommonTools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DockingDataModels;

[DataContract]
public class Cavity
{
    /// <summary>
    /// The hashed identifier for the protein cavity which is computed with {ProteinId}_{BindingCavity}.
    /// </summary>
    [Key]
    [DataMember]
    public long Id { get; set; }


    /// <summary>
    /// The protein identifier in the format of {ProteinSymbol}_{OrganismSymbol}.
    /// </summary>
    [DataMember]
    public string ProteinId { get; set; }

    /// <summary>
    /// The discriminator for binding site, i.e. the description for the location where a ligand can bind to.
    /// Most crystal structures bind no more than one ligand simultaneously.
    /// For those simultaneously bind multiple ligands on different cavities, two structures are required.
    /// </summary>
    [DataMember]
    public string BindingSite { get; set; }


    /// <summary>
    /// The date and time when the protein cavity was created.
    /// </summary>
    [Required]
    [DataMember]
    public DateTime Created { get; set; }

    /// <summary>
    /// The date and time when the protein cavity was last updated.
    /// </summary>
    [DataMember]
    public DateTime Updated { get; set; }


    #region Snapshot Properties

    /// <summary>
    /// The snapshot number of structures the protein cavity has.
    /// </summary>
    [DataMember]
    public int StructureCount { get; set; }

    /// <summary>
    /// The snapshot of boolean values indicating if the owned structures have a binding ligand.
    /// </summary>
    [DataMember]
    public bool[] StructureHasBindingLigands { get; set; }

    /// <summary>
    /// The snapshot of obtaining methods of the owned structures.
    /// </summary>
    [DataMember]
    public StructureObtainingMethod[] StructureObtainingMethods { get; set; }

    #endregion

    #region Navigation Properties

    /// <summary>
    /// The protein who owns this cavity.
    /// </summary>
    [Required]
    [DataMember]
    public Protein Protein { get; set; }

    /// <summary>
    /// The structures of this protein cavity.
    /// </summary>
    [DataMember]
    public List<Structure> Structures { get; set; }

    /// <summary>
    /// A list of computation results for this protein.
    /// </summary>
    [DataMember]
    public List<Result> Results { get; set; }

    #endregion

    public void Init(string proteinId, string bindingCavity)
    {
        Id = $"{proteinId}_{bindingCavity}".ComputeHashInt64();
        ProteinId = proteinId;
        BindingSite = bindingCavity;
        Created = DateTime.UtcNow;
        Update();
    }

    public void Update()
    {
        Updated = DateTime.UtcNow;
    }
}
