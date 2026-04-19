namespace GenericComputationPlatform.Analytics;

public class JobAnalyticsPolicy
{
    public MissingValuePolicy MissingValue { get; set; } = new();
    public DockingPolicy Docking { get; set; } = new();
    public SimilarityPolicy Similarity { get; set; } = new();
    public PredictionPolicy Prediction { get; set; } = new();
    public RankingPolicy Ranking { get; set; } = new();
    public DisplayPolicy Display { get; set; } = new();
}

public class MissingValuePolicy
{
    public bool TreatNaAsMissing { get; set; } = true;
    public bool TreatQuestionMarkAsMissing { get; set; } = true;
    public bool TreatNullAsMissing { get; set; } = true;
    public bool KeepForDisplay { get; set; } = true;
    public bool ExcludeFromNumericStats { get; set; } = true;
    public bool IncludeInQualityReport { get; set; } = true;
}

public class DockingPolicy
{
    public bool AggregateUsingValidValuesOnly { get; set; } = true;
    public bool ImputeMissingAsZero { get; set; } = false;
    public bool InterpolateMissing { get; set; } = false;
    public bool GuessMissing { get; set; } = false;
    public int MinValidScoresToAggregate { get; set; } = 1;
    public bool ExcludeWhenAllMissing { get; set; } = true;
}

public class SimilarityPolicy
{
    public bool ExcludeFromScoringWhenMissing { get; set; } = true;
    public bool ExcludeFromRankingWhenMissing { get; set; } = true;
    public bool KeepForDisplayAndFullExport { get; set; } = true;
}

public class PredictionPolicy
{
    public bool UsePredictionInAnalytics { get; set; } = false;
    public bool UsePredictionInRanking { get; set; } = false;
    public bool UsePredictionInFiltering { get; set; } = false;
    public bool DisplayPredictionIfAvailable { get; set; } = true;
}

public class RankingPolicy
{
    public bool IncludeOnlyAnalyzableRows { get; set; } = true;
}

public class DisplayPolicy
{
    public bool KeepExcludedRowsInFullExport { get; set; } = true;
    public bool KeepExcludedRowsInDetails { get; set; } = true;
}
