using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Xmf2.Common.Collections
{
	public static class ReadOnlyCollectionConcatExtensions
	{
		public static IReadOnlyList<T> Concat<T>(this IReadOnlyList<T> collectionA, IReadOnlyList<T> collectionB)
			=> new ReadOnlyListConcat<T>(collectionA, collectionB);

		public static IReadOnlyCollection<T> Concat<T>(this IReadOnlyCollection<T> collectionA, IReadOnlyCollection<T> collectionB)
			=> new ReadOnlyCollectionConcat<IReadOnlyCollection<T>, T>(collectionA, collectionB);

		private class ReadOnlyListConcat<T> : ReadOnlyCollectionConcat<IReadOnlyList<T>, T>, IReadOnlyList<T>
		{
			public ReadOnlyListConcat(IReadOnlyList<T> collectionA, IReadOnlyList<T> collectionB) : base(collectionA, collectionB) { }

			public T this[int index] => index < CollectionA.Count ? CollectionA[index] : CollectionB[index - CollectionA.Count];
		}

		private class ReadOnlyCollectionConcat<TCol, T> : IReadOnlyCollection<T>
			where TCol : IReadOnlyCollection<T>
		{
			protected readonly TCol CollectionA;
			protected readonly TCol CollectionB;

			public ReadOnlyCollectionConcat(TCol collectionA, TCol collectionB)
			{
				CollectionA = collectionA;
				CollectionB = collectionB;
			}

			public int Count => CollectionA.Count + CollectionB.Count;

			public IEnumerator<T> GetEnumerator() => Enumerable.Concat(CollectionA, CollectionB).GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}
	}
}