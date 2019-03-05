using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Extensions
{
    public static class DictionaryExtensions
    {
        public static void ForEach<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Action<TKey, TValue> invoke)
        {
            foreach (var kvp in dictionary)
                invoke(kvp.Key, kvp.Value);
        }
    }
}
