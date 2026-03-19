using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace DockingDataModels;

[DataContract(IsReference = true)]
public class Result
{
    /// <summary>
    /// The numeric identifier of the job the result is computed for.
    /// </summary>
    [Key]
    [DataMember]
    public int JobId { get; set; }

    /// <summary>
    /// The numeric identifier of the ligand the result is computed for.
    /// </summary>
    [Key]
    [DataMember]
    public long LigandId { get; set; }

    /// <summary>
    /// The numeric identifier of the protein cavity the result is computed for.
    /// </summary>
    [Key]
    [DataMember]
    public long CavityId { get; set; }


    /// <summary>
    /// The date and time when the result was created.
    /// </summary>
    [Required]
    [DataMember]
    public DateTime Created { get; set; }

    /// <summary>
    /// The date and time when the result was last updated.
    /// </summary>
    [DataMember]
    public DateTime Updated { get; set; }


    /// <summary>
    /// The scoring metric for the docking scores.
    /// </summary>
    [DataMember]
    public DockingScoreMetric DockingScoreMetric { get; set; }

    /// <summary>
    /// The docking scores for all structures related to the protein. A null value means not computed.
    /// </summary>
    [DataMember]
    public float?[] DockingScores { get; set; }

    /// <summary>
    /// The average docking score for all structures of the protein. A null value means not computed.
    /// </summary>
    [DataMember]
    public float? AverageDockingScore { get; set; }

    /// <summary>
    /// The docked scores for all structures related to the protein. A null value means not computed.
    /// </summary>
    [DataMember]
    public string[] DockedModelHashes { get; set; }

    /// <summary>
    /// The predicted result from the trained machine learning model. Unknown if not computed.
    /// </summary>
    [DataMember]
    public Prediction Prediction { get; set; }


    /// <summary>
    /// The most similar active small molecule in known ligands.
    /// </summary>
    [DataMember]
    public SimilarChemblCompound MostSimilarActiveCompound { get; set; }

    /// <summary>
    /// The most similar small molecule in known ligands.
    /// </summary>
    [DataMember]
    public SimilarChemblCompound MostSimilarCompound { get; set; }


    #region Navigation Properties

    /// <summary>
    /// The job associated with the result.
    /// </summary>
    [Required]
    [DataMember]
    public Job Job { get; set; }

    /// <summary>
    /// The ligand associated with the result.
    /// </summary>
    [Required]
    [DataMember]
    public Ligand Ligand { get; set; }

    /// <summary>
    /// The protein cavity associated with the result.
    /// </summary>
    [Required]
    [DataMember]
    public Cavity Cavity { get; set; }

    #endregion

    #region Store Procedures

    public void Init(int jobId, long ligandId, long cavityId, Cavity cavity)
    {
        JobId = jobId;
        LigandId = ligandId;
        CavityId = cavityId;

        DockingScoreMetric = DockingScoreMetric.Unknown;
        DockingScores = new float?[cavity.StructureCount];
        DockedModelHashes = new string[cavity.StructureCount];

        if (cavity.Protein.HasActiveChemblCompounds)
            MostSimilarActiveCompound = new SimilarChemblCompound { Activity = BioActivity.Unknown };
        if (cavity.Protein.HasChemblCompounds)
            MostSimilarCompound = new SimilarChemblCompound { Activity = BioActivity.Unknown };
        if (cavity.Protein.HasTrainedModels)
            Prediction = new Prediction { Activity = BioActivity.Unknown };

        Created = DateTime.UtcNow;
        Update();
    }

    public void Update()
    {
        Updated = DateTime.UtcNow;
    }

    public void SetDockingScore(int modelId, DockingScoreMetric metric, float score, string dockingId)
    {
        DockingScoreMetric = metric;
        DockingScores[modelId] = score;
        DockedModelHashes[modelId] = dockingId;
        AverageDockingScore = DockingScores.Where(o => o != null).Average();
        Update();
    }

    public void UnsetDockingScore(int modelId)
    {
        DockingScores[modelId] = null;
        DockedModelHashes[modelId] = null;
        if (DockingScores.Any(o => o != null))
        {
            AverageDockingScore = DockingScores.Where(o => o != null).Average();
        }
        else
        {
            AverageDockingScore = null;
            DockingScoreMetric = DockingScoreMetric.Unknown;
        }
        Update();
    }

    public void UnsetDockingScores()
    {
        DockingScoreMetric = DockingScoreMetric.Unknown;
        DockingScores = new float?[DockingScores.Length];
        DockedModelHashes = new string[DockingScores.Length];
        AverageDockingScore = null;
        Update();
    }

    public void SetSimilarActiveCompound(SimilarChemblCompound comp)
    {
        MostSimilarActiveCompound = comp;
        Update();
    }

    public void SetSimilarCompound(SimilarChemblCompound comp)
    {
        MostSimilarCompound = comp;
        Update();
    }

    public void ResetSimilarActiveCompound()
    {
        MostSimilarActiveCompound = new SimilarChemblCompound { Activity = BioActivity.Unknown };
        Update();
    }

    public void ResetSimilarCompound()
    {
        MostSimilarCompound = new SimilarChemblCompound { Activity = BioActivity.Unknown };
        Update();
    }

    public void SetPrediction(Prediction pred)
    {
        Prediction = pred;
        Update();
    }

    public void ResetPrediction()
    {
        Prediction = new Prediction { Activity = BioActivity.Unknown };
        Update();
    }

    #endregion
}
