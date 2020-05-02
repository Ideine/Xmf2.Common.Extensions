using System;
using System.Collections.Generic;
using System.Linq;
using Xmf2.Common.Collections;
using Xunit;

namespace Xmf2.Common.Tests.Extensions
{
	public static class CheckBunchExtensions
	{
		private delegate TSource MakeRange<TSource>(int count);
		private delegate IEnumerable<IReadOnlyList<T>> ByBunchDelegate<TSource, T>(TSource source, int bunchMaxSize);

		[Fact]
		public static void ArrayRefuseInvalidArguments()
		{
			RefuseInvalidArguments(ArrayRange(1), BunchExtensions.ByBunchOf);
		}

		[Fact]
		public static void IReadonlyListRefuseInvalidArguments()
		{
			RefuseInvalidArguments(IReadonlyListRange(1), BunchExtensions.ByBunchOf);
		}

		[Fact]
		public static void IEnumerableRefuseInvalidArguments()
		{
			RefuseInvalidArguments(IEnumerableRange(1), BunchExtensions.ByBunchOf);
		}

		private static void RefuseInvalidArguments<TSource, T>(TSource source, ByBunchDelegate<TSource, T> byBunchDelegate)
		{
			Action action = () => source.ByBunchWith(0, byBunchDelegate);
			action.ShoudThrow<ArgumentOutOfRangeException>();
		}

		[Fact]
		public static void ArrayByBunchWork()
		{
			ByBunchWork(makeTypedRange: ArrayRange, BunchExtensions.ByBunchOf);
		}

		[Fact]
		public static void IReadonlyListByBunchWork()
		{
			ByBunchWork(makeTypedRange: IReadonlyListRange, BunchExtensions.ByBunchOf);
		}

		[Fact]
		public static void IEnumerableByBunchWork()
		{
			ByBunchWork(makeTypedRange: IEnumerableRange, BunchExtensions.ByBunchOf);
		}

		private static void ByBunchWork<TSource, T>(MakeRange<TSource> makeTypedRange, ByBunchDelegate<TSource, T> byBunchDelegate)
			where TSource : IEnumerable<T>
		{
			var range = makeTypedRange(count: 7);
			var bunches = range.ByBunchWith(3, byBunchDelegate);
			Assert.Equal(range.Skip(0 * 3).Take(3), bunches.First());
			Assert.Equal(range.Skip(1 * 3).Take(3), bunches.Skip(1).First());
			Assert.Equal(range.Skip(2 * 3).Take(3), bunches.Skip(2).First());

			CheckThat(makeTypedRange(00), byBunchOf: 10, shouldMakeThisBunchNumber: 00, byBunchDelegate);
			CheckThat(makeTypedRange(20), byBunchOf: 10, shouldMakeThisBunchNumber: 02, byBunchDelegate);
			CheckThat(makeTypedRange(21), byBunchOf: 10, shouldMakeThisBunchNumber: 03, byBunchDelegate);
			CheckThat(makeTypedRange(21), byBunchOf: 01, shouldMakeThisBunchNumber: 21, byBunchDelegate);
		}

		private static void CheckThat<TSource, T>(TSource source, int byBunchOf, int shouldMakeThisBunchNumber, ByBunchDelegate<TSource, T> byBunchDelegate)
			where TSource : IEnumerable<T>
		{
			var byBunch = source.ByBunchWith(byBunchOf, byBunchDelegate);
			var rebuild = byBunch.SelectMany(bunch => bunch);
			Assert.Equal(source, rebuild);
			Assert.Equal(shouldMakeThisBunchNumber, byBunch.Count());
		}

		private static IEnumerable<int> IEnumerableRange(int count)		=> Enumerable.Range(0, count);
		private static IReadOnlyList<int> IReadonlyListRange(int count)	=> Enumerable.Range(0, count).ToList();
		private static int[] ArrayRange(int count)						=> Enumerable.Range(0, count).ToArray();

		private static IEnumerable<IReadOnlyList<T>> ByBunchWith<TSource, T>(this TSource source, int bunchMaxSize, ByBunchDelegate<TSource, T> byBunchDelegate)
			=> byBunchDelegate(source, bunchMaxSize);
	}
}
