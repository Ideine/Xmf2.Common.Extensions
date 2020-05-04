using System;
using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
	public static class BunchExtensions
	{
		/// <summary>
		/// Découpe un Array en sous listes.
		/// </summary>
		public static IEnumerable<IReadOnlyList<T>> ByBunchOf<T>(this T[] source, int bunchMaxSize)
		{
			if (bunchMaxSize < 1)
			{
				throw new ArgumentOutOfRangeException(nameof(bunchMaxSize));
			}
			return source.InternalByBunchOf(bunchMaxSize);
		}

		/// <summary>
		/// Découpe un IReadOnlyList en sous listes.
		/// </summary>
		public static IEnumerable<IReadOnlyList<T>> ByBunchOf<T>(this IReadOnlyList<T> source, int bunchMaxSize)
		{
			if (source is T[] arrayOfT)
			{
				return arrayOfT.ByBunchOf(bunchMaxSize);
			}
			if (bunchMaxSize < 1)
			{
				throw new ArgumentOutOfRangeException(nameof(bunchMaxSize));
			}
			return source.InternalByBunchOf(bunchMaxSize);
		}

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
			if (source is IReadOnlyList<T> readonlyList)
			{
				return readonlyList.ByBunchOf(bunchMaxSize);
			}
			if (bunchMaxSize < 1)
			{
				throw new ArgumentOutOfRangeException(nameof(bunchMaxSize));
			}
			return source.InternalByBunchOf(bunchMaxSize);
		}

		private static IEnumerable<IReadOnlyList<T>> InternalByBunchOf<T>(this T[] source, int bunchMaxSize)
		{
			for (int offset = 0 ; offset < source.Length ; offset += bunchMaxSize)
			{
				yield return offset + bunchMaxSize > source.Length
					? source.Slice(offset)
					: source.Slice(offset, bunchMaxSize);
			}
		}

		private static IEnumerable<IReadOnlyList<T>> InternalByBunchOf<T>(this IReadOnlyList<T> source, int bunchMaxSize)
		{
			for (int offset = 0 ; offset < source.Count ; offset += bunchMaxSize)
			{
				yield return offset + bunchMaxSize > source.Count
					? source.Slice(offset)
					: source.Slice(offset, bunchMaxSize);
			}
		}

		private static IEnumerable<IReadOnlyList<T>> InternalByBunchOf<T>(this IEnumerable<T> source, int bunchMaxSize)
		{
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