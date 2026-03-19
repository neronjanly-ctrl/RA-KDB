using System;

namespace DockingDataModels;

public class RunningJob
{
    public int Id { get; set; }

    public bool IsRunning { get; set; }

    public DateTime Created { get; set; }

    public DateTime Started { get; set; }

    public DateTime Updated { get; set; }

    public int[] AccruedStructures { get; set; }

    public bool IsHuntingAccrued { get; set; }

    public bool IsPredictionAccrued { get; set; }

    public RunningJob()
    {
        IsRunning = false;
        Created = DateTime.UtcNow;
    }

    public void Start()
    {
        IsRunning = true;
        Started = Updated = DateTime.UtcNow;
    }

    public void Update()
    {
        Updated = DateTime.UtcNow;
    }

    public void Stop()
    {
        IsRunning = false;
        Updated = DateTime.UtcNow;
    }
}
