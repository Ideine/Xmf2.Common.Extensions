using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
	public static class DuplicatesExtensions
	{
		public static IEnumerable<T> Duplicates<T>(this IReadOnlyCollection<T> items, IEqualityComparer<T> comparer = null)
			=> InternalDuplicates(items, comparer, items.Count);

		public static IEnumerable<T> Duplicates<T>(this IEnumerable<T> items, IEqualityComparer<T> comparer = null)
			=> InternalDuplicates(items, comparer, null);

		private static IEnumerable<T> InternalDuplicates<T>(this IEnumerable<T> items, IEqualityComparer<T> comparer = null, int? capacity = null)
		{
			
#if NETSTANDARD2_0
			var itemSet = new HashSet<T>(comparer);
#else
			var itemSet = capacity.HasValue
						? new HashSet<T>(capacity.Value, comparer)
						: new HashSet<T>(comparer);
#endif
			foreach (var item in items)
			{

#if NETSTANDARD2_0
				if (itemSet.Contains(item))
				{
					yield return item;
				}
				else
				{
					itemSet.Add(item);
				}
#else
				if (!itemSet.Add(item))
				{
					yield return item;
				}
#endif
			}
		}
	}
}