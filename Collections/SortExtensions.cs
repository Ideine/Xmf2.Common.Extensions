using System;
using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
	public static class SortExtensions
	{
		public static List<T> Sort<T, TU>(this List<T> list, Func<T, TU> sortBy)
		{
			list.Sort((a, b) => Comparer<TU>.Default.Compare(sortBy(a), sortBy(b)));
			return list;
		}
	}
}