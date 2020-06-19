using System;
using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
	public static class SortExtensions
	{
		public static List<T> SortBy<T, TU>(this List<T> list, Func<T, TU> sortBySelector)
		{
			list.Sort((a, b) => Comparer<TU>.Default.Compare(sortBySelector(a), sortBySelector(b)));
			return list;
		}

		public static void Sort<T>(this List<T> list, params Comparison<T>[] comparisons)
		{
			list.Sort(ByCombinedComparisons);

			int ByCombinedComparisons(T x, T y)
			{
				int result = 0;
				for (int i = 0 ; i < comparisons.Length && result == 0 ; i++)
				{
					result = comparisons[i](x, y);
				}
				return result;
			}
		}

		public static void Sort<T, TCompareA, TCompareB>(
			this List<T> list,
			Func<T, TCompareA> sortByA,
			Func<T, TCompareB> thenByB)
		{
			var comparerA = Comparer<TCompareA>.Default;
			var comparerB = Comparer<TCompareB>.Default;
			list.Sort(
				(x, y) => comparerA.Compare(sortByA(x), sortByA(y)),
				(x, y) => comparerB.Compare(thenByB(x), thenByB(y))
			);
		}

		public static void Sort<T, TCompareA, TCompareB, TCompareC>(
			this List<T> list,
			Func<T, TCompareA> sortByA,
			Func<T, TCompareB> thenByB,
			Func<T, TCompareC> thenByC)
		{
			var comparerA = Comparer<TCompareA>.Default;
			var comparerB = Comparer<TCompareB>.Default;
			var comparerC = Comparer<TCompareC>.Default;
			list.Sort(
				(x, y) => comparerA.Compare(sortByA(x), sortByA(y)),
				(x, y) => comparerB.Compare(thenByB(x), thenByB(y)),
				(x, y) => comparerC.Compare(thenByC(x), thenByC(y))
			);
		}

		public static void Sort<T, TCompareA, TCompareB, TCompareC, TCompareD>(
			this List<T> list,
			Func<T, TCompareA> sortByA,
			Func<T, TCompareB> thenByB,
			Func<T, TCompareC> thenByC,
			Func<T, TCompareD> thenByD)
		{
			var comparerA = Comparer<TCompareA>.Default;
			var comparerB = Comparer<TCompareB>.Default;
			var comparerC = Comparer<TCompareC>.Default;
			var comparerD = Comparer<TCompareD>.Default;
			list.Sort(
				(x, y) => comparerA.Compare(sortByA(x), sortByA(y)),
				(x, y) => comparerB.Compare(thenByB(x), thenByB(y)),
				(x, y) => comparerC.Compare(thenByC(x), thenByC(y)),
				(x, y) => comparerD.Compare(thenByD(x), thenByD(y))
			);
		}
	}
}