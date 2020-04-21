using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
	public static class DictionaryExtensions
	{
		public static void Add<TKey, TKey2, TValue>(this Dictionary<TKey, Dictionary<TKey2, TValue>> items, TKey key, TKey2 key2, TValue value)
		{
			if (!items.TryGetValue(key, out var d))
			{
				items.Add(key, d = new Dictionary<TKey2, TValue>());
			}

			d[key2] = value;
		}
	}
}