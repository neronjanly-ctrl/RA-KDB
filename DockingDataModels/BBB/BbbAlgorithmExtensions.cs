using CommonTools;

namespace DockingDataModels;

public static class BbbAlgorithmExtensions
{
    public static BbbAlgorithm ParseBbbAlgorithm(this string s)
    {
        return EnumByMatchParser<BbbAlgorithm>.Parse(s);
    }

    public static bool TryParseBbbAlgorithm(this string s, out BbbAlgorithm value)
    {
        return EnumByMatchParser<BbbAlgorithm>.TryParse(s, out value);
    }

    public static string GetName(this BbbAlgorithm element)
    {
        return EnumAnnotationHelper<BbbAlgorithm>.GetAttribute<NameAttribute>(element).Name;
    }

    public static string GetArgumentName(this BbbAlgorithm element)
    {
        return EnumAnnotationHelper<BbbAlgorithm>.GetAttribute<NameAttribute>(element).InternalName;
    }

    public static BbbAlgorithm[] All => EnumAnnotationHelper<BbbAlgorithm>.Enums;
}
