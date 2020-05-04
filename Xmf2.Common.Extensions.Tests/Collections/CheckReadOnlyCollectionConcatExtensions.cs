using System.Collections.Generic;
using Xmf2.Common.Collections;
using Xunit;

namespace Xmf2.Common.Tests.Collections
{
	public static class CheckReadOnlyCollectionConcatExtensions
	{
		[Fact]
		public static void ShouldConcat()
		{
			IReadOnlyList<int> a = new int[] { };
			IReadOnlyList<int> b = new int[] { 0, 1, 2 };
			CheckAssertions(onEnum: a.Concat(b));

			a = new int[] { 0};
			b = new int[] { 1, 2 };
			CheckAssertions(onEnum: a.Concat(b));

			a = new int[] { 0, 1 };
			b = new int[] { 2 };
			CheckAssertions(onEnum: a.Concat(b));

			a = new int[] { 0, 1, 2 };
			b = new int[] { };
			CheckAssertions(onEnum: a.Concat(b));

			void CheckAssertions(IReadOnlyList<int> onEnum)
			{
				//Check indexer
				for (int i = 0 ; i < 3 ; i++)
				{
					Assert.Equal(i, onEnum[i]);
				}

				//Check count
				Assert.Equal(3, onEnum.Count);

				//Check sequence
				Assert.Equal(new int[] { 0, 1, 2 }, onEnum);

				//Check enumerator
				int j = 0;
				foreach (var item in onEnum)
				{
					Assert.Equal(j++, item);
				}
			}
		}
	}
}
