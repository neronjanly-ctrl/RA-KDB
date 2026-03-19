using ChemicalFunctions;
using DockingDataModels;
using System;

namespace GenericComputationPlatform.Extensions;

public static class DockingResultExtensions
{
    public static string GetFormattedVinaScore(this Result result, int? modelId = null)
    {
        if (result.DockingScores.Length == 0 || modelId != null && modelId.Value >= result.DockingScores.Length)
            return "N/A";
        float? score = modelId == null ? result.AverageDockingScore : result.DockingScores[modelId.Value];
        if (score == null)
            return "?";
        if (result.DockingScoreMetric == DockingScoreMetric.Sybyl)
            return score.Value.ToVinaScore().ToString("f2");
        else if (result.DockingScoreMetric == DockingScoreMetric.Vina)
            return score.Value.ToString("f2");
        throw new InvalidOperationException($"Unknown score metric {result.DockingScoreMetric}");
    }

    public static string GetFormattedActiveSimilarity(this Result result)
    {
        if (result.MostSimilarActiveCompound == null)
            return "N/A";
        if (result.MostSimilarActiveCompound.Activity == BioActivity.Unknown)
            return "?";
        return result.MostSimilarActiveCompound.Similarity.ToString("p2");
    }

    public static string GetFormattedSimilarity(this Result result)
    {
        if (result.MostSimilarCompound == null)
            return "N/A";
        if (result.MostSimilarCompound.Activity == BioActivity.Unknown)
            return "?";
        return result.MostSimilarCompound.Similarity.ToString("p2");
    }

    public static string GetFormattedActivity(this Result result)
    {
        if (result.Prediction == null)
            return "N/A";
        if (result.Prediction.Activity == BioActivity.Unknown)
            return "?";
        return result.Prediction.Activity.ToString();
    }

    public static string GetFormattedConfidenceLevel(this Result result)
    {
        if (result.Prediction == null)
            return "N/A";
        if (result.Prediction.Activity == BioActivity.Unknown)
            return "?";
        if (result.Prediction.ConfidenceLevel == null)
            return null;
        return result.Prediction.ConfidenceLevel.Value.ToString("p2");
    }
}
