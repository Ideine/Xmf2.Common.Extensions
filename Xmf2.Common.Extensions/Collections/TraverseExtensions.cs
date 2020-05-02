using System;
using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
	public static class TraverseExtensions
	{
		public static IEnumerable<T> Traverse<T>(this T v, Func<T, IEnumerable<T>> bySelector)
		{
			yield return v;
			foreach (var selected in bySelector(v))
			{
				foreach (var subSelected in selected.Traverse(bySelector))
				{
					yield return subSelected;
				}
			}
		}
		public static IEnumerable<T> Traverse<T>(this T v, Func<T, T> bySelector)
		{
			T nextNode = v;
			while (nextNode != null)
			{
				yield return nextNode;
				nextNode = bySelector(nextNode);
			}
		}
	}
}