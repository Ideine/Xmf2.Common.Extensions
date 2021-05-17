using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
	public static class CombinationExtensions
	{
		public static IEnumerable<T[]> GetCombinations<T>(this IReadOnlyList<T> collection, int numberInCombination)
		{
			foreach (var indexes in GetIndexesOfCombinationInternal(collection.Count, numberInCombination))
			{
				var result = new T[numberInCombination];
				for (int i = 0; i < numberInCombination; i++)
				{
					result[i] = collection[indexes[i]];
				}
				yield return result;
			}
		}

		public static IEnumerable<int[]> GetIndexesOfCombination(int nbElement, int numberInCombination)
		{
			foreach (var indexes in GetIndexesOfCombinationInternal(nbElement, numberInCombination))
			{
				int[] copy = new int[numberInCombination];
				indexes.CopyTo(copy, 0);
				yield return copy;
			}
		}

		private static IEnumerable<int[]> GetIndexesOfCombinationInternal(int nbElement, int numberInCombination)
		{
			int[] indexes = new int[numberInCombination];
			int[] indexesMax = new int[numberInCombination];
			{
				int j = numberInCombination;
				for (var i = 0 ; i < numberInCombination ; i++)
				{
					indexes[i] = i;
					indexesMax[i] = nbElement - j--;
				}
			}
			do
			{
				yield return indexes;
			} while (Increment(numberInCombination - 1));

			bool Increment(int indexToIncrement)
			{
				if (indexes[indexToIncrement] < indexesMax[indexToIncrement])
				{
					indexes[indexToIncrement]++;
					return true;
				}
				else if (indexToIncrement > 0 && Increment(indexToIncrement - 1))
				{
					indexes[indexToIncrement] = indexes[indexToIncrement - 1] + 1;
					return true;
				}
				else
				{
					return false;
				}
			}
		}
	}
}
