using System;
using System.Collections.Generic;
using System.Linq;

namespace Xmf2.Common.Collections
{
	public static class HashsetExtensions
	{
		public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source) => new HashSet<T>(source);

		public static HashSet<TResult> ToHashSet<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
		{
			return source.Select(selector).ToHashSet();
		}

		public static void AddRange<TSource>(this HashSet<TSource> source, IEnumerable<TSource> items)
		{
			foreach (TSource item in items)
			{
				source.Add(item);
			}
		}
	}
}