using System.Collections.Generic;

namespace GenericComputationPlatform.Analytics;

public class JobAnalyticsRow
{
    public string LigandName { get; set; }
    public string LigandSmiles { get; set; }
    public string ProteinSymbol { get; set; }
    public string GeneSymbol { get; set; }
    public string OrganismSymbol { get; set; }
    public string ApprovedName { get; set; }
    public string Organism { get; set; }
    public string Synonyms { get; set; }
    public List<float?> DockingScores { get; set; } = new();
    public float? SimilarityScore { get; set; }
    public string BestMatchId { get; set; }
    public string BestMatchUrl { get; set; }
    public string BestMatchSmiles { get; set; }
    public string CompareUrl { get; set; }
    public string SourceUrl { get; set; }
    public string PredictionResult { get; set; }
    public string PredictionConfidence { get; set; }

    public bool IsAnalyzable { get; set; }
    public List<string> ExclusionReasons { get; set; } = new();

    public float? DockingMean { get; set; }
    public float? DockingMedian { get; set; }
    public float? DockingMin { get; set; }
    public float? DockingMax { get; set; }
    public float? DockingStd { get; set; }
    public float? DockingRange { get; set; }
    public int ModelsPassingDockingCount { get; set; }
    public bool AllModelsPassDocking { get; set; }
    public bool AnyModelPassDocking { get; set; }
    public bool PassDockingEffective { get; set; }
    public bool PassSimilarityInteraction { get; set; }
    public bool PassSimilarityKnown { get; set; }
    public float? DockingEffectiveScore { get; set; }
    public float? SimilarityScoreNorm { get; set; }
    public float? ConsistencyScore { get; set; }
    public float RuleBonusRaw { get; set; }
    public float RuleBonusNorm { get; set; }
    public float? PriorityScore { get; set; }
    public int? PriorityRank { get; set; }
    public string CandidateClass { get; set; }
}
