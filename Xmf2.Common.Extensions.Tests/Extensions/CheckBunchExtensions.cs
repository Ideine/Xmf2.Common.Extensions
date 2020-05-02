using System.Collections.Generic;
using System.Linq;
using Xmf2.Common.Collections;
using Xunit;

namespace Xmf2.Common.Tests.Extensions
{
	public static class CheckBunchExtensions
	{
		[Fact]
		public static void ArrayByBunchWork()
		{
			ByBunchWork(ArrayRange, BunchExtensions.ByBunchOf);
		}

		[Fact]
		public static void IReadonlyListByBunchWork()
		{
			ByBunchWork(IReadonlyListRange, BunchExtensions.ByBunchOf);
		}

		[Fact]
		public static void IEnumerableByBunchWork()
		{
			ByBunchWork(IEnumerableRange, BunchExtensions.ByBunchOf);
		}

		private static IEnumerable<int> IEnumerableRange(int count) => Enumerable.Range(0, count);
		private static IReadOnlyList<int> IReadonlyListRange(int count) => Enumerable.Range(0, count).ToList();
		private static int[] ArrayRange(int count) => Enumerable.Range(0, count).ToArray();

		private static void ByBunchWork<TSource, T>(MakeRange<TSource> makeRange, ByBunchDelegate<TSource, T> byBunchDelegate)
			where TSource : IEnumerable<T>
		{
			var range = makeRange(count: 7);
			var bunches = range.ByBunchWith(3, byBunchDelegate);
			Assert.Equal(range.Skip(0 * 3).Take(3), bunches.First());
			Assert.Equal(range.Skip(1 * 3).Take(3), bunches.Skip(1).First());
			Assert.Equal(range.Skip(2 * 3).Take(3), bunches.Skip(2).First());

			CheckThat(makeRange(00), byBunchOf: 10, shouldMakeThisBunchNumber: 00, byBunchDelegate);
			CheckThat(makeRange(20), byBunchOf: 10, shouldMakeThisBunchNumber: 02, byBunchDelegate);
			CheckThat(makeRange(21), byBunchOf: 10, shouldMakeThisBunchNumber: 03, byBunchDelegate);
			CheckThat(makeRange(21), byBunchOf: 01, shouldMakeThisBunchNumber: 21, byBunchDelegate);
		}

		private delegate TSource MakeRange<TSource>(int count);
		private delegate IEnumerable<IReadOnlyList<T>> ByBunchDelegate<TSource, T>(TSource source, int bunchMaxSize);

		private static void CheckThat<TSource, T>(TSource source, int byBunchOf, int shouldMakeThisBunchNumber, ByBunchDelegate<TSource, T> byBunchDelegate)
			where TSource : IEnumerable<T>
		{
			var byBunch = source.ByBunchWith(byBunchOf, byBunchDelegate);
			var rebuild = byBunch.SelectMany(bunch => bunch);
			Assert.Equal(source, rebuild);
			Assert.Equal(shouldMakeThisBunchNumber, byBunch.Count());
		}

		private static IEnumerable<IReadOnlyList<T>> ByBunchWith<TSource, T>(this TSource source, int bunchMaxSize, ByBunchDelegate<TSource, T> byBunchDelegate)
		{
			return byBunchDelegate(source, bunchMaxSize);
		}
	}
}
