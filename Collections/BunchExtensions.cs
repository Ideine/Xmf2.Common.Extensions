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
		public static IEnumerable<List<T>> ByBunchOf<T>(this IEnumerable<T> source, int bunchMaxSize)
		{
			using IEnumerator<T> enumerator = source.GetEnumerator();
			bool moveNext = true;
			while (moveNext)
			{
				yield return GetABunch();
			}

			List<T> GetABunch()
			{
				var bunch = new List<T>(bunchMaxSize);
				for (int i = 0 ; i < bunchMaxSize && (moveNext = enumerator.MoveNext()) ; i++)
				{
					bunch.Add(enumerator.Current);
				}

				return bunch;
			}
		}
	}
}