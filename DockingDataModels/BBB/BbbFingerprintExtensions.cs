using CommonTools;

namespace DockingDataModels;

public static class BbbFingerprintExtensions
{
    public static BbbFingerprint ParseBbbFingerprint(this string s)
    {
        return EnumByMatchParser<BbbFingerprint>.Parse(s);
    }

    public static bool TryParseBbbFingerprint(this string s, out BbbFingerprint value)
    {
        return EnumByMatchParser<BbbFingerprint>.TryParse(s, out value);
    }

    public static string GetName(this BbbFingerprint element)
    {
        return EnumAnnotationHelper<BbbFingerprint>.GetAttribute<NameAttribute>(element).Name;
    }

    public static string GetArgumentName(this BbbFingerprint element)
    {
        return EnumAnnotationHelper<BbbFingerprint>.GetAttribute<NameAttribute>(element).InternalName;
    }

    public static BbbFingerprint[] All => EnumAnnotationHelper<BbbFingerprint>.Enums;
}
