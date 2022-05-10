using System;
using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
	public static class DictionaryExtensions
	{
		public static void Add<TKey, TKey2, TValue>(this Dictionary<TKey, Dictionary<TKey2, TValue>> items, TKey key, TKey2 key2, TValue value)
		{
			if (!items.TryGetValue(key, out Dictionary<TKey2, TValue> d))
			{
				items.Add(key, d = new Dictionary<TKey2, TValue>());
			}

			d[key2] = value;
		}

#if NETSTANDARD2_1 || NET6_0
		[Obsolete("Use TryAdd from System.Collections")]
#endif
		public static bool TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
		{
			if (dictionary.ContainsKey(key))
			{
				return false;
			}
			else
			{
				dictionary.Add(key, value);
				return true;
			}
		}

		public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> items, TKey key)
		{
			items.TryGetValue(key, out TValue value);
			return value;
		}
	}
}