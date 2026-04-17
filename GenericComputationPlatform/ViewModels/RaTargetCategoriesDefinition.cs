using System.Collections.Generic;

namespace GenericComputationPlatform.ViewModels;

public class RaTargetCategoryDefinition
{
    public string Key { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public IReadOnlySet<string> Symbols { get; init; } = new HashSet<string>();
}