using System;
using System.Collections.Generic;
using System.Linq;

namespace Xmf2.Common.Extensions
{
	public static class ComparisonExtensions
	{
		public static Comparison<T> Combine<T>(this IEnumerable<Comparison<T>> comparisons)
		{
			return comparisons.ToArray().Combine();
		}

		public static Comparison<T> Combine<T>(this IReadOnlyList<Comparison<T>> comparisons)
		{
			return ((T x, T y) => ByCombinedComparisons(x, y));

			int ByCombinedComparisons(T x, T y)
			{
				int result = 0;
				for (int i = 0 ; i < comparisons.Count; i++)
				{
					if ((result = comparisons[i](x, y)) != 0)
					{
						return result;
					}
				}
				return result;
			}
		}
	}
}
