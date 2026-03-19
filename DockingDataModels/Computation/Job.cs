using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace DockingDataModels;

[DataContract(IsReference = true)]
public partial class Job
{
    /// <summary>
    /// The numeric identifier of the job.
    /// </summary>
    [Key]
    [DataMember]
    public int Id { get; set; }


    /// <summary>
    /// The mnemonic name of the job.
    /// </summary>
    [Required]
    [DataMember]
    public string Name { get; set; }

    /// <summary>
    /// A boolean value indicating if the job is private to the creator only.
    /// </summary>
    [DataMember]
    public bool IsPrivate { get; set; }

    /// <summary>
    /// The email address of the user who created the job.
    /// </summary>
    [DataMember]
    public string UserId { get; set; }

    /// <summary>
    /// The IPv4 address of the user.
    /// </summary>
    [DataMember]
    public string IpAddress { get; set; }


    /// <summary>
    /// The date and time when the job was created.
    /// </summary>
    [Required]
    [DataMember]
    public DateTime Created { get; set; }

    /// <summary>
    /// The date and time when the job was started.
    /// </summary>
    [DataMember]
    public DateTime Started { get; set; }

    /// <summary>
    /// The date and time when the job was last updated.
    /// </summary>
    [DataMember]
    public DateTime Updated { get; set; }


    /// <summary>
    /// The status of the job.
    /// </summary>
    [DataMember]
    public RunningStatus Status { get; set; }

    #region Snapshot Properties

    /// <summary>
    /// The snapshot number of domains used by this job.
    /// </summary>
    [DataMember]
    public int DomainCount { get; set; }

    /// <summary>
    /// The snapshot number of proteins used by this job.
    /// </summary>
    [DataMember]
    public int ProteinCount { get; set; }

    /// <summary>
    /// The snapshot number of ligands used by this job.
    /// </summary>
    [DataMember]
    public int LigandCount { get; set; }

    /// <summary>
    /// The snapshot number of results used by this job.
    /// </summary>
    [DataMember]
    public int ResultCount { get; set; }

    #endregion

    #region Summarizing Properties

    // Stage 0: Compute Docking Scores (multiple substages for multiple structures)
    // Stage 1: Compute Similarity Score (find the most similar active ChEMBL compound)
    // Stage 2: Compute the Machine Learning prediction

    // A job includes multiple protein-ligand pairs.
    // Each pair corresponds to a sub-job (and therefore a result) which involves stage 0, 1 and 2.
    // So a job may have multiple sub-stages in each stage.
    // Below the statistical information of each stage and all stages is the job-wide statistics.

    /// <summary>
    /// The statistical information of stage 0, i.e. the docking stage.
    /// </summary>
    [DataMember]
    public StageStat Stage0 { get; set; }

    /// <summary>
    /// The statistical information of stage 1, i.e. the hunting stage.
    /// </summary>
    [DataMember]
    public StageStat Stage1 { get; set; }

    /// <summary>
    /// The statistical information of stage 2, i.e. the prediction stage.
    /// </summary>
    [DataMember]
    public StageStat Stage2 { get; set; }

    /// <summary>
    /// The statistical information of all stages.
    /// </summary>
    [DataMember]
    public StageStat AllStages { get; set; }

    public TimeSpan? TimeRemaining
    {
        get
        {
            if (AllStages.IsComplete)
                return TimeSpan.Zero;

            // No stages completed in this run
            if (AllStages.CompletedCount == 0)
                return null;

            // No accumulated time in this run
            if (AllStages.TimeUsed == default)
                return null;

            // Some stages are yet to be computed so we cannot estimate remaining time for now.
            return (Stage0.NeedRun ? Stage0.TimeRemaining : TimeSpan.Zero)
                + (Stage1.NeedRun ? Stage1.TimeRemaining : TimeSpan.Zero)
                + (Stage2.NeedRun ? Stage2.TimeRemaining : TimeSpan.Zero);
        }
    }

    public string TimeRemainingString
    {
        get
        {
            TimeSpan? time = TimeRemaining;
            if (time == null)
                return null;

            TimeSpan value = time.Value;

            string s1 = null, s2 = null, s3 = null, s4 = null;
            if (value.Days > 0)
                s1 = $"{value.Days} day{(value.Days > 1 ? "s" : "")}";

            if (value.Hours > 0)
                s2 = $"{value.Hours} hour{(value.Hours > 1 ? "s" : "")}";

            if (s1 != null)
                return s2 == null ? s1 : $"{s1} and {s2}";

            if (value.Minutes > 0)
                s3 = $"{value.Minutes} minute{(value.Minutes > 1 ? "s" : "")}";

            if (s2 != null)
                return s3 == null ? s2 : $"{s2} and {s3}";

            if (value.Seconds > 0)
                s4 = $"{value.Seconds} second{(value.Seconds > 1 ? "s" : "")}";

            if (s3 != null)
                return s4 == null ? s3 : $"{s3} and {s4}";

            return s4;
        }
    }

    public float Progress => AllStages.Progress;
    public bool IsComplete => AllStages.IsComplete;

    #endregion

    #region Navigation Properties

    /// <summary>
    /// The user who created the job. Null if anonymous.
    /// </summary>
    [DataMember]
    public User User { get; set; }

    /// <summary>
    /// A list of ligands used by this job.
    /// </summary>
    [DataMember]
    public List<JobLigand> JobLigands { get; set; }

    /// <summary>
    /// A list of domains used by this job.
    /// </summary>
    [DataMember]
    public List<JobDomain> JobDomains { get; set; }

    /// <summary>
    /// A list of results for this job.
    /// </summary>
    [DataMember]
    public List<Result> Results { get; set; }

    #endregion

    #region Store Procedures

    public Ligand[] GetLigands()
    {
        return JobLigands.Select(o => o.Ligand).ToArray();
    }

    public Domain[] GetDomains()
    {
        return JobDomains.Select(o => o.Domain).ToArray();
    }

    public void ResetProgress(int[] stages = null)
    {
        Started = default;
        Status = RunningStatus.Created;

        if (stages != null)
        {
            Debug.Assert(stages.Length == 3);
            Stage0.TargetCount = stages[0] * LigandCount;
            Stage1.TargetCount = stages[1] * LigandCount;
            Stage2.TargetCount = stages[2] * LigandCount;
            AllStages.TargetCount = stages.Sum() * LigandCount;
        }

        Stage0.TimeUsed = default;
        Stage1.TimeUsed = default;
        Stage2.TimeUsed = default;
        AllStages.TimeUsed = default;

        Stage0.PrecompletedCount = 0;
        Stage1.PrecompletedCount = 0;
        Stage2.PrecompletedCount = 0;
        AllStages.PrecompletedCount = 0;

        Stage0.CompletedCount = 0;
        Stage1.CompletedCount = 0;
        Stage2.CompletedCount = 0;
        AllStages.CompletedCount = 0;

        Update();
    }

    public void PrecompleteStage(int stage, int num = 1)
    {
        switch (stage)
        {
            case 0:
                Stage0.PrecompletedCount += num;
                break;
            case 1:
                Stage1.PrecompletedCount += num;
                break;
            case 2:
                Stage2.PrecompletedCount += num;
                break;
        }
        AllStages.PrecompletedCount += num;
        Update();
    }

    public void CompleteStage(int stage, TimeSpan timeUsed)
    {
        switch (stage)
        {
            case 0:
                Stage0.CompletedCount++;
                Stage0.TimeUsed += timeUsed;
                break;
            case 1:
                Stage1.CompletedCount++;
                Stage1.TimeUsed += timeUsed;
                break;
            case 2:
                Stage2.CompletedCount++;
                Stage2.TimeUsed += timeUsed;
                break;
        }
        AllStages.CompletedCount++;
        AllStages.TimeUsed += timeUsed;
        Update();
    }

    public void Create()
    {
        Status = RunningStatus.Created;
        Created = DateTime.UtcNow;
        Update();
    }

    public void Init()
    {
        Status = RunningStatus.Initializing;
        Update();
    }

    public void Update()
    {
        Updated = DateTime.UtcNow;
    }

    public void Run()
    {
        Status = RunningStatus.Running;
        Started = DateTime.UtcNow;
        Update();
    }

    public void Finish()
    {
        Status = RunningStatus.Finished;
        Update();
    }

    #endregion
}
