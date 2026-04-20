using System.Collections.Generic;

namespace GenericComputationPlatform.Analytics;

public class JobAnalyticsConfigMeta
{
    public List<JobAnalyticsConfigFieldMeta> Fields { get; set; } = new();
}

public class JobAnalyticsConfigFieldMeta
{
    public string Label { get; set; }
    public string Type { get; set; }
    public object Default { get; set; }
    public bool Editable { get; set; } = true;
    public double? Min { get; set; }
    public double? Max { get; set; }
    public double? Step { get; set; }
    public string Group { get; set; }
    public string UiComponent { get; set; }
    public string Description { get; set; }
    public string Path { get; set; }
    public string PlatformLockedNote { get; set; }
}
