using CommonTools;

namespace DockingDataModels;

public static class FingerprintExtensions
{
    public static Fingerprint ParseFingerprint(this string s)
    {
        return EnumByMatchParser<Fingerprint>.Parse(s);
    }

    public static bool TryParseFingerprint(this string s, out Fingerprint value)
    {
        return EnumByMatchParser<Fingerprint>.TryParse(s, out value);
    }

    public static string GetName(this Fingerprint element)
    {
        return EnumAnnotationHelper<Fingerprint>.GetAttribute<NameAttribute>(element).Name;
    }

    public static string GetArgumentName(this Fingerprint element)
    {
        return EnumAnnotationHelper<Fingerprint>.GetAttribute<NameAttribute>(element).InternalName;
    }

    public static Fingerprint[] All => EnumAnnotationHelper<Fingerprint>.Enums;
}
