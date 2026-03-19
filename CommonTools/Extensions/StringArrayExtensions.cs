using System.Linq;

namespace CommonTools;

public static class StringArrayExtensions
{
    public static bool IsEmpty(this string[] row)
    {
        return row == null || row.All(string.IsNullOrWhiteSpace);
    }
}
