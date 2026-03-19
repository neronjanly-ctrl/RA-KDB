using System.Globalization;

namespace CommonTools;

public static class HexIdHelper
{
    public static long ParseId(this string idstr) => long.Parse(idstr, NumberStyles.AllowHexSpecifier);

    public static string StringifyId(this long id) => id.ToString("x16");
}
