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
	}
}