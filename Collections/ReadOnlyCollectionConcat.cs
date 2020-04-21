using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Xmf2.Common.Collections
{
	public static class ReadOnlyCollectionConcatExtensions
	{
		public static IReadOnlyCollection<T> Concat<T>(this IReadOnlyCollection<T> collectionA, IReadOnlyCollection<T> collectionB)
			=> new ReadOnlyCollectionConcat<T>(collectionA, collectionB);

		private class ReadOnlyCollectionConcat<T> : IReadOnlyCollection<T>
		{
			private readonly IReadOnlyCollection<T> _collectionA;
			private readonly IReadOnlyCollection<T> _collectionB;

			public ReadOnlyCollectionConcat(IReadOnlyCollection<T> collectionA, IReadOnlyCollection<T> collectionB)
			{
				_collectionA = collectionA;
				_collectionB = collectionB;
			}

			public int Count => _collectionA.Count + _collectionB.Count;

			public IEnumerator<T> GetEnumerator() => Enumerable.Concat(_collectionA, _collectionB).GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}
	}
}