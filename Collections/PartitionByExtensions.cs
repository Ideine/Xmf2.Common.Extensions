using System;
using System.Collections.Generic;
using System.Linq;

namespace Xmf2.Common.Collections
{
	public static class PartitionByExtensions
	{
		public static IEnumerable<(TCompared key, IEnumerable<T> series)> PartitionBy<T, TCompared>(this IEnumerable<T> source, Func<T, TCompared> selector)
		{
			using (var enumerator = source.GetEnumerator())
			{
				bool moveNext = enumerator.MoveNext();
				var equalityComparer = moveNext ? EqualityComparer<TCompared>.Default : null;
				while (moveNext)
				{
					var bunchKey = selector(enumerator.Current);
					yield return (bunchKey, GetSeries(bunchKey).ToList());
				}
				IEnumerable<T> GetSeries(TCompared seriesKey)
				{
					var firstOfSeries = true;
					var sameSeries = true;
					do
					{
						var current = enumerator.Current;
						if (firstOfSeries || equalityComparer.Equals(seriesKey, selector(current)))
						{
							yield return current;
							firstOfSeries = false;
							moveNext = enumerator.MoveNext();
						}
						else
						{
							sameSeries = false;
						}
					} while (moveNext && sameSeries);
				}
			}
		}
	}
}
