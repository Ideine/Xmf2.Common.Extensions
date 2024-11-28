using System;
using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
	public static class TryGetExtensions
	{
		public static bool TryGetMin<T, TCompared>(this IEnumerable<T> source, Func<T, TCompared> selector, out T min, IComparer<TCompared> comparer = null)
		{
			IEnumerator<T> enumerator = source.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				min = default;
				return false;
			}
			else
			{
				TCompared currentMin = selector(min = enumerator.Current);
				comparer ??= Comparer<TCompared>.Default;
				while (enumerator.MoveNext())
				{
					TCompared next = selector(enumerator.Current);
					if (comparer.Compare(currentMin, next) > 0)
					{
						min = enumerator.Current;
						currentMin = next;
					}
				}

				return true;
			}
		}

		public static bool TryGetMax<T, TCompared>(this IEnumerable<T> source, Func<T, TCompared> selector, out T max, IComparer<TCompared> comparer = null)
		{
			IEnumerator<T> enumerator = source.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				max = default;
				return false;
			}
			else
			{
				TCompared currentMax = selector(max = enumerator.Current);
				comparer ??= Comparer<TCompared>.Default;
				while (enumerator.MoveNext())
				{
					TCompared next = selector(enumerator.Current);
					if (comparer.Compare(currentMax, next) < 0)
					{
						max = enumerator.Current;
						currentMax = next;
					}
				}

				return true;
			}
		}
	}
}