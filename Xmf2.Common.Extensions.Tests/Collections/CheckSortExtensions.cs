using System.Collections.Generic;
using Xmf2.Common.Collections;
using Xunit;

namespace Xmf2.Common.Tests.Collections
{
	public class CheckSortExtensions
	{
		[Fact]
		public static void SortByMultipleComparerWorks()
		{
			List<Foo> list = GetTestList();
			list.Sort(
				(x, y) => Comparer<int>.Default.Compare(x.SomeInt, y.SomeInt),
				(x, y) => Comparer<string>.Default.Compare(x.SomeString, y.SomeString)
			);
			Assert.Equal(
				new[] { "1a", "1b", "2a", "2b" },
				list.ToArray(x => $"{x.SomeInt}{x.SomeString}")
			);


			list = GetTestList();
			list.Sort(
				(x, y) => Comparer<string>.Default.Compare(x.SomeString, y.SomeString),
				(x, y) => Comparer<int>.Default.Compare(x.SomeInt, y.SomeInt)
			);
			Assert.Equal(
				new[] { "a1", "a2", "b1", "b2" },
				list.ToArray(x => $"{x.SomeString}{x.SomeInt}")
			);


			list = GetTestList();
			list.Sort(
				(x, y) => Comparer<int>.Default.Compare(x.SomeInt, y.SomeInt),
				(x, y) => Comparer<int>.Default.Compare(x.SomeInt, y.SomeInt)
			);
			Assert.Equal(
				new[] { "1", "1", "2", "2" },
				list.ToArray(x => $"{x.SomeInt}")
			);
		}

		[Fact]
		public static void SortByMultipleSelectorWorks()
		{
			List<Foo> list;

			list = GetTestList();
			list.Sort(x => x.SomeInt, x => x.SomeString);
			Assert.Equal(
				new[] { "1a", "1b", "2a", "2b" },
				list.ToArray(x => $"{x.SomeInt}{x.SomeString}")
			);


			list = GetTestList();
			list.Sort(x => x.SomeString, x => x.SomeInt);
			Assert.Equal(
				new[] { "a1", "a2", "b1", "b2" },
				list.ToArray(x => $"{x.SomeString}{x.SomeInt}")
			);

			list = GetTestList();
			list.Sort(x => x.SomeInt, x => x.SomeInt);
			Assert.Equal(
				new[] { "1", "1", "2", "2" },
				list.ToArray(x => $"{x.SomeInt}")
			);
		}

		private static List<Foo> GetTestList()
		{
			return new List<Foo>()
			{
				new Foo() { SomeInt = 2, SomeString = "b" },
				new Foo() { SomeInt = 1, SomeString = "a" },
				new Foo() { SomeInt = 1, SomeString = "b" },
				new Foo() { SomeInt = 2, SomeString = "a" }
			};
		}

		private class Foo
		{
			public int SomeInt { get; set; }
			public string SomeString { get; set; }
		}
	}
}
