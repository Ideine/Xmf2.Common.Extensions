using System;
using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
	public static class TryGetMinExtensions
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
	}
}
