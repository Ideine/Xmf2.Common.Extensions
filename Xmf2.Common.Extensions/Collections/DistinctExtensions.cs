using System;
using System.Collections.Generic;
using System.Linq;

namespace Xmf2.Common.Collections
{
	public static class DistinctExtensions
	{
#if NET6_0_OR_GREATER
		[Obsolete("use DistinctBy instead")]
#endif
		public static IEnumerable<TResult> Distinct<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
			=> source.Select(selector).Distinct();
	}
}