using System;
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
			char[] source = {
				'a', 'a',
				'b', 'b',
				'c',
				'a' };
			Assert.Equal(4, source.Partitioned().Count());

			IGrouping<char, char> groupA		= source.Partitioned().Skip(0).First();
			IGrouping<char, char> groupB		= source.Partitioned().Skip(1).First();
			IGrouping<char, char> groupC		= source.Partitioned().Skip(2).First();
			IGrouping<char, char> groupAPrime = source.Partitioned().Skip(3).First();

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
