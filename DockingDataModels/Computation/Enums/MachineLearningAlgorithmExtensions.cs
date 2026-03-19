using CommonTools;

namespace DockingDataModels;

public static class MachineLearningAlgorithmExtensions
{
    public static MachineLearningAlgorithm ParseMachineLearningAlgorithm(this string s)
    {
        return EnumByMatchParser<MachineLearningAlgorithm>.Parse(s);
    }

    public static bool TryParseMachineLearningAlgorithm(this string s, out MachineLearningAlgorithm value)
    {
        return EnumByMatchParser<MachineLearningAlgorithm>.TryParse(s, out value);
    }

    public static string GetName(this MachineLearningAlgorithm element)
    {
        return EnumAnnotationHelper<MachineLearningAlgorithm>.GetAttribute<NameAttribute>(element).Name;
    }

    public static string GetArgumentName(this MachineLearningAlgorithm element)
    {
        return EnumAnnotationHelper<MachineLearningAlgorithm>.GetAttribute<NameAttribute>(element).InternalName;
    }

    public static MachineLearningAlgorithm[] All => EnumAnnotationHelper<MachineLearningAlgorithm>.Enums;
}
