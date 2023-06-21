using System.Collections.Generic;
using System.Linq;
using Xmf2.Common.Collections;
using Xunit;

namespace Xmf2.Common.Tests.Collections
{
	public static class CheckDuplicatesExtensions
	{
		[Fact]
		public static void EmptyWhenNoDuplicates()
		{
			var bunch = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
			Assert.Empty(bunch.Duplicates());
		}

		[Fact]
		public static void DoFindDuplicates()
		{
			var bunch = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8,
								   1,       4,    6 };
			Assert.Contains(1, bunch.Duplicates());
			Assert.Contains(4, bunch.Duplicates());
			Assert.Contains(6, bunch.Duplicates());
		}

		[Fact]
		public static void WorksWithExplicitIComparer()
		{
			var bunch = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8,
								   1,       4,    6 };

			var intWrapped = bunch.Select(x => new IntWrapper(x));
			Assert.Empty(intWrapped.Duplicates());
			Assert.Equal(3, intWrapped.Duplicates(new IntWrapperComparer()).Count());
		}

#region Nested Type
		private class IntWrapper
		{
			public IntWrapper(int value)
			{
				Value = value;
			}
			public int Value { get; }
		}

		private class IntWrapperComparer : IEqualityComparer<IntWrapper>
		{
			public bool Equals(IntWrapper x, IntWrapper y) => x.Value == y.Value;
			public int GetHashCode(IntWrapper obj) => obj.Value.GetHashCode();
		}
#endregion Nested Type
	}
}
