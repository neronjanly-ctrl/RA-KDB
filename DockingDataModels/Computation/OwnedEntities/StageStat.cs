using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.Serialization;

namespace DockingDataModels;

[Owned]
[DataContract]
public class StageStat
{
    /// <summary>
    /// The total number of stages.
    /// </summary>
    [DataMember]
    public int TargetCount { get; set; }

    /// <summary>
    /// The number of precompleted stages.
    /// </summary>
    [DataMember]
    public int PrecompletedCount { get; set; }

    /// <summary>
    /// The number of completed stages. Precompleted stages are not included.
    /// </summary>
    [DataMember]
    public int CompletedCount { get; set; }

    public bool NeedRun => TargetCount - PrecompletedCount > 0;
    public bool IsComplete => TargetCount <= PrecompletedCount + CompletedCount;

    public TimeSpan? TimeRemaining
        => CompletedCount == 0 || TimeUsed == default ? null
        : NeedRun ? TimeSpan.FromSeconds(TimeUsed.TotalSeconds / CompletedCount * (TargetCount - PrecompletedCount - CompletedCount))
        : TimeSpan.Zero;

    public float Progress => IsComplete ? 1 : PrecompletedCount + CompletedCount <= 0 ? 0 : (float)(PrecompletedCount + CompletedCount) / TargetCount;

    /// <summary>
    /// The accrued time used to process the stage.
    /// </summary>
    [DataMember]
    public TimeSpan TimeUsed { get; set; }
}
