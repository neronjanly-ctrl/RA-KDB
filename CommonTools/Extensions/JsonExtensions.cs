using System.Collections.Generic;
using System.Linq;

namespace CommonTools;

public static class JsonExtensions
{
    private static string ToCsv(IEnumerable<string> objs)
    {
        return string.Join(",", objs.Select(o => $@"""{o}"""));
    }

    public static string ToJsonArray(this IEnumerable<string> objs)
    {
        return $"[{ToCsv(objs)}]";
    }

    public static string ToJsonArray(this IEnumerable<int> objs)
    {
        return $"[{string.Join(",", objs)}]";
    }

    public static string ToJsonArray(this IEnumerable<double> objs)
    {
        return $"[{string.Join(",", objs)}]";
    }

    public static string ToJsonArray(this IEnumerable<IEnumerable<string>> objs)
    {
        return $"[{string.Join(",", objs.Select(o => o.ToJsonArray()))}]";
    }

    public static string ToJsonArray(this IEnumerable<IEnumerable<int>> objs)
    {
        return $"[{string.Join(",", objs.Select(o => o.ToJsonArray()))}]";
    }

    public static string ToJsonArray(this IEnumerable<IEnumerable<double>> objs)
    {
        return $"[{string.Join(",", objs.Select(o => o.ToJsonArray()))}]";
    }

    public static string ToJsonArray(this IReadOnlyDictionary<string, string[]> dict)
    {
        return $"[{string.Join(",", dict.Select(o => $@"[""{o.Key}"",{ToCsv(o.Value)}]"))}]";
    }

    public static string ToJsonArray(this IReadOnlyDictionary<string, int[]> dict)
    {
        return $"[{string.Join(",", dict.Select(o => $@"[""{o.Key}"",{string.Join(",", o.Value)}]"))}]";
    }

    public static string ToJsonArray(this IReadOnlyDictionary<string, double[]> dict)
    {
        return $"[{string.Join(",", dict.Select(o => $@"[""{o.Key}"",{string.Join(",", o.Value)}]"))}]";
    }

    public static string ToJsonArray(this IReadOnlyDictionary<int, string[]> dict)
    {
        return $"[{string.Join(",", dict.Select(o => $@"[{o.Key},{ToCsv(o.Value)}]"))}]";
    }

    public static string ToJsonArray(this IReadOnlyDictionary<int, int[]> dict)
    {
        return $"[{string.Join(",", dict.Select(o => $@"[{o.Key},{string.Join(",", o.Value)}]"))}]";
    }

    public static string ToJsonArray(this IReadOnlyDictionary<int, double[]> dict)
    {
        return $"[{string.Join(",", dict.Select(o => $@"[{o.Key},{string.Join(",", o.Value)}]"))}]";
    }
}
