using CommonTools;
using DockingApiClient;
using DockingDataModels;
using GenericComputationPlatform.Analytics;
using GenericComputationPlatform.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GenericComputationPlatform.Services;

public class JobAnalyticsService : IJobAnalyticsService
{
    private readonly JobClient _jobClient;
    private readonly ResultClient _resultClient;
    private readonly AppSettings _appSettings;

    public JobAnalyticsService(JobClient jobClient, ResultClient resultClient, Microsoft.Extensions.Options.IOptions<AppSettings> appSettings)
    {
        _jobClient = jobClient;
        _resultClient = resultClient;
        _appSettings = appSettings.Value;
    }

    public async Task<JobAnalyticsSummary> BuildSummaryAsync(string domainId, int jobId, JobAnalyticsConfig config, CancellationToken ct = default)
    {
        Job job = await _jobClient.GetOneAsync(jobId);
        IReadOnlyList<Result> results = await _resultClient.List2Async(jobId);

        JobAnalyticsPolicy policy = new();
        JobAnalyticsConfig effectiveConfig = ApplyUserParams(config ?? new JobAnalyticsConfig());
        JobAnalyticsConfigMeta meta = BuildRuntimeConfigMeta();
        JobAnalyticsValidationResult configValidation = ValidateConfig(effectiveConfig, meta);

        List<JobAnalyticsRow> rows = MapResultsToAnalyticsRows(domainId, job, results, policy);
        ApplyPolicy(rows, policy);
        ComputeDerivedFields(rows, effectiveConfig, policy);

        JobAnalyticsSummary summary = BuildSummary(domainId, job, rows, effectiveConfig);
        JobAnalyticsValidationResult dataValidation = ValidateDataQuality(rows, policy);
        summary.Validation = new JobAnalyticsValidationResult
        {
            IsValid = configValidation.IsValid && dataValidation.IsValid,
            Errors = configValidation.Errors.Concat(dataValidation.Errors).ToList(),
            Warnings = configValidation.Warnings.Concat(dataValidation.Warnings).ToList()
        };

        return summary;
    }

    public JobAnalyticsConfigMeta BuildRuntimeConfigMeta()
    {
        JobAnalyticsConfig defaults = new();
        return new JobAnalyticsConfigMeta
        {
            Fields = new List<JobAnalyticsConfigFieldMeta>
            {
                new() { Label = "Docking threshold", Type = "number", Default = defaults.PlatformDefaults.DockingThreshold, Editable = true, Min = -50, Max = 50, Step = 0.1, Group = "platform", UiComponent = "number", Description = "Effective docking threshold", Path = "platformDefaults.dockingThreshold" },
                new() { Label = "Similarity interaction threshold", Type = "number", Default = defaults.PlatformDefaults.SimilarityThresholdInteraction, Editable = true, Min = 0, Max = 1, Step = 0.01, Group = "platform", UiComponent = "slider", Description = "Minimum for interaction", Path = "platformDefaults.similarityThresholdInteraction" },
                new() { Label = "Similarity known threshold", Type = "number", Default = defaults.PlatformDefaults.SimilarityThresholdKnown, Editable = true, Min = 0, Max = 1, Step = 0.01, Group = "platform", UiComponent = "slider", Description = "Minimum for known compounds", Path = "platformDefaults.similarityThresholdKnown" },
                new() { Label = "Top N", Type = "integer", Default = defaults.AnalysisParams.TopN, Editable = true, Min = 1, Max = 1000, Step = 1, Group = "analysis", UiComponent = "number", Description = "Rows in top candidate output", Path = "analysisParams.topN" },
                new() { Label = "Aggregate method", Type = "string", Default = defaults.AnalysisParams.AggregateMethod, Editable = true, Group = "analysis", UiComponent = "select", Description = "Docking aggregate method", Path = "analysisParams.aggregateMethod" },
                new() { Label = "Scatter size base", Type = "number", Default = defaults.PlotParams.ScatterSizeBase, Editable = true, Min = 0.1, Max = 100, Step = 0.1, Group = "plot", UiComponent = "number", Description = "Base size for scatter", Path = "plotParams.scatterSizeBase", PlatformLockedNote = "Analytics params do not affect Spider Plot logic." },
                new() { Label = "Scatter size scale", Type = "number", Default = defaults.PlotParams.ScatterSizeScale, Editable = true, Min = 0, Max = 100, Step = 0.1, Group = "plot", UiComponent = "number", Description = "Scale for scatter", Path = "plotParams.scatterSizeScale", PlatformLockedNote = "Analytics params do not affect Spider Plot logic." }
            }
        };
    }

    public JobAnalyticsConfig ApplyUserParams(JobAnalyticsConfig config)
    {
        config ??= new JobAnalyticsConfig();
        config.AnalysisParams.AggregateMethod = (config.AnalysisParams.AggregateMethod ?? "mean").Trim().ToLowerInvariant();
        if (config.AnalysisParams.AggregateMethod != "mean" && config.AnalysisParams.AggregateMethod != "median" && config.AnalysisParams.AggregateMethod != "min" && config.AnalysisParams.AggregateMethod != "max")
            config.AnalysisParams.AggregateMethod = "mean";
        return config;
    }

    public JobAnalyticsValidationResult ValidateConfig(JobAnalyticsConfig config, JobAnalyticsConfigMeta meta)
    {
        JobAnalyticsValidationResult validation = new();

        if (config.PlatformDefaults.SimilarityThresholdKnown < config.PlatformDefaults.SimilarityThresholdInteraction)
            validation.Errors.Add("Similarity known threshold must be >= interaction threshold.");

        if (config.AnalysisParams.TopN < 1)
            validation.Errors.Add("top_n must be >= 1.");

        float weightSum = config.PriorityWeights.DockingWeight + config.PriorityWeights.SimilarityWeight + config.PriorityWeights.ConsistencyWeight;
        if (Math.Abs(weightSum) < 0.0001f)
            validation.Errors.Add("weight sum must not be 0.");
        else if (Math.Abs(weightSum - 100.0f) > 0.0001f)
            validation.Warnings.Add("weight sum is not 100; values will be normalized.");

        if (config.RuleBonus.InteractionBonus < 0 || config.RuleBonus.KnownCompoundBonus < 0 || config.RuleBonus.AllModelsPassBonus < 0)
            validation.Errors.Add("rule bonus values must be >= 0.");

        if (config.PlotParams.ScatterSizeBase <= 0)
            validation.Errors.Add("scatter_size_base must be > 0.");

        if (config.PlotParams.ScatterSizeScale < 0)
            validation.Errors.Add("scatter_size_scale must be >= 0.");

        validation.IsValid = validation.Errors.Count == 0;
        return validation;
    }

    public JobAnalyticsValidationResult ValidateDataQuality(IReadOnlyCollection<JobAnalyticsRow> rows, JobAnalyticsPolicy policy)
    {
        int missingDocking = rows.Count(o => o.ExclusionReasons.Contains("Missing docking score"));
        int missingSimilarity = rows.Count(o => o.ExclusionReasons.Contains("Missing similarity score"));
        int analyzable = rows.Count(o => o.IsAnalyzable);

        JobAnalyticsValidationResult validation = new
        {
            IsValid = analyzable > 0,
            Warnings =
            {
                $"Rows with missing docking score: {missingDocking}",
                $"Rows with missing similarity score: {missingSimilarity}",
                $"Analyzable rows: {analyzable}"
            }
        };

        if (analyzable == 0)
            validation.Errors.Add("No analyzable rows found.");

        return validation;
    }

    public object BuildFrontendPayload(JobAnalyticsSummary summary, JobAnalyticsConfigMeta meta)
    {
        return new
        {
            summary.TotalRows,
            summary.AnalyzableRows,
            summary.ExcludedByMissingDocking,
            summary.ExcludedByMissingSimilarity,
            summary.MeanDocking,
            summary.MedianDocking,
            summary.HighPriorityCount,
            summary.TopCandidates,
            summary.GroupedByProtein,
            summary.GroupedByGene,
            summary.GroupedByLigand,
            summary.Validation,
            summary.AppliedConfig,
            Meta = meta,
            Notice = "Analytics configuration does not affect Spider Plot thresholds."
        };
    }

    public string BuildSummaryCsv(JobAnalyticsSummary summary)
    {
        List<string[]> rows = new()
        {
            new [] { "Metric", "Value" },
            new [] { "Total rows", summary.TotalRows.ToString(CultureInfo.InvariantCulture) },
            new [] { "Analyzable rows", summary.AnalyzableRows.ToString(CultureInfo.InvariantCulture) },
            new [] { "Excluded by missing docking", summary.ExcludedByMissingDocking.ToString(CultureInfo.InvariantCulture) },
            new [] { "Excluded by missing similarity", summary.ExcludedByMissingSimilarity.ToString(CultureInfo.InvariantCulture) },
            new [] { "Mean docking", summary.MeanDocking?.ToString("F3", CultureInfo.InvariantCulture) ?? "N/A" },
            new [] { "Median docking", summary.MedianDocking?.ToString("F3", CultureInfo.InvariantCulture) ?? "N/A" },
            new [] { "High priority count", summary.HighPriorityCount.ToString(CultureInfo.InvariantCulture) },
            new [] { "" , "" },
            new [] { "Top Candidates" , "" },
            new [] { "Ligand", "Protein", "Gene", "Docking", "Similarity", "Priority Score", "Candidate Class" }
        };

        rows.AddRange(summary.TopCandidates.Select(o => new[]
        {
            o.LigandName,
            o.ProteinSymbol,
            o.GeneSymbol,
            o.DockingEffectiveScore?.ToString("F3", CultureInfo.InvariantCulture) ?? "N/A",
            o.SimilarityScore?.ToString("F3", CultureInfo.InvariantCulture) ?? "N/A",
            o.PriorityScore?.ToString("F2", CultureInfo.InvariantCulture) ?? "N/A",
            o.CandidateClass ?? "N/A"
        }));

        return string.Join(Environment.NewLine, CsvHelper.FormatCsvRows(rows));
    }

    public string BuildFullAnalysisCsv(JobAnalyticsSummary summary)
    {
        int maxModelCount = summary.Rows.Count == 0 ? 0 : summary.Rows.Max(o => o.DockingScores.Count);
        List<string> headers = new()
        {
            "Ligand",
            "SMILES",
            "Protein Symbol",
            "Gene Symbol",
            "Similarity Score",
            "Prediction Result",
            "Prediction Confidence",
            "IsAnalyzable",
            "ExclusionReasons",
            "DockingMean",
            "DockingMedian",
            "DockingMin",
            "DockingMax",
            "DockingStd",
            "DockingRange",
            "ModelsPassingDockingCount",
            "AllModelsPassDocking",
            "AnyModelPassDocking",
            "PassDockingEffective",
            "PassSimilarityInteraction",
            "PassSimilarityKnown",
            "DockingEffectiveScore",
            "SimilarityScoreNorm",
            "ConsistencyScore",
            "RuleBonusRaw",
            "RuleBonusNorm",
            "PriorityScore",
            "PriorityRank",
            "CandidateClass",
            "Compare Url",
            "Source Url"
        };

        headers.AddRange(Enumerable.Range(1, maxModelCount).Select(o => $"Docking Score Model {o}"));

        IEnumerable<IEnumerable<string>> content = summary.Rows.Select(o =>
        {
            List<string> row = new()
            {
                o.LigandName,
                o.LigandSmiles,
                o.ProteinSymbol,
                o.GeneSymbol,
                o.SimilarityScore?.ToString("F3", CultureInfo.InvariantCulture) ?? "N/A",
                o.PredictionResult,
                o.PredictionConfidence,
                o.IsAnalyzable ? "true" : "false",
                string.Join(" | ", o.ExclusionReasons),
                o.DockingMean?.ToString("F3", CultureInfo.InvariantCulture) ?? "N/A",
                o.DockingMedian?.ToString("F3", CultureInfo.InvariantCulture) ?? "N/A",
                o.DockingMin?.ToString("F3", CultureInfo.InvariantCulture) ?? "N/A",
                o.DockingMax?.ToString("F3", CultureInfo.InvariantCulture) ?? "N/A",
                o.DockingStd?.ToString("F3", CultureInfo.InvariantCulture) ?? "N/A",
                o.DockingRange?.ToString("F3", CultureInfo.InvariantCulture) ?? "N/A",
                o.ModelsPassingDockingCount.ToString(CultureInfo.InvariantCulture),
                o.AllModelsPassDocking ? "true" : "false",
                o.AnyModelPassDocking ? "true" : "false",
                o.PassDockingEffective ? "true" : "false",
                o.PassSimilarityInteraction ? "true" : "false",
                o.PassSimilarityKnown ? "true" : "false",
                o.DockingEffectiveScore?.ToString("F3", CultureInfo.InvariantCulture) ?? "N/A",
                o.SimilarityScoreNorm?.ToString("F3", CultureInfo.InvariantCulture) ?? "N/A",
                o.ConsistencyScore?.ToString("F3", CultureInfo.InvariantCulture) ?? "N/A",
                o.RuleBonusRaw.ToString("F3", CultureInfo.InvariantCulture),
                o.RuleBonusNorm.ToString("F3", CultureInfo.InvariantCulture),
                o.PriorityScore?.ToString("F3", CultureInfo.InvariantCulture) ?? "N/A",
                o.PriorityRank?.ToString(CultureInfo.InvariantCulture) ?? "N/A",
                o.CandidateClass,
                o.CompareUrl,
                o.SourceUrl,
            };

            row.AddRange(Enumerable.Range(0, maxModelCount).Select(i => i < o.DockingScores.Count && o.DockingScores[i].HasValue
                ? o.DockingScores[i]!.Value.ToString("F3", CultureInfo.InvariantCulture)
                : "N/A"));

            return row;
        });

        return string.Join(Environment.NewLine, CsvHelper.FormatCsvRows(content, headers));
    }

    private List<JobAnalyticsRow> MapResultsToAnalyticsRows(string domainId, Job job, IReadOnlyList<Result> results, JobAnalyticsPolicy policy)
    {
        string hosting = _appSettings.ExternalUrls.Hosting.TrimEnd('/');
        return results.Select(o =>
        {
            SimilarChemblCompound compound = o.MostSimilarCompound;
            bool hasValidSimilarity = compound != null && compound.Activity != BioActivity.Unknown;

            return new JobAnalyticsRow
            {
                LigandName = job.JobLigands.First(p => p.LigandId == o.LigandId).LigandName,
                LigandSmiles = o.Ligand.Smiles,
                ProteinSymbol = o.Cavity.Protein.ProteinSymbol,
                GeneSymbol = o.Cavity.Protein.GeneSymbol,
                OrganismSymbol = o.Cavity.Protein.OrganismSymbol,
                ApprovedName = o.Cavity.Protein.ProteinName,
                Organism = o.Cavity.Protein.Organism,
                Synonyms = string.Join(',', o.Cavity.Protein.Properties.Synonyms),
                DockingScores = o.DockingScores?.ToList() ?? new List<float?>(),
                SimilarityScore = hasValidSimilarity ? compound.Similarity : null,
                BestMatchId = hasValidSimilarity ? compound.Id : null,
                BestMatchUrl = hasValidSimilarity ? compound.Url : null,
                BestMatchSmiles = hasValidSimilarity ? compound.Smiles : null,
                CompareUrl = hosting + $"/{domainId}/job/w{job.Id}/compare/{o.CavityId.StringifyId()}/{o.LigandId.StringifyId()}",
                SourceUrl = hosting + $"/{domainId}/job/w{job.Id}/protein/{o.CavityId.StringifyId()}",
                PredictionResult = o.GetFormattedActivity(),
                PredictionConfidence = o.GetFormattedConfidenceLevel(),
            };
        }).ToList();
    }

    private static void ApplyPolicy(List<JobAnalyticsRow> rows, JobAnalyticsPolicy policy)
    {
        foreach (JobAnalyticsRow row in rows)
        {
            bool hasValidDocking = row.DockingScores.Any(o => o.HasValue);
            bool hasValidSimilarity = row.SimilarityScore.HasValue;

            row.IsAnalyzable = true;
            if (!hasValidDocking)
            {
                row.IsAnalyzable = false;
                row.ExclusionReasons.Add("Missing docking score");
            }

            if (!hasValidSimilarity)
            {
                row.IsAnalyzable = false;
                row.ExclusionReasons.Add("Missing similarity score");
            }
        }
    }

    private static void ComputeDerivedFields(List<JobAnalyticsRow> rows, JobAnalyticsConfig config, JobAnalyticsPolicy policy)
    {
        float weightSum = config.PriorityWeights.DockingWeight + config.PriorityWeights.SimilarityWeight + config.PriorityWeights.ConsistencyWeight;
        float dockingWeight = Math.Abs(weightSum) < 0.0001f ? 0f : config.PriorityWeights.DockingWeight / weightSum;
        float similarityWeight = Math.Abs(weightSum) < 0.0001f ? 0f : config.PriorityWeights.SimilarityWeight / weightSum;
        float consistencyWeight = Math.Abs(weightSum) < 0.0001f ? 0f : config.PriorityWeights.ConsistencyWeight / weightSum;
        float maxBonus = config.RuleBonus.InteractionBonus + config.RuleBonus.KnownCompoundBonus + config.RuleBonus.AllModelsPassBonus;

        foreach (JobAnalyticsRow row in rows)
        {
            List<float> docking = row.DockingScores.Where(o => o.HasValue).Select(o => o.Value).ToList();
            if (docking.Count > 0)
            {
                row.DockingMean = docking.Average();
                row.DockingMedian = docking.OrderBy(o => o).ElementAt(docking.Count / 2);
                row.DockingMin = docking.Min();
                row.DockingMax = docking.Max();
                row.DockingRange = row.DockingMax - row.DockingMin;

                float mean = row.DockingMean.Value;
                row.DockingStd = (float)Math.Sqrt(docking.Average(v => Math.Pow(v - mean, 2)));
                row.ModelsPassingDockingCount = docking.Count(o => o <= config.PlatformDefaults.DockingThreshold);
                row.AllModelsPassDocking = docking.Count > 0 && row.ModelsPassingDockingCount == docking.Count;
                row.AnyModelPassDocking = row.ModelsPassingDockingCount > 0;
            }

            row.PassSimilarityInteraction = row.SimilarityScore >= config.PlatformDefaults.SimilarityThresholdInteraction;
            row.PassSimilarityKnown = row.SimilarityScore >= config.PlatformDefaults.SimilarityThresholdKnown;

            float? aggregateDocking = config.AnalysisParams.AggregateMethod switch
            {
                "median" => row.DockingMedian,
                "min" => row.DockingMin,
                "max" => row.DockingMax,
                _ => row.DockingMean,
            };

            row.DockingEffectiveScore = aggregateDocking;
            row.PassDockingEffective = row.DockingEffectiveScore.HasValue && row.DockingEffectiveScore <= config.PlatformDefaults.DockingThreshold;

            if (!row.IsAnalyzable)
                continue;

            row.SimilarityScoreNorm = Math.Clamp(row.SimilarityScore ?? 0, 0f, 1f);
            row.ConsistencyScore = row.DockingStd.HasValue ? Math.Clamp(1f - (row.DockingStd.Value / Math.Max(config.AnalysisParams.HighPriorityStdThreshold, 0.0001f)), 0f, 1f) : 0f;

            float dockingNorm = row.DockingEffectiveScore.HasValue
                ? Math.Clamp((config.PlatformDefaults.DockingThreshold - row.DockingEffectiveScore.Value + 5f) / 10f, 0f, 1f)
                : 0f;

            row.RuleBonusRaw = 0f;
            if (row.PassSimilarityInteraction)
                row.RuleBonusRaw += config.RuleBonus.InteractionBonus;
            if (row.PassSimilarityKnown)
                row.RuleBonusRaw += config.RuleBonus.KnownCompoundBonus;
            if (row.AllModelsPassDocking)
                row.RuleBonusRaw += config.RuleBonus.AllModelsPassBonus;

            row.RuleBonusNorm = maxBonus <= 0 ? 0 : row.RuleBonusRaw / maxBonus;
            row.PriorityScore = 100f * (
                dockingNorm * dockingWeight
                + (row.SimilarityScoreNorm ?? 0) * similarityWeight
                + (row.ConsistencyScore ?? 0) * consistencyWeight
            ) + 10f * row.RuleBonusNorm;

            row.CandidateClass = row.PriorityScore >= config.AnalysisParams.HighPriorityThreshold
                ? "High"
                : row.PriorityScore >= config.AnalysisParams.ModeratePriorityThreshold
                    ? "Moderate"
                    : "Low";
        }

        int rank = 1;
        foreach (JobAnalyticsRow row in rows.Where(o => o.IsAnalyzable).OrderByDescending(o => o.PriorityScore ?? float.MinValue))
            row.PriorityRank = rank++;
    }

    private static JobAnalyticsSummary BuildSummary(string domainId, Job job, List<JobAnalyticsRow> rows, JobAnalyticsConfig config)
    {
        List<JobAnalyticsRow> analyzable = rows.Where(o => o.IsAnalyzable).ToList();
        List<float> docking = analyzable.Where(o => o.DockingEffectiveScore.HasValue).Select(o => o.DockingEffectiveScore.Value).OrderBy(o => o).ToList();

        JobAnalyticsSummary summary = new()
        {
            DomainId = domainId,
            Job = job,
            Rows = rows,
            TotalRows = rows.Count,
            AnalyzableRows = analyzable.Count,
            ExcludedByMissingDocking = rows.Count(o => o.ExclusionReasons.Contains("Missing docking score")),
            ExcludedByMissingSimilarity = rows.Count(o => o.ExclusionReasons.Contains("Missing similarity score")),
            MeanDocking = docking.Count > 0 ? docking.Average() : null,
            MedianDocking = docking.Count > 0 ? docking[docking.Count / 2] : null,
            HighPriorityCount = analyzable.Count(o => o.CandidateClass == "High"),
            AppliedConfig = config,
            TopCandidates = analyzable.OrderBy(o => o.PriorityRank).Take(config.AnalysisParams.TopN).ToList(),
            GroupedByProtein = BuildGroups(analyzable, o => o.ProteinSymbol),
            GroupedByGene = BuildGroups(analyzable, o => o.GeneSymbol),
            GroupedByLigand = BuildGroups(analyzable, o => o.LigandName),
        };

        summary.DistributionStats["priority_score"] = analyzable.Select(o => o.PriorityScore).Where(o => o.HasValue).Select(o => o.Value).ToArray();
        summary.DistributionStats["docking"] = analyzable.Select(o => o.DockingEffectiveScore).Where(o => o.HasValue).Select(o => o.Value).ToArray();
        summary.DistributionStats["similarity"] = analyzable.Select(o => o.SimilarityScore).Where(o => o.HasValue).Select(o => o.Value).ToArray();

        summary.FigureData["scatter"] = analyzable.Select(o => new
        {
            x = o.DockingEffectiveScore,
            y = o.SimilarityScore,
            size = config.PlotParams.ScatterSizeBase + config.PlotParams.ScatterSizeScale * (o.PriorityScore ?? 0) / 100f,
            label = $"{o.LigandName} / {o.ProteinSymbol}"
        }).ToArray();

        return summary;
    }

    private static List<JobAnalyticsGroupSummary> BuildGroups(IEnumerable<JobAnalyticsRow> rows, Func<JobAnalyticsRow, string> keySelector)
    {
        return rows.GroupBy(keySelector)
            .Select(g => new JobAnalyticsGroupSummary
            {
                GroupKey = g.Key,
                TotalRows = g.Count(),
                AnalyzableRows = g.Count(o => o.IsAnalyzable),
                MeanPriorityScore = g.Any(o => o.PriorityScore.HasValue)
                    ? g.Where(o => o.PriorityScore.HasValue).Select(o => o.PriorityScore!.Value).Average()
                    : null,
                MeanDocking = g.Any(o => o.DockingEffectiveScore.HasValue)
                    ? g.Where(o => o.DockingEffectiveScore.HasValue).Select(o => o.DockingEffectiveScore!.Value).Average()
                    : null,
            })
            .OrderByDescending(o => o.MeanPriorityScore)
            .ToList();
    }
}
