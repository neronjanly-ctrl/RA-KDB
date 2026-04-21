using System.Collections.Generic;

namespace GenericComputationPlatform.Analytics;

public class JobAnalyticsFigures
{
    public HistogramFigure DockingDistribution { get; set; } = new();
    public ModelBoxplotFigure ModelBoxplot { get; set; } = new();
    public HistogramFigure SimilarityDistribution { get; set; } = new();
    public PriorityScatterFigure PriorityScatter { get; set; } = new();
    public TopCandidatesBarFigure TopCandidatesBar { get; set; } = new();
    public CorrelationHeatmapFigure ModelCorrelationHeatmap { get; set; } = new();
}

public class HistogramFigure
{
    public List<string> Labels { get; set; } = new();
    public List<int> Counts { get; set; } = new();
    public string XAxisTitle { get; set; }
    public string YAxisTitle { get; set; }
    public float? Min { get; set; }
    public float? Max { get; set; }
    public List<HistogramThresholdLine> ThresholdLines { get; set; } = new();
}

public class HistogramThresholdLine
{
    public float Value { get; set; }
    public string Label { get; set; }
    public string Color { get; set; }
}

public class ModelBoxplotFigure
{
    public List<ModelBoxplotItem> Models { get; set; } = new();
}

public class ModelBoxplotItem
{
    public string Model { get; set; }
    public float Min { get; set; }
    public float Q1 { get; set; }
    public float Median { get; set; }
    public float Q3 { get; set; }
    public float Max { get; set; }
}

public class PriorityScatterFigure
{
    public List<PriorityScatterPoint> Points { get; set; } = new();
    public List<ScatterThresholdLine> ThresholdLines { get; set; } = new();
}

public class PriorityScatterPoint
{
    public float? X { get; set; }
    public float? Y { get; set; }
    public float Size { get; set; }
    public string Label { get; set; }
    public string Protein { get; set; }
    public string CandidateClass { get; set; }
    public float? Priority { get; set; }
    public float? Docking { get; set; }
    public float? Similarity { get; set; }
    public int? PriorityRank { get; set; }
    public bool PassSimilarityInteraction { get; set; }
    public bool PassSimilarityKnown { get; set; }
    public bool IsTopCandidate { get; set; }
}

public class ScatterThresholdLine
{
    public string Axis { get; set; }
    public float Value { get; set; }
    public string Label { get; set; }
    public string Color { get; set; }
}

public class TopCandidatesBarFigure
{
    public List<string> Labels { get; set; } = new();
    public List<float> PriorityScores { get; set; } = new();
}

public class CorrelationHeatmapFigure
{
    public List<string> Labels { get; set; } = new();
    public List<List<float>> Matrix { get; set; } = new();
}