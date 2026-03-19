using System.Text.RegularExpressions;

namespace CommonTools;

public static class PathExtensions
{
    public static string EscapePath(this string path)
    {
        return Regex.Replace(path, @"[\\/:*?""<>|]+", "_");
    }
}
