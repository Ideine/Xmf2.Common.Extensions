using System;
using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
	public static class ToDictionaryExtensions
	{
		public static Dictionary<TKey, TSource> ToDictionary<TKey, TSource>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, int capacity)
		{
			return source.ToDictionary(keySelector, EqualityComparer<TKey>.Default, capacity);
		}

		public static Dictionary<TKey, TSource> ToDictionary<TKey, TSource>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer, int capacity)
		{
			var dictionary = new Dictionary<TKey, TSource>(capacity, comparer);
			foreach (TSource item in source)
			{
				dictionary.Add(keySelector(item), item);
			}

			return dictionary;
		}

		public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, int capacity)
		{
			return source.ToDictionary(keySelector, elementSelector, EqualityComparer<TKey>.Default, capacity);
		}

		public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer, int capacity)
		{
			var dictionary = new Dictionary<TKey, TElement>(capacity, comparer);
			foreach (TSource item in source)
			{
				dictionary.Add(keySelector(item), elementSelector(item));
			}

			return dictionary;
		}
	}
}