using System.Collections.Generic;

namespace CommonTools;

public static class DictionaryExtentions
{
    public static TValue GetValueSafe<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dict, TKey key)
    {
        return dict.TryGetValue(key, out TValue value) ? value : default;
    }
}
