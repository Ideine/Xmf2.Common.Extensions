using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Xmf2.Common.Collections
{
	public static class PartitionByExtensions
	{
		/// <summary>
		/// Regroupe les items d'un IEnumerable ayant consécutivement la même valeur.
		/// </summary>
		public static IEnumerable<IGrouping<T, T>> Partitioned<T>(this IEnumerable<T> source) => source.PartitionBy(x => x);

		/// <summary>
		/// Regroupe les items d'un IEnumerable ayant consécutivement la même valeur.
		/// </summary>
		/// <example> <code>
		///		//Compare results of PartitionBy vs GroupBy
		///
		///		string values = "HELlO WORLD";
		///		foreach (var group in values.PartitionBy(char.ToLower).Where(x => x.Key == 'l' || x.Key == 'o'))
		///			Console.WriteLine($"{group.Key} {group.Count()}");
		///		// Output :
		///		// l 2
		///		// o 1
		///		// o 1
		///		// l 1
		///
		///		foreach (var group in values.GroupBy(char.ToLower).Where(x => x.Key == 'l' || x.Key == 'o'))
		///			Console.WriteLine($"{group.Key} {group.Count()}");
		///		// Output :
		///		// l 3
		///		// o 2
		/// </code></example>
		public static IEnumerable<IGrouping<TKey, TElement>> PartitionBy<TElement, TKey>(this IEnumerable<TElement> source, Func<TElement, TKey> selector)
		{
			using IEnumerator<TElement> enumerator = source.GetEnumerator();
			bool moveNext = enumerator.MoveNext();
			EqualityComparer<TKey> equalityComparer = moveNext ? EqualityComparer<TKey>.Default : null;
			while (moveNext)
			{
				TKey partitionKey = selector(enumerator.Current);
				yield return new PartitionGroup<TKey, TElement>(partitionKey, GetPartition(partitionKey).ToList());
			}

			IEnumerable<TElement> GetPartition(TKey key)
			{
				bool firstOfSeries = true;
				bool sameSeries = true;
				do
				{
					TElement current = enumerator.Current;
					if (firstOfSeries || equalityComparer.Equals(key, selector(current)))
					{
						yield return current;
						firstOfSeries = false;
						moveNext = enumerator.MoveNext();
					}
					else
					{
						sameSeries = false;
					}
				} while (moveNext && sameSeries);
			}
		}

		private class PartitionGroup<TKey, TElement> : IGrouping<TKey, TElement>
		{
			private readonly List<TElement> _elements;

			public TKey Key { get; }

			public PartitionGroup(TKey key, List<TElement> elements)
			{
				Key = key;
				_elements = elements;
			}

			public IEnumerator<TElement> GetEnumerator() => _elements.GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator() => _elements.GetEnumerator();
		}
	}
}