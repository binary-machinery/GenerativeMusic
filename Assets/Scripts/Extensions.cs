using System;
using System.Collections.Generic;

public static class Extensions
{
    public static TValue GetFirstOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dict)
    {
        foreach (KeyValuePair<TKey, TValue> kv in dict)
            return kv.Value;
        return default;
    }

    public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
    {
        TValue value;
        if (dict.TryGetValue(key, out value))
            return value;
        return default;
    }

    public static TValue GetOrCreateDefault<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
        where TValue : new()
    {
        TValue value;
        if (!dict.TryGetValue(key, out value))
        {
            value = new TValue();
            dict[key] = value;
        }
        return value;
    }

    public static TValue GetOrCreate<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, Func<TValue> provider)
    where TValue : new()
    {
        TValue value;
        if (!dict.TryGetValue(key, out value))
        {
            value = provider.Invoke();
            dict[key] = value;
        }
        return value;
    }
}
