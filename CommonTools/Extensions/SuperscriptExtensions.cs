using System.Collections.Generic;
using System.Linq;

namespace CommonTools;

/// <summary>
/// 
/// </summary>
/// <see cref="https://en.wikipedia.org/wiki/Unicode_subscripts_and_superscripts"/>
public static class SuperscriptExtensions
{
    private static readonly Dictionary<char, int> _superDict = new()
    {
        // all decimal digits
        { '0', 0x2070 },
        { '1', 0x00B9 },
        { '2', 0x00B2 },
        { '3', 0x00B3 },
        { '4', 0x2074 },
        { '5', 0x2075 },
        { '6', 0x2076 },
        { '7', 0x2077 },
        { '8', 0x2078 },
        { '9', 0x2079 },
        // math symbols +-=()
        { '+', 0x207A },
        { '-', 0x207B },
        { '=', 0x207C },
        { '(', 0x207D },
        { ')', 0x207E },
        // all upper case alphabets but CFQSXYZ
        { 'A', 0x1D2C },
        { 'B', 0x1D2E },
        { 'D', 0x1D30 },
        { 'E', 0x1D31 },
        { 'G', 0x1D33 },
        { 'H', 0x1D34 },
        { 'I', 0x1D35 },
        { 'J', 0x1D36 },
        { 'K', 0x1D37 },
        { 'L', 0x1D38 },
        { 'M', 0x1D39 },
        { 'N', 0x1D3A },
        { 'O', 0x1D3C },
        { 'P', 0x1D3E },
        { 'R', 0x1D3F },
        { 'T', 0x1D40 },
        { 'U', 0x1D41 },
        { 'V', 0x2C7D },
        { 'W', 0x1D42 },
        // all lower case alphabets but q
        { 'a', 0x1D43 },
        { 'b', 0x1D47 },
        { 'c', 0x1D9C },
        { 'd', 0x1D48 },
        { 'e', 0x1D49 },
        { 'f', 0x1DA0 },
        { 'g', 0x1D4D },
        { 'h', 0x02B0 },
        { 'i', 0x2071 },
        { 'j', 0x02B2 },
        { 'k', 0x1D4F },
        { 'l', 0x02E1 },
        { 'm', 0x1D50 },
        { 'n', 0x207F },
        { 'o', 0x1D52 },
        { 'p', 0x1D56 },
        { 'r', 0x02B3 },
        { 's', 0x02E2 },
        { 't', 0x1D57 },
        { 'u', 0x1D58 },
        { 'v', 0x1D5B },
        { 'w', 0x02B7 },
        { 'x', 0x02E3 },
        { 'y', 0x02B8 },
        { 'z', 0x1DBB },
    };

    /// <summary>
    /// Only [0123456789+-=()ABDEGHIJKLMNOPRTUVWabcdefghijklmnoprstuvwxyz] are supported.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string ToSuperscript(this string s)
    {
        if (s.Any(o => !_superDict.ContainsKey(o)))
            return null;
        return string.Join(string.Empty, s.Select(o => $"&#x{_superDict[o]:x4};"));
    }

    public static string ToSuperscript(this int n)
    {
        return n.ToString().ToSuperscript();
    }

    private static readonly Dictionary<char, int> _subDict = new()
    {
        // all decimal digits
        { '0', 0x2080 },
        { '1', 0x2081 },
        { '2', 0x2082 },
        { '3', 0x2083 },
        { '4', 0x2084 },
        { '5', 0x2085 },
        { '6', 0x2086 },
        { '7', 0x2087 },
        { '8', 0x2088 },
        { '9', 0x2089 },
        // math symbols +-=()
        { '+', 0x208A },
        { '-', 0x208B },
        { '=', 0x208C },
        { '(', 0x208D },
        { ')', 0x208E },
        // all lower case alphabets but bcdfgqwyz
        { 'a', 0x2090 },
        { 'e', 0x2091 },
        { 'h', 0x2095 },
        { 'i', 0x1D62 },
        { 'j', 0x2C7C },
        { 'k', 0x2096 },
        { 'l', 0x2097 },
        { 'm', 0x2098 },
        { 'n', 0x2099 },
        { 'o', 0x2092 },
        { 'p', 0x209A },
        { 'r', 0x1D63 },
        { 's', 0x209B },
        { 't', 0x209C },
        { 'u', 0x1D64 },
        { 'v', 0x1D65 },
        { 'x', 0x2093 },
    };

    /// <summary>
    /// Only [0123456789+-=()aehijlklmnoprstuvx] are supported.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string ToSubscript(this string s)
    {
        if (s.Any(o => !_subDict.ContainsKey(o)))
            return null;
        return string.Join(string.Empty, s.Select(o => $"&#x{_subDict[o]:x4};"));
    }

    public static string ToSubscript(this int n)
    {
        return n.ToString().ToSubscript();
    }
}
