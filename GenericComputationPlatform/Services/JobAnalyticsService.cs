using CommonTools;
using DockingApiClient;
using DockingDataModels;
using GenericComputationPlatform.Analytics;
using GenericComputationPlatform.Extensions;
using Microsoft.AspNetCore.Routing;
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
    private readonly LinkGenerator _linkGenerator;

    public JobAnalyticsService(
        JobClient jobClient,
        ResultClient resultClient,
        Microsoft.Extensions.Options.IOptions<AppSettings> appSettings,
        LinkGenerator linkGenerator)
    {
        _jobClient = jobClient;
        _resultClient = resultClient;
        _appSettings = appSettings.Value;
        _linkGenerator = linkGenerator;
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
                new() {
                    Label = "Docking Threshold",
                    Type = "number",
                    Default = defaults.PlatformDefaults.DockingThreshold,
                    Editable = true,
                    Min = -20, Max = 0, Step = 0.1,
                    Group = "platform_defaults",
                    UiComponent = "number",
                    Description = "Docking threshold used in analysis space only.",
                    Path = "platformDefaults.dockingThreshold",
                    PlatformLockedNote = "Platform Spider Plot uses fixed platform thresholds."
                },
                new() {
                    Label = "Similarity Threshold (Interaction)",
                    Type = "number",
                    Default = defaults.PlatformDefaults.SimilarityThresholdInteraction,
                    Editable = true,
                    Min = 0, Max = 1, Step = 0.01,
                    Group = "platform_defaults",
                    UiComponent = "slider",
                    Description = "Similarity threshold for interaction candidates.",
                    Path = "platformDefaults.similarityThresholdInteraction",
                    PlatformLockedNote = "Platform Spider Plot uses fixed platform thresholds."
                },
                new() {
                    Label = "Similarity Threshold (Known)",
                    Type = "number",
                    Default = defaults.PlatformDefaults.SimilarityThresholdKnown,
                    Editable = true,
                    Min = 0, Max = 1, Step = 0.01,
                    Group = "platform_defaults",
                    UiComponent = "slider",
                    Description = "Similarity threshold for known-like candidates.",
                    Path = "platformDefaults.similarityThresholdKnown",
                    PlatformLockedNote = "Platform Spider Plot uses fixed platform thresholds."
                },
                new() {
                    Label = "Top N",
                    Type = "integer",
                    Default = defaults.AnalysisParams.TopN,
                    Editable = true,
                    Min = 1, Max = 100, Step = 1,
                    Group = "analysis_params",
                    UiComponent = "number",
                    Description = "Number of top candidates to display/export.",
                    Path = "analysisParams.topN"
                },
                new() {
                    Label = "Docking Aggregate Method",
                    Type = "select",
                    Default = defaults.AnalysisParams.AggregateMethod,
                    Editable = true,
                    Group = "analysis_params",
                    UiComponent = "select",
                    Description = "Aggregate method for docking scores.",
                    Path = "analysisParams.aggregateMethod"
                },
                new() {
                    Label = "High Priority Max Std",
                    Type = "number",
                    Default = defaults.AnalysisParams.HighPriorityStdThreshold,
                    Editable = true,
                    Min = 0, Max = 5, Step = 0.05,
                    Group = "analysis_params",
                    UiComponent = "number",
                    Description = "Maximum docking std allowed for high-priority classification.",
                    Path = "analysisParams.highPriorityStdThreshold"
                },
                new() {
                    Label = "Moderate Docking Threshold",
                    Type = "number",
                    Default = defaults.AnalysisParams.ModerateDockingThreshold,
                    Editable = true,
                    Min = -20, Max = 0, Step = 0.1,
                    Group = "analysis_params",
                    UiComponent = "number",
                    Description = "Docking threshold used in moderate candidate classification.",
                    Path = "analysisParams.moderateDockingThreshold"
                },
                new() {
                    Label = "Moderate Similarity Threshold",
                    Type = "number",
                    Default = defaults.AnalysisParams.ModerateSimilarityThreshold,
                    Editable = true,
                    Min = 0, Max = 1, Step = 0.01,
                    Group = "analysis_params",
                    UiComponent = "slider",
                    Description = "Similarity threshold used in moderate candidate classification.",
                    Path = "analysisParams.moderateSimilarityThreshold"
                },
                new() {
                    Label = "Bonus: All Models Pass",
                    Type = "number",
                    Default = defaults.RuleBonus.AllModelsPassBonus,
                    Editable = true,
                    Min = 0, Max = 100, Step = 1,
                    Group = "rule_bonus",
                    UiComponent = "number",
                    Description = "Rule bonus when all valid docking models pass threshold.",
                    Path = "ruleBonus.allModelsPassBonus"
                },
                new() {
                    Label = "Bonus: Interaction Pass",
                    Type = "number",
                    Default = defaults.RuleBonus.InteractionBonus,
                    Editable = true,
                    Min = 0, Max = 100, Step = 1,
                    Group = "rule_bonus",
                    UiComponent = "number",
                    Description = "Rule bonus when similarity passes interaction threshold.",
                    Path = "ruleBonus.interactionBonus"
                },
                new() {
                    Label = "Bonus: Known Pass",
                    Type = "number",
                    Default = defaults.RuleBonus.KnownCompoundBonus,
                    Editable = true,
                    Min = 0, Max = 100, Step = 1,
                    Group = "rule_bonus",
                    UiComponent = "number",
                    Description = "Rule bonus when similarity passes known threshold.",
                    Path = "ruleBonus.knownCompoundBonus"
                },
                new() {
                    Label = "Weight: Docking",
                    Type = "number",
                    Default = defaults.PriorityWeights.DockingWeight,
                    Editable = true,
                    Min = 0, Max = 100, Step = 1,
                    Group = "priority_weights",
                    UiComponent = "slider",
                    Description = "Weight of docking contribution in priority score.",
                    Path = "priorityWeights.dockingWeight"
                },
                new() {
                    Label = "Weight: Similarity",
                    Type = "number",
                    Default = defaults.PriorityWeights.SimilarityWeight,
                    Editable = true,
                    Min = 0, Max = 100, Step = 1,
                    Group = "priority_weights",
                    UiComponent = "slider",
                    Description = "Weight of similarity contribution in priority score.",
                    Path = "priorityWeights.similarityWeight"
                },
                new() {
                    Label = "Weight: Consistency",
                    Type = "number",
                    Default = defaults.PriorityWeights.ConsistencyWeight,
                    Editable = true,
                    Min = 0, Max = 100, Step = 1,
                    Group = "priority_weights",
                    UiComponent = "slider",
                    Description = "Weight of consistency contribution in priority score.",
                    Path = "priorityWeights.consistencyWeight"
                },
                new() {
                    Label = "Weight: Rule Bonus",
                    Type = "number",
                    Default = defaults.PriorityWeights.RuleBonusWeight,
                    Editable = true,
                    Min = 0, Max = 100, Step = 1,
                    Group = "priority_weights",
                    UiComponent = "slider",
                    Description = "Weight of rule-bonus contribution in priority score.",
                    Path = "priorityWeights.ruleBonusWeight"
                },
                new() {
                    Label = "Scatter Size Base",
                    Type = "number",
                    Default = defaults.PlotParams.ScatterSizeBase,
                    Editable = true,
                    Min = 1, Max = 200, Step = 1,
                    Group = "plot_params",
                    UiComponent = "number",
                    Description = "Base size for scatter plot markers.",
                    Path = "plotParams.scatterSizeBase",
                    PlatformLockedNote = "Analytics params do not affect Spider Plot logic."
                },
                new() {
                    Label = "Scatter Size Scale",
                    Type = "number",
                    Default = defaults.PlotParams.ScatterSizeScale,
                    Editable = true,
                    Min = 0, Max = 20, Step = 0.1,
                    Group = "plot_params",
                    UiComponent = "number",
                    Description = "Priority-score-to-marker-size scale.",
                    Path = "plotParams.scatterSizeScale",
                    PlatformLockedNote = "Analytics params do not affect Spider Plot logic."
                }
            }
        };
    }

    public JobAnalyticsConfig ApplyUserParams(JobAnalyticsConfig config)
    {
        config ??= new JobAnalyticsConfig();

        config.AnalysisParams.AggregateMethod =
            (config.AnalysisParams.AggregateMethod ?? "mean").Trim().ToLowerInvariant();

        if (config.AnalysisParams.AggregateMethod != "mean" &&
            config.AnalysisParams.AggregateMethod != "median" &&
            config.AnalysisParams.AggregateMethod != "min")
        {
            config.AnalysisParams.AggregateMethod = "mean";
        }

        if (config.AnalysisParams.TopN < 1)
            config.AnalysisParams.TopN = 1;

        if (config.AnalysisParams.HighPriorityStdThreshold < 0)
            config.AnalysisParams.HighPriorityStdThreshold = 0.5f;

        if (config.AnalysisParams.ModerateSimilarityThreshold < 0)
            config.AnalysisParams.ModerateSimilarityThreshold = 0;
        if (config.AnalysisParams.ModerateSimilarityThreshold > 1)
            config.AnalysisParams.ModerateSimilarityThreshold = 1;

        if (config.PlatformDefaults.SimilarityThresholdInteraction < 0)
            config.PlatformDefaults.SimilarityThresholdInteraction = 0;
        if (config.PlatformDefaults.SimilarityThresholdInteraction > 1)
            config.PlatformDefaults.SimilarityThresholdInteraction = 1;

        if (config.PlatformDefaults.SimilarityThresholdKnown < 0)
            config.PlatformDefaults.SimilarityThresholdKnown = 0;
        if (config.PlatformDefaults.SimilarityThresholdKnown > 1)
            config.PlatformDefaults.SimilarityThresholdKnown = 1;

        return config;
    }

    public JobAnalyticsValidationResult ValidateConfig(JobAnalyticsConfig config, JobAnalyticsConfigMeta meta)
    {
        JobAnalyticsValidationResult validation = new();

        if (config.PlatformDefaults.SimilarityThresholdKnown < config.PlatformDefaults.SimilarityThresholdInteraction)
            validation.Errors.Add("Similarity known threshold must be >= interaction threshold.");

        if (config.AnalysisParams.TopN < 1)
            validation.Errors.Add("TopN must be >= 1.");

        if (config.AnalysisParams.HighPriorityStdThreshold < 0)
            validation.Errors.Add("HighPriorityStdThreshold must be >= 0.");

        if (config.AnalysisParams.ModerateSimilarityThreshold < 0 || config.AnalysisParams.ModerateSimilarityThreshold > 1)
            validation.Errors.Add("ModerateSimilarityThreshold must be in [0,1].");

        float weightSum =
            config.PriorityWeights.DockingWeight +
            config.PriorityWeights.SimilarityWeight +
            config.PriorityWeights.ConsistencyWeight +
            config.PriorityWeights.RuleBonusWeight;

        if (Math.Abs(weightSum) < 0.0001f)
            validation.Errors.Add("Priority weight sum must not be 0.");
        else if (Math.Abs(weightSum - 100.0f) > 0.0001f)
            validation.Warnings.Add($"Priority weight sum is {weightSum:F2}; recommended total is 100.");

        if (config.RuleBonus.InteractionBonus < 0 ||
            config.RuleBonus.KnownCompoundBonus < 0 ||
            config.RuleBonus.AllModelsPassBonus < 0)
        {
            validation.Errors.Add("Rule bonus values must be >= 0.");
        }

        if (config.PlotParams.ScatterSizeBase <= 0)
            validation.Errors.Add("ScatterSizeBase must be > 0.");

        if (config.PlotParams.ScatterSizeScale < 0)
            validation.Errors.Add("ScatterSizeScale must be >= 0.");

        validation.IsValid = validation.Errors.Count == 0;
        return validation;
    }

    public JobAnalyticsValidationResult ValidateDataQuality(IReadOnlyCollection<JobAnalyticsRow> rows, JobAnalyticsPolicy policy)
    {
        int missingDocking = rows.Count(o => o.ExclusionReasons.Contains("Missing docking score"));
        int missingSimilarity = rows.Count(o => o.ExclusionReasons.Contains("Missing similarity score"));
        int analyzable = rows.Count(o => o.IsAnalyzable);

        JobAnalyticsValidationResult validation = new JobAnalyticsValidationResult
        {
            IsValid = analyzable > 0,
            Errors = new List<string>(),
            Warnings = new List<string>()
        };

        validation.Warnings.Add($"Rows with missing docking score: {missingDocking}");
        validation.Warnings.Add($"Rows with missing similarity score: {missingSimilarity}");
        validation.Warnings.Add($"Analyzable rows: {analyzable}");

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
            summary.Figures,
            summary.GroupedByProtein,
            summary.GroupedByGene,
            summary.GroupedByLigand,
            summary.Validation,
            summary.AppliedConfig,
            ConfigMeta = meta,
            Notice = "Analysis Space parameters affect only analytics results and exports. They do not affect platform Spider Plot logic."
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
            new [] { "Applied docking threshold", summary.AppliedConfig.PlatformDefaults.DockingThreshold.ToString("F3", CultureInfo.InvariantCulture) },
            new [] { "Applied interaction threshold", summary.AppliedConfig.PlatformDefaults.SimilarityThresholdInteraction.ToString("F3", CultureInfo.InvariantCulture) },
            new [] { "Applied known threshold", summary.AppliedConfig.PlatformDefaults.SimilarityThresholdKnown.ToString("F3", CultureInfo.InvariantCulture) },
            new [] { "Applied aggregate method", summary.AppliedConfig.AnalysisParams.AggregateMethod },
            new [] { "" , "" },
            new [] { "Top Candidates" , "" },
            new [] { "Ligand", "Protein", "Gene", "Docking Mean", "Similarity", "Priority Score", "Candidate Class" }
        };

        rows.AddRange(summary.TopCandidates.Select(o => new[]
        {
            o.LigandName,
            o.ProteinSymbol,
            o.GeneSymbol,
            o.DockingMean?.ToString("F3", CultureInfo.InvariantCulture) ?? "N/A",
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
            "PassDockingMean",
            "PassDockingEffective",
            "DockingMeanScore",
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
                o.PassDockingMean ? "true" : "false",
                o.PassDockingEffective ? "true" : "false",
                o.DockingMeanScore?.ToString("F3", CultureInfo.InvariantCulture) ?? "N/A",
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

            row.AddRange(Enumerable.Range(0, maxModelCount).Select(i =>
                i < o.DockingScores.Count && o.DockingScores[i].HasValue
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
            bool hasSimilarity = compound != null;

            string comparePath = _linkGenerator.GetPathByAction(
                action: "Compare",
                controller: "Job",
                values: new
                {
                    domainId,
                    jobId = job.Id,
                    cavityId = o.CavityId.StringifyId(),
                    ligandId = o.LigandId.StringifyId()
                }) ?? string.Empty;

            string sourcePath = _linkGenerator.GetPathByAction(
                action: "JobDetails",
                controller: "Protein",
                values: new
                {
                    domainId,
                    jobId = job.Id,
                    cavityId = o.CavityId.StringifyId()
                }) ?? string.Empty;

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
                SimilarityScore = hasSimilarity ? compound.Similarity : null,
                BestMatchId = hasSimilarity ? compound.Id : null,
                BestMatchUrl = hasSimilarity ? compound.Url : null,
                BestMatchSmiles = hasSimilarity ? compound.Smiles : null,
                CompareUrl = string.IsNullOrWhiteSpace(comparePath) ? null : hosting + comparePath,
                SourceUrl = string.IsNullOrWhiteSpace(sourcePath) ? null : hosting + sourcePath,
            };
        }).ToList();
    }

    private static void ApplyPolicy(List<JobAnalyticsRow> rows, JobAnalyticsPolicy policy)
    {
        foreach (JobAnalyticsRow row in rows)
        {
            bool hasValidDocking = row.DockingScores.Any(v => v.HasValue);
            bool hasValidSimilarity = row.SimilarityScore.HasValue;

            row.IsAnalyzable = true;
            row.ExclusionReasons.Clear();

            if (policy.Docking.ExcludeWhenAllMissing && !hasValidDocking)
            {
                row.IsAnalyzable = false;
                row.ExclusionReasons.Add("Missing docking score");
            }

            if (policy.Similarity.ExcludeFromScoringWhenMissing && !hasValidSimilarity)
            {
                row.IsAnalyzable = false;
                row.ExclusionReasons.Add("Missing similarity score");
            }
        }
    }

    private static void ComputeDerivedFields(List<JobAnalyticsRow> rows, JobAnalyticsConfig config, JobAnalyticsPolicy policy)
    {
        float maxBonus =
            config.RuleBonus.AllModelsPassBonus +
            config.RuleBonus.InteractionBonus +
            config.RuleBonus.KnownCompoundBonus;

        foreach (JobAnalyticsRow row in rows)
        {
            List<float> docking = row.DockingScores.Where(v => v.HasValue).Select(v => v.Value).ToList();

            if (docking.Count > 0)
            {
                row.DockingMean = docking.Average();
                row.DockingMedian = GetMedian(docking);
                row.DockingMin = docking.Min();
                row.DockingMax = docking.Max();
                row.DockingRange = row.DockingMax - row.DockingMin;

                float mean = row.DockingMean.Value;
                row.DockingStd = (float)Math.Sqrt(docking.Average(v => Math.Pow(v - mean, 2)));

                row.ModelsPassingDockingCount = docking.Count(v => v <= config.PlatformDefaults.DockingThreshold);
                row.AllModelsPassDocking = docking.Count > 0 && row.ModelsPassingDockingCount == docking.Count;
                row.AnyModelPassDocking = row.ModelsPassingDockingCount > 0;
            }

            row.PassSimilarityInteraction =
                row.SimilarityScore.HasValue &&
                row.SimilarityScore.Value >= config.PlatformDefaults.SimilarityThresholdInteraction;

            row.PassSimilarityKnown =
                row.SimilarityScore.HasValue &&
                row.SimilarityScore.Value >= config.PlatformDefaults.SimilarityThresholdKnown;

            row.DockingEffectiveScore = GetAggregateDocking(row, config.AnalysisParams.AggregateMethod);

            row.PassDockingEffective =
                row.DockingEffectiveScore.HasValue &&
                row.DockingEffectiveScore.Value <= config.PlatformDefaults.DockingThreshold;

            row.PassDockingMean =
                row.DockingMean.HasValue &&
                row.DockingMean.Value <= config.PlatformDefaults.DockingThreshold;
        }

        List<JobAnalyticsRow> scorableRows = rows
            .Where(r => r.IsAnalyzable && r.DockingMean.HasValue && r.DockingStd.HasValue && r.SimilarityScore.HasValue)
            .ToList();

        float? dockingMeanMin = scorableRows.Count == 0 ? null : scorableRows.Min(r => r.DockingMean);
        float? dockingMeanMax = scorableRows.Count == 0 ? null : scorableRows.Max(r => r.DockingMean);
        float? similarityMin = scorableRows.Count == 0 ? null : scorableRows.Min(r => r.SimilarityScore);
        float? similarityMax = scorableRows.Count == 0 ? null : scorableRows.Max(r => r.SimilarityScore);
        float? dockingStdMin = scorableRows.Count == 0 ? null : scorableRows.Min(r => r.DockingStd);
        float? dockingStdMax = scorableRows.Count == 0 ? null : scorableRows.Max(r => r.DockingStd);

        foreach (JobAnalyticsRow row in scorableRows)
        {
            row.DockingMeanScore = MinMaxScale(row.DockingMean, dockingMeanMin, dockingMeanMax, reverse: true);
            row.SimilarityScoreNorm = MinMaxScale(row.SimilarityScore, similarityMin, similarityMax, reverse: false);
            row.ConsistencyScore = MinMaxScale(row.DockingStd, dockingStdMin, dockingStdMax, reverse: true);

            row.RuleBonusRaw = 0f;
            if (row.AllModelsPassDocking)
                row.RuleBonusRaw += config.RuleBonus.AllModelsPassBonus;
            if (row.PassSimilarityInteraction)
                row.RuleBonusRaw += config.RuleBonus.InteractionBonus;
            if (row.PassSimilarityKnown)
                row.RuleBonusRaw += config.RuleBonus.KnownCompoundBonus;

            row.RuleBonusNorm = maxBonus <= 0 ? 0f : row.RuleBonusRaw / maxBonus;

            row.PriorityScore =
                (config.PriorityWeights.DockingWeight * (row.DockingMeanScore ?? 0f)) +
                (config.PriorityWeights.SimilarityWeight * (row.SimilarityScoreNorm ?? 0f)) +
                (config.PriorityWeights.ConsistencyWeight * (row.ConsistencyScore ?? 0f)) +
                (config.PriorityWeights.RuleBonusWeight * row.RuleBonusNorm);

            row.CandidateClass = ClassifyCandidate(row, config);
        }

        int rank = 1;
        foreach (JobAnalyticsRow row in scorableRows
            .OrderByDescending(r => r.PriorityScore ?? float.MinValue)
            .ThenBy(r => r.DockingMean ?? float.MaxValue)
            .ThenByDescending(r => r.SimilarityScore ?? float.MinValue))
        {
            row.PriorityRank = rank++;
        }
    }

    private static JobAnalyticsSummary BuildSummary(string domainId, Job job, List<JobAnalyticsRow> rows, JobAnalyticsConfig config)
    {
        List<JobAnalyticsRow> scorableRows = rows.Where(o => o.IsAnalyzable && o.PriorityScore.HasValue).ToList();
        List<float> docking = rows
            .Where(o => o.DockingMean.HasValue)
            .Select(o => o.DockingMean!.Value)
            .ToList();

        return new JobAnalyticsSummary
        {
            DomainId = domainId,
            Job = job,
            Rows = rows,
            TotalRows = rows.Count,
            AnalyzableRows = scorableRows.Count,
            ExcludedByMissingDocking = rows.Count(o => o.ExclusionReasons.Contains("Missing docking score")),
            ExcludedByMissingSimilarity = rows.Count(o => o.ExclusionReasons.Contains("Missing similarity score")),
            MeanDocking = docking.Count > 0 ? docking.Average() : null,
            MedianDocking = docking.Count > 0 ? GetMedian(docking) : null,
            HighPriorityCount = scorableRows.Count(o => o.CandidateClass == "High Priority"),
            AppliedConfig = config,
            TopCandidates = scorableRows.OrderBy(o => o.PriorityRank).Take(config.AnalysisParams.TopN).ToList(),
            GroupedByProtein = BuildGroups(rows, o => o.ProteinSymbol),
            GroupedByGene = BuildGroups(rows, o => o.GeneSymbol),
            GroupedByLigand = BuildGroups(rows, o => o.LigandName),
            Figures = BuildFigures(rows, scorableRows, config),
        };
    }

    private static JobAnalyticsFigures BuildFigures(List<JobAnalyticsRow> fullRows, List<JobAnalyticsRow> scorableRows, JobAnalyticsConfig config)
    {
        IEnumerable<float?> flattenedDockingScores = fullRows
            .SelectMany(o => o.DockingScores)
            .Where(o => o.HasValue);

        return new JobAnalyticsFigures
        {
            DockingDistribution = BuildHistogram(
                flattenedDockingScores,
                bins: 15,
                xAxisTitle: "Docking score",
                yAxisTitle: "Count",
                thresholds: new List<HistogramThresholdLine>
                {
                    new()
                    {
                        Value = config.PlatformDefaults.DockingThreshold,
                        Label = "Docking threshold",
                        Color = "#111827"
                    }
                }),
            ModelBoxplot = BuildModelBoxplot(fullRows),
            SimilarityDistribution = BuildHistogram(
                fullRows.Select(o => o.SimilarityScore),
                bins: 15,
                xAxisTitle: "Similarity score",
                yAxisTitle: "Count",
                thresholds: new List<HistogramThresholdLine>
                {
                    new()
                    {
                        Value = config.PlatformDefaults.SimilarityThresholdInteraction,
                        Label = "Interaction threshold",
                        Color = "#0f766e"
                    },
                    new()
                    {
                        Value = config.PlatformDefaults.SimilarityThresholdKnown,
                        Label = "Known threshold",
                        Color = "#7c3aed"
                    }
                }),
            PriorityScatter = BuildPriorityScatter(scorableRows, config),
            TopCandidatesBar = BuildTopCandidatesBar(scorableRows, config.AnalysisParams.TopN),
            ModelCorrelationHeatmap = BuildCorrelationHeatmap(fullRows),
        };
    }

    private static HistogramFigure BuildHistogram(
        IEnumerable<float?> values,
        int bins,
        string xAxisTitle,
        string yAxisTitle,
        List<HistogramThresholdLine> thresholds = null)
    {
        List<float> numeric = values.Where(o => o.HasValue).Select(o => o!.Value).ToList();
        HistogramFigure figure = new()
        {
            XAxisTitle = xAxisTitle,
            YAxisTitle = yAxisTitle,
            ThresholdLines = thresholds ?? new List<HistogramThresholdLine>(),
        };

        if (numeric.Count == 0 || bins <= 0)
            return figure;

        float min = numeric.Min();
        float max = numeric.Max();
        figure.Min = min;
        figure.Max = max;

        float range = max - min;
        if (Math.Abs(range) < 0.00001f)
        {
            figure.Labels.Add($"{min:F2}");
            figure.Counts.Add(numeric.Count);
            return figure;
        }

        float step = range / bins;
        int[] counts = new int[bins];

        foreach (float value in numeric)
        {
            int idx = (int)Math.Floor((value - min) / step);
            idx = Math.Clamp(idx, 0, bins - 1);
            counts[idx]++;
        }

        for (int i = 0; i < bins; i++)
        {
            float start = min + i * step;
            float end = i == bins - 1 ? max : start + step;
            figure.Labels.Add($"{start:F2}..{end:F2}");
            figure.Counts.Add(counts[i]);
        }

        return figure;
    }

    private static ModelBoxplotFigure BuildModelBoxplot(List<JobAnalyticsRow> fullRows)
    {
        ModelBoxplotFigure figure = new();
        int modelCount = fullRows.Count == 0 ? 0 : fullRows.Max(o => o.DockingScores.Count);

        for (int i = 0; i < modelCount; i++)
        {
            List<float> values = fullRows
                .Where(o => o.DockingScores.Count > i && o.DockingScores[i].HasValue)
                .Select(o => o.DockingScores[i]!.Value)
                .OrderBy(o => o)
                .ToList();

            if (values.Count == 0)
                continue;

            figure.Models.Add(new ModelBoxplotItem
            {
                Model = $"Model {i + 1}",
                Min = values.First(),
                Q1 = GetPercentile(values, 0.25f),
                Median = GetPercentile(values, 0.5f),
                Q3 = GetPercentile(values, 0.75f),
                Max = values.Last(),
            });
        }

        return figure;
    }

    private static PriorityScatterFigure BuildPriorityScatter(List<JobAnalyticsRow> scorableRows, JobAnalyticsConfig config)
    {
        return new PriorityScatterFigure
        {
            ThresholdLines = new List<ScatterThresholdLine>
            {
                new() { Axis = "x", Value = config.PlatformDefaults.DockingThreshold, Label = "Docking threshold", Color = "#111827" },
                new() { Axis = "y", Value = config.PlatformDefaults.SimilarityThresholdInteraction, Label = "Interaction threshold", Color = "#0f766e" },
                new() { Axis = "y", Value = config.PlatformDefaults.SimilarityThresholdKnown, Label = "Known threshold", Color = "#7c3aed" },
            },
            Points = scorableRows.Select(o => new PriorityScatterPoint
            {
                X = o.DockingMean,
                Y = o.SimilarityScore,
                Size = config.PlotParams.ScatterSizeBase + config.PlotParams.ScatterSizeScale * ((o.PriorityScore ?? 0f) / 100f),
                Label = o.ProteinSymbol,
                Protein = o.ProteinSymbol,
                CandidateClass = o.CandidateClass,
                Priority = o.PriorityScore,
                Docking = o.DockingMean,
                Similarity = o.SimilarityScore,
                PriorityRank = o.PriorityRank,
                PassSimilarityInteraction = o.PassSimilarityInteraction,
                PassSimilarityKnown = o.PassSimilarityKnown,
                IsTopCandidate = o.PriorityRank.HasValue && o.PriorityRank.Value <= config.AnalysisParams.TopN,
            }).ToList()
        };
    }

    private static TopCandidatesBarFigure BuildTopCandidatesBar(List<JobAnalyticsRow> scorableRows, int topN)
    {
        TopCandidatesBarFigure figure = new();

        foreach (JobAnalyticsRow row in scorableRows.OrderBy(o => o.PriorityRank).Take(topN))
        {
            figure.Labels.Add(row.ProteinSymbol);
            figure.PriorityScores.Add(row.PriorityScore ?? 0f);
        }

        return figure;
    }

    private static CorrelationHeatmapFigure BuildCorrelationHeatmap(List<JobAnalyticsRow> fullRows)
    {
        int modelCount = fullRows.Count == 0 ? 0 : fullRows.Max(o => o.DockingScores.Count);
        Dictionary<string, List<float?>> series = new();

        for (int i = 0; i < modelCount; i++)
        {
            int modelIndex = i;
            series[$"Model {i + 1}"] = fullRows
                .Select(o => o.DockingScores.Count > modelIndex ? o.DockingScores[modelIndex] : null)
                .ToList();
        }

        if (series.Count == 0)
            return new CorrelationHeatmapFigure();

        List<string> labels = series.Keys.ToList();
        CorrelationHeatmapFigure figure = new()
        {
            Labels = labels,
            Matrix = new List<List<float>>()
        };

        for (int i = 0; i < labels.Count; i++)
        {
            List<float> row = new();
            for (int j = 0; j < labels.Count; j++)
            {
                row.Add(GetPearson(series[labels[i]], series[labels[j]]));
            }
            figure.Matrix.Add(row);
        }

        return figure;
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
                MeanDocking = g.Any(o => o.DockingMean.HasValue)
                    ? g.Where(o => o.DockingMean.HasValue).Select(o => o.DockingMean!.Value).Average()
                    : null,
            })
            .OrderByDescending(o => o.MeanPriorityScore ?? float.MinValue)
            .ToList();
    }

    private static string ClassifyCandidate(JobAnalyticsRow row, JobAnalyticsConfig config)
    {
        if (row.DockingMean.HasValue &&
            row.SimilarityScore.HasValue &&
            row.DockingStd.HasValue &&
            row.DockingMean.Value <= config.PlatformDefaults.DockingThreshold &&
            row.SimilarityScore.Value >= config.PlatformDefaults.SimilarityThresholdInteraction &&
            row.DockingStd.Value <= config.AnalysisParams.HighPriorityStdThreshold)
        {
            return "High Priority";
        }

        if (row.DockingMean.HasValue &&
            row.SimilarityScore.HasValue &&
            row.DockingMean.Value <= config.PlatformDefaults.DockingThreshold &&
            row.SimilarityScore.Value >= config.PlatformDefaults.SimilarityThresholdKnown)
        {
            return "Known-like Strong";
        }

        if (row.DockingMean.HasValue &&
            row.SimilarityScore.HasValue &&
            row.DockingMean.Value <= config.PlatformDefaults.DockingThreshold &&
            row.SimilarityScore.Value < config.PlatformDefaults.SimilarityThresholdInteraction)
        {
            return "Novel Strong Binder";
        }

        if (row.AllModelsPassDocking ||
            (row.DockingMean.HasValue &&
             row.SimilarityScore.HasValue &&
             row.DockingMean.Value <= config.AnalysisParams.ModerateDockingThreshold &&
             row.SimilarityScore.Value >= config.AnalysisParams.ModerateSimilarityThreshold))
        {
            return "Moderate";
        }

        return "Low Priority";
    }

    private static float? MinMaxScale(float? value, float? min, float? max, bool reverse)
    {
        if (!value.HasValue || !min.HasValue || !max.HasValue)
            return null;

        float range = max.Value - min.Value;
        if (Math.Abs(range) < 0.00001f)
            return 1f;

        float scaled = (value.Value - min.Value) / range;
        scaled = Math.Clamp(scaled, 0f, 1f);
        return reverse ? 1f - scaled : scaled;
    }

    private static float? GetMedian(List<float> values)
    {
        if (values == null || values.Count == 0)
            return null;

        List<float> sorted = values.OrderBy(x => x).ToList();
        int count = sorted.Count;
        int mid = count / 2;

        if (count % 2 == 1)
            return sorted[mid];

        return (sorted[mid - 1] + sorted[mid]) / 2f;
    }

    private static float GetPercentile(List<float> sortedValues, float percentile)
    {
        if (sortedValues == null || sortedValues.Count == 0)
            return 0f;

        if (sortedValues.Count == 1)
            return sortedValues[0];

        float rank = percentile * (sortedValues.Count - 1);
        int low = (int)Math.Floor(rank);
        int high = (int)Math.Ceiling(rank);
        if (low == high)
            return sortedValues[low];

        float weight = rank - low;
        return sortedValues[low] + (sortedValues[high] - sortedValues[low]) * weight;
    }

    private static float GetPearson(IReadOnlyList<float?> x, IReadOnlyList<float?> y)
    {
        List<(float x, float y)> paired = new();
        for (int i = 0; i < Math.Min(x.Count, y.Count); i++)
        {
            if (x[i].HasValue && y[i].HasValue)
                paired.Add((x[i]!.Value, y[i]!.Value));
        }

        if (paired.Count < 2)
            return 0f;

        float meanX = paired.Average(o => o.x);
        float meanY = paired.Average(o => o.y);
        float cov = paired.Sum(o => (o.x - meanX) * (o.y - meanY));
        float varX = paired.Sum(o => (o.x - meanX) * (o.x - meanX));
        float varY = paired.Sum(o => (o.y - meanY) * (o.y - meanY));

        float denom = (float)Math.Sqrt(varX * varY);
        if (Math.Abs(denom) < 0.00001f)
            return 0f;

        return cov / denom;
    }

    private static float? GetAggregateDocking(JobAnalyticsRow row, string method)
    {
        return method switch
        {
            "median" => row.DockingMedian,
            "min" => row.DockingMin,
            _ => row.DockingMean,
        };
    }
}