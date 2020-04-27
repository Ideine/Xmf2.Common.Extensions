using System;
using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
	public static class SortExtensions
	{
		[Obsolete("Use SortBy.")]//Obsolete because 'Sort' method already exists on List, therefore IDE is not able to suggest to add this Extension namespace automatically wich is pain in... uhh, somewhere.
		public static List<T> Sort<T, TU>(this List<T> list, Func<T, TU> sortBySelector)
		{
			list.Sort((a, b) => Comparer<TU>.Default.Compare(sortBySelector(a), sortBySelector(b)));
			return list;
		}

		public static List<T> SortBy<T, TU>(this List<T> list, Func<T, TU> sortBySelector)
		{
			list.Sort((a, b) => Comparer<TU>.Default.Compare(sortBySelector(a), sortBySelector(b)));
			return list;
		}
	}
}