using System;
using System.Collections.Generic;
using System.Linq;

public static class DistinctExtensions
{
	public static IEnumerable<TResult> Distinct<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
		=> source.Select(selector).Distinct();
}