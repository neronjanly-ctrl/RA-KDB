using System.Collections.Generic;
using System.Linq;

namespace CommonTools;

public static class StringExtensions
{
    private static readonly HashSet<string> FunctionWords = new() {
        "a", "an", "the", "s",
        "you", "he", "she", "it", "we", "they",
        "me", "him", "her", "us", "them",
        "my", "his", "its", "our", "your", "their",
        "mine", "yours", "hers", "theirs",
        "in", "under", "towards", "from", "to", "before", "of", "for",
        "and", "but", "though", "although",
        "if", "then", "else", "well", "however", "thus", "therefore",
        "would", "could", "should", "might",
        "up", "on", "down", "out", "with", "as",
        "oh", "ah", "eh",
        "yes", "no", "okay",
        "etc", "et", "al",
    };

    private const string Delimiters = ":;&(/";

    public static string CapitalizeTitle(this string s, HashSet<string> terms = null)
    {
        char[] arr = s.ToCharArray();
        bool first = true, inword = false;
        Dictionary<string, string> termDict = terms?.ToDictionary(o => o.ToLower(), o => o);

        for (int i = 0, st = -1; i <= arr.Length; i++)
        {
            if (inword)
            {
                if (i == arr.Length || !char.IsLetter(arr[i]))
                {
                    inword = false;
                    string w = new string(arr[st..i]).ToLower();
                    if (termDict != null && termDict.TryGetValue(w, out string t))
                    {
                        first = false;
                        for (int j = st; j < i; j++)
                            arr[j] = t[j - st];
                    }
                    else
                    {
                        for (int j = st; j < i; j++)
                            arr[j] = char.ToLower(arr[j]);
                        if (first || !FunctionWords.Contains(w))
                        {
                            first = false;
                            arr[st] = char.ToUpper(arr[st]);
                        }
                    }
                }
            }
            else
            {
                if (i < arr.Length && char.IsLetter(arr[i]))
                {
                    inword = true;
                    st = i;
                }
            }
            if (i < arr.Length && Delimiters.Contains(arr[i]))
                first = true;
        }
        return new(arr);
    }
}
