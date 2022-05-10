using System;
using System.Collections.Generic;
using System.Linq;

namespace Xmf2.Common.Collections
{
	//TODO BUGGY
	public static class HashsetExtensions
	{
#if NETSTANDARD2_0
		public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source) => new HashSet<T>(source);
#endif
		public static HashSet<TResult> ToHashSet<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
		{
#if NETSTANDARD2_0
			return HashsetExtensions.ToHashSet(source.Select(selector));
#else
			return System.Linq.Enumerable.ToHashSet(source.Select(selector));
#endif
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