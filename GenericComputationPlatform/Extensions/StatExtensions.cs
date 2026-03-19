using DockingDataModels;
using System.Collections.Generic;
using System.Linq;

namespace GenericComputationPlatform.Extensions;

public static class StatExtensions
{
    public static int RunningCount(this IDictionary<RunningStatus, int> stat)
    {
        return stat.Sum(o => o.Value) - stat[RunningStatus.Finished] - stat[RunningStatus.Failed];
    }
}
