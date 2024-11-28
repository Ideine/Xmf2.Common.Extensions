using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
	public static class DuplicatesExtensions
	{
		public static IEnumerable<T> Duplicates<T>(this IReadOnlyCollection<T> items, IEqualityComparer<T> comparer = null) => InternalDuplicates(items, comparer, items.Count);

		public static IEnumerable<T> Duplicates<T>(this IEnumerable<T> items, IEqualityComparer<T> comparer = null) => InternalDuplicates(items, comparer);

		private static IEnumerable<T> InternalDuplicates<T>(this IEnumerable<T> items, IEqualityComparer<T> comparer = null, int? capacity = null)
		{
			HashSet<T> itemSet = capacity.HasValue ? new HashSet<T>(capacity.Value, comparer) : new HashSet<T>(comparer);
			foreach (T item in items)
			{
				if (!itemSet.Add(item))
				{
					yield return item;
				}
			}
		}
	}
}