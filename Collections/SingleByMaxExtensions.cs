using System;
using System.Collections.Generic;
using System.Linq;

namespace Xmf2.Common.Collections
{
	public static class SingleByMaxExtensions
	{
		public static T1 SingleByMax<T1, T2>(this IEnumerable<T1> source, Func<T1, T2> selector, IComparer<T2> pComparer = null)
		{
			var enumerator = source.Select(t => (t, selector(t))).GetEnumerator();
			(T1, T2) biggestResult = enumerator.MoveNext() ? enumerator.Current
														  : throw new InvalidOperationException("The source sequence is empty.");

			bool resultIsAmbiguous = false;
			while (enumerator.MoveNext())
			{
				var comparison = (pComparer ?? Comparer<T2>.Default).Compare(biggestResult.Item2, enumerator.Current.Item2);
				if (NextIsEqual())
				{
					resultIsAmbiguous = true;
				}
				else if (NextIsBigger())
				{
					resultIsAmbiguous = false;
					biggestResult = enumerator.Current;
				}
				bool NextIsEqual() => comparison == 0;
				bool NextIsBigger() => comparison < 0;
			}
			if (resultIsAmbiguous)
			{
				throw new InvalidOperationException("More than one element can be considered as Max element");
			}
			return biggestResult.Item1;
		}
	}
}
