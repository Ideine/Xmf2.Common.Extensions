using System;
using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
	public static class BunchExtensions
	{

		/// <summary>
		/// Découpe un IEnumerable en sous listes.
		/// </summary>
		/// <example>
		///		var hugeEnumerable = GetSomeHugeEnumerable();
		///		DontCallThisMethodWithTooMuchElements(hugeEnumerable); //Would crash, e.g. too much memory consumption.
		///		foreach (var littleList in enumerable.ByBunchOf(bunchMaxSize: 100))
		///		{
		///			DontCallThisMethodWithTooMuchElements(littleList);//with 100 elements it's ok.
		///		}
		/// </example>
		public static IEnumerable<IReadOnlyList<T>> ByBunchOf<T>(this IEnumerable<T> source, int bunchMaxSize)
		{
			if (bunchMaxSize < 1)
			{
				throw new ArgumentOutOfRangeException(nameof(bunchMaxSize));
			}

			using IEnumerator<T> enumerator = source.GetEnumerator();
			bool moveNext, didMove;
			IReadOnlyList<T> bunch;
			do
			{
				(moveNext, didMove, bunch) = TryGetABunch(enumerator, bunchMaxSize);
				if (didMove)
				{
					yield return bunch;
				}
			} while (moveNext);
		}

		private static (bool moveNext, bool didMove, IReadOnlyList<T> bunch) TryGetABunch<T>(IEnumerator<T> enumerator, int bunchMaxSize)
		{
			var bunch = new List<T>(bunchMaxSize);
			bool didMove = false;
			bool moveNext = true;
			for (int i = 0 ; i < bunchMaxSize && (moveNext = enumerator.MoveNext()) ; i++)
			{
				bunch.Add(enumerator.Current);
				didMove = true;
			}
			return (moveNext, didMove, bunch);
		}
	}
}