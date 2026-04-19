namespace GenericComputationPlatform.Analytics;

public class JobAnalyticsConfig
{
    public PlatformDefaults PlatformDefaults { get; set; } = new();
    public AnalysisParams AnalysisParams { get; set; } = new();
    public RuleBonusConfig RuleBonus { get; set; } = new();
    public PriorityWeights PriorityWeights { get; set; } = new();
    public PlotParams PlotParams { get; set; } = new();
}

public class PlatformDefaults
{
    public float DockingThreshold { get; set; } = -7.0f;
    public float SimilarityThresholdInteraction { get; set; } = 0.30f;
    public float SimilarityThresholdKnown { get; set; } = 0.60f;
}

public class AnalysisParams
{
    public int TopN { get; set; } = 20;
    public string AggregateMethod { get; set; } = "mean";
    public float HighPriorityStdThreshold { get; set; } = 1.0f;
    public float ModeratePriorityThreshold { get; set; } = 55.0f;
    public float HighPriorityThreshold { get; set; } = 75.0f;
}

public class RuleBonusConfig
{
    public float InteractionBonus { get; set; } = 5.0f;
    public float KnownCompoundBonus { get; set; } = 8.0f;
    public float AllModelsPassBonus { get; set; } = 4.0f;
}

public class PriorityWeights
{
    public float DockingWeight { get; set; } = 40.0f;
    public float SimilarityWeight { get; set; } = 40.0f;
    public float ConsistencyWeight { get; set; } = 20.0f;
}

public class PlotParams
{
    public float ScatterSizeBase { get; set; } = 6.0f;
    public float ScatterSizeScale { get; set; } = 3.0f;
}
