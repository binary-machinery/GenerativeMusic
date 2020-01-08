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
    
    // Fisher–Yates shuffle, https://stackoverflow.com/questions/273313/randomize-a-listt/1262619#1262619
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            int random = UnityEngine.Random.Range(0, int.MaxValue);
            int k = random % n;
            --n;
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}