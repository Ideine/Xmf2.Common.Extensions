using System;
using System.Collections.Generic;
using System.Linq;
using Xmf2.Common.Collections;
using Xunit;

namespace Xmf2.Common.Tests.Collections
{
	public static class CheckCombineExtensions
	{
		[Fact]
		public static void ShouldFindAllCombinations()
		{
			var set = new int [] { 0, 1, 2, 3, 4 };
			var computedCombinations2 = CombinationExtensions.GetIndexesOfCombination(set.Length, 2).Select(ToStr).ToHashSetOrDie();
			var computedCombinations3 = CombinationExtensions.GetIndexesOfCombination(set.Length, 3).Select(ToStr).ToHashSetOrDie();
			var computedCombinations4 = CombinationExtensions.GetIndexesOfCombination(set.Length, 4).Select(ToStr).ToHashSetOrDie();
			var expectedCombinations2 = new HashSet<string>()
			{
				"0,1",
				"0,2",
				"0,3",
				"0,4",
				"1,2",
				"1,3",
				"1,4",
				"2,3",
				"2,4",
				"3,4"
			};
			var expectedCombinations3 = new HashSet<string>()
			{
				"0,1,2",
				"0,1,3",
				"0,1,4",
				"0,2,3",
				"0,2,4",
				"0,3,4",
				"1,2,3",
				"1,2,4",
				"1,3,4",
				"2,3,4"
			};
			var expectedCombinations4 = new HashSet<string>()
			{
				"0,1,2,3",
				"0,1,2,4",
				"0,1,3,4",
				"0,2,3,4",
				"1,2,3,4"
			};

			Assert.Subset(expectedCombinations2, computedCombinations2);
			Assert.Subset(expectedCombinations3, computedCombinations3);
			Assert.Subset(expectedCombinations4, computedCombinations4);

			var charSet = new char[] { 'a', 'b', 'c', 'd', 'e' };
			var expectedCombinationsA = new HashSet<string>()
			{
				"a,b,c,d",
				"a,b,c,e",
				"a,b,d,e",
				"a,c,d,e",
				"b,c,d,e"
			};
			var computedCombinationsA = charSet.GetCombinations(4).Select(ToStr).ToHashSetOrDie();
			Assert.Subset(expectedCombinationsA, computedCombinationsA);
		}

		private static string ToStr(IReadOnlyList<char> x) => string.Join(',', x);
		private static string ToStr(IReadOnlyList<int> x) => string.Join(",", x.Select(x => x.ToString()));
		private static HashSet<T> ToHashSetOrDie<T>(this IEnumerable<T> enumerable)
		{
			var x = new HashSet<T>();
			foreach (var y in enumerable)
			{
				if (x.Contains(y))
				{
					throw new Exception("Duplicate");
				}
				else
				{
					x.Add(y);
				}
			}
			return x;
		}
	}
}
