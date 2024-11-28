using System;
using System.Collections.Generic;
using Xmf2.Common.Extensions;

namespace Xmf2.Common.Collections
{
	public static class SortExtensions
	{
		public static List<T> SortBy<T, TU>(this List<T> list, Func<T, TU> sortBySelector)
		{
			list.Sort((a, b) => Comparer<TU>.Default.Compare(sortBySelector(a), sortBySelector(b)));
			return list;
		}

		public static List<T> SortByDesc<T, TU>(this List<T> list, Func<T, TU> sortBySelector)
		{
			list.Sort((a, b) => Comparer<TU>.Default.Compare(sortBySelector(b), sortBySelector(a)));
			return list;
		}

		public static void Sort<T>(this List<T> list, params Comparison<T>[] comparisons)
		{
			list.Sort(comparisons.Combine());
		}

		public static void Sort<T, TCompareA, TCompareB>(
			this List<T> list,
			Func<T, TCompareA> sortByA,
			Func<T, TCompareB> thenByB)
		{
			Comparer<TCompareA> comparerA = Comparer<TCompareA>.Default;
			Comparer<TCompareB> comparerB = Comparer<TCompareB>.Default;
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
			Comparer<TCompareA> comparerA = Comparer<TCompareA>.Default;
			Comparer<TCompareB> comparerB = Comparer<TCompareB>.Default;
			Comparer<TCompareC> comparerC = Comparer<TCompareC>.Default;
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
			Comparer<TCompareA> comparerA = Comparer<TCompareA>.Default;
			Comparer<TCompareB> comparerB = Comparer<TCompareB>.Default;
			Comparer<TCompareC> comparerC = Comparer<TCompareC>.Default;
			Comparer<TCompareD> comparerD = Comparer<TCompareD>.Default;
			list.Sort(
				(x, y) => comparerA.Compare(sortByA(x), sortByA(y)),
				(x, y) => comparerB.Compare(thenByB(x), thenByB(y)),
				(x, y) => comparerC.Compare(thenByC(x), thenByC(y)),
				(x, y) => comparerD.Compare(thenByD(x), thenByD(y))
			);
		}
	}
}