using System;
using System.Collections.Generic;
using System.Linq;
using Xmf2.Common.Collections;
using Xunit;

namespace Xmf2.Common.Tests.Collections
{
	public static class CheckPartitionByExtensions
	{
		[Fact]
		public static void ShouldAcceptEmptySource()
		{
			int[] source = Array.Empty<int>();
			Assert.Empty(source.Partitioned());
		}

		[Fact]
		public static void ShouldBreakOnChange()
		{
			char[] source = {'a', 'a', 'b', 'b', 'c', 'a' };
			List<IGrouping<char,char>> partition = source.Partitioned().ToList();
			Assert.Equal(4, partition.Count);

			IGrouping<char, char> groupA = partition[0];
			IGrouping<char, char> groupB = partition[1];
			IGrouping<char, char> groupC = partition[2];
			IGrouping<char, char> groupAPrime = partition[3];

			Assert.Equal('a', groupA.Key);
			Assert.Equal(new [] { 'a', 'a' }, groupA);

			Assert.Equal('b', groupB.Key);
			Assert.Equal(new [] { 'b', 'b' }, groupB);

			Assert.Equal('c', groupC.Key);
			Assert.Equal(new[] { 'c' }, groupC);

			Assert.Equal('a', groupAPrime.Key);
			Assert.Equal(new[] { 'a' }, groupAPrime);
		}
	}
}
