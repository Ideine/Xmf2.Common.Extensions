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
			var source = new int[0];
			Assert.Equal(0, source.Partitioned().Count());
		}

		[Fact]
		public static void ShouldBreakOnChange()
		{
			var source = new char[] {
				'a', 'a',
				'b', 'b',
				'c',
				'a' };
			Assert.Equal(4, source.Partitioned().Count());

			var groupA		= source.Partitioned().Skip(0).First();
			var groupB		= source.Partitioned().Skip(1).First();
			var groupC		= source.Partitioned().Skip(2).First();
			var groupAPrime = source.Partitioned().Skip(3).First();

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
