namespace CommonTools;

public static class FuzzyMatchingHelper
{
    public static bool FuzzyMatch(this string s, params string[] patterns)
    {
        if (s == null)
            return false;
        foreach (string pattern in patterns)
        {
            int i = 0, j = 0;
            while (true)
            {
                while (i < s.Length && (s[i] == ' ' || s[i] == '-' || s[i] == '_' || s[i] == '.'))
                    i++;
                while (j < pattern.Length && (pattern[j] == ' ' || pattern[j] == '-' || pattern[j] == '_' || pattern[j] == '.'))
                    j++;
                if ((i < s.Length) ^ (j < pattern.Length))
                    break;
                if (i == s.Length)
                    return true;
                if (char.ToLower(s[i]) != char.ToLower(pattern[j]))
                    break;
                i++;
                j++;
            }
        }
        return false;
    }
}
