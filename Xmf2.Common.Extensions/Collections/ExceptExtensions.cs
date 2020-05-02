using System;
using System.Collections.Generic;
using System.Linq;
using Xmf2.Common.Extensions;

namespace Xmf2.Common.Collections
{
	public static class ExceptExtensions
	{
		public static IEnumerable<T> Except<T, TCompared>(this IEnumerable<T> source, T element, Func<T, TCompared> comparedBy)
		{
			return Except(source, element.WrapInArray(), comparedBy, comparedBy);
		}

		public static IEnumerable<T> Except<T, TCompared>(this IEnumerable<T> source, IEnumerable<T> second, Func<T, TCompared> comparedBy)
		{
			return Except(source, second, comparedBy, comparedBy);
		}

		public static IEnumerable<TFirst> Except<TFirst, TSecond, TCompared>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TCompared> firstSelect, Func<TSecond, TCompared> secondSelect)
		{
			return Except(first, second, firstSelect, secondSelect, EqualityComparer<TCompared>.Default);
		}

		public static IEnumerable<TFirst> Except<TFirst, TSecond, TCompared>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TCompared> firstSelect, Func<TSecond, TCompared> secondSelect, IEqualityComparer<TCompared> comparer)
		{
			if (first == null)
			{
				throw new ArgumentNullException(nameof(first));
			}

			if (second == null)
			{
				throw new ArgumentNullException(nameof(second));
			}

			return ExceptIterator(first, second, firstSelect, secondSelect, comparer);
		}

		private static IEnumerable<TFirst> ExceptIterator<TFirst, TSecond, TCompared>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TCompared> firstSelect, Func<TSecond, TCompared> secondSelect, IEqualityComparer<TCompared> comparer)
		{
			var set = new HashSet<TCompared>(second.Select(secondSelect), comparer);
			foreach (TFirst tSource1 in first)
			{
				if (set.Add(firstSelect(tSource1)))
				{
					yield return tSource1;
				}
			}
		}
	}
}