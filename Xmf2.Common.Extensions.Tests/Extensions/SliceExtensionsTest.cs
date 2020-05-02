using System;
using System.Collections.Generic;
using System.Linq;
using Xmf2.Common.Collections;
using Xunit;

namespace Xmf2.Common.Tests
{
	public static class CheckSliceExtensions
	{
		[Fact]
		public static void ArraySliceShouldRefuseInvalidArguments()
		{
			int[] nullSource = null;
			int[] validSource = new int[1];
			SliceShouldRefuseInvalidArguments(nullSource, validSource, SliceExtensions.Slice);
		}

		[Fact]
		public static void ReadOnlyListSliceShouldRefuseInvalidArguments()
		{
			IReadOnlyList<int> nullSource = null;
			IReadOnlyList<int> validSource = new int[1];
			SliceShouldRefuseInvalidArguments(nullSource, validSource, SliceExtensions.Slice);
		}

		private static void SliceShouldRefuseInvalidArguments<TSource, T>(TSource nullSource, TSource validSource, SliceDelegateB<TSource, T> sliceDelegate)
		{
			Action action;

			//Test argument: source
			action = () => nullSource.SliceWith(0, 0, sliceDelegate);
			action.ShoudThrow<ArgumentNullException>();

			//Test argument: startOffset
			action = () => validSource.SliceWith(offset: -1, count: 0, sliceDelegate);
			action.ShoudThrow<ArgumentOutOfRangeException>();

			action = () => validSource.SliceWith(offset: 2, count: 0, sliceDelegate);
			action.ShoudThrow<ArgumentException>();

			//Test argument: count
			action = () => validSource.SliceWith(offset: 0, count: -1, sliceDelegate);
			action.ShoudThrow<ArgumentOutOfRangeException>();

			action = () => validSource.SliceWith(offset: 0, count: 2, sliceDelegate);
			action.ShoudThrow<ArgumentException>();
		}

		[Fact]
		public static void ArrayIndexorShouldRefuseInvalidArguments()
		{
			int[] source = new int[3];
			SliceIndexorShouldRefuseInvalidArguments(source, SliceExtensions.Slice);
		}

		[Fact]
		public static void ReadOnlyListSliceIndexorShouldRefuseInvalidArguments()
		{
			IReadOnlyList<int> source = new List<int>() { default, default, default };
			SliceIndexorShouldRefuseInvalidArguments(source, SliceExtensions.Slice);
		}

		private static void SliceIndexorShouldRefuseInvalidArguments<TSource, T>(TSource source, SliceDelegateB<TSource, T> sliceDelegate)
		{
			var slice = source.SliceWith(1, 1, sliceDelegate);
			Action action;

			//Test indexor
			action = () => _ = slice[-1];
			action.ShoudThrow<ArgumentOutOfRangeException>();

			action = () => _ = slice[1];
			action.ShoudThrow<ArgumentOutOfRangeException>();
		}

		[Fact]
		public static void ArraySliceIndexorShouldWork()
		{
			char[] abc = "abc".ToCharArray();
			IndexorShouldWork(abc, SliceExtensions.Slice);
		}

		[Fact]
		public static void ReadOnlyListSliceIndexorShouldWork()
		{
			IReadOnlyList<char> abc = new List<char>("abc");
			IndexorShouldWork(abc, SliceExtensions.Slice);
		}

		private static void IndexorShouldWork<TSource>(TSource abc, SliceDelegateA<TSource, char> sliceDelegate)
		{
			Assert.Equal('a', abc.SliceWith(offset: 0, sliceDelegate)[0]);
			Assert.Equal('b', abc.SliceWith(offset: 0, sliceDelegate)[1]);
			Assert.Equal('c', abc.SliceWith(offset: 0, sliceDelegate)[2]);

			Assert.Equal('b', abc.SliceWith(offset: 1, sliceDelegate)[0]);
			Assert.Equal('c', abc.SliceWith(offset: 1, sliceDelegate)[1]);

			Assert.Equal('c', abc.SliceWith(offset: 2, sliceDelegate)[0]);
		}

		[Fact]
		public static void ArrayCountShouldWork()
		{
			var abc = "abc".ToCharArray();
			CountShoulWork(abc, SliceExtensions.Slice, SliceExtensions.Slice);
		}

		[Fact]
		public static void ReadOnlyListCountShouldWork()
		{
			IReadOnlyList<char> abc = new List<char>("abc");
			CountShoulWork(abc, SliceExtensions.Slice, SliceExtensions.Slice);
		}

		private static void CountShoulWork<TSource, T>(TSource abc, SliceDelegateA<TSource, T> sliceDelegateA, SliceDelegateB<TSource, T> sliceDelegateB)
		{
			Assert.Equal(3, abc.SliceWith(offset: 0, sliceDelegateA).Count);
			Assert.Equal(2, abc.SliceWith(offset: 1, sliceDelegateA).Count);
			Assert.Equal(1, abc.SliceWith(offset: 2, sliceDelegateA).Count);
			Assert.Equal(0, abc.SliceWith(offset: 3, sliceDelegateA).Count);

			Assert.Equal(3, abc.SliceWith(offset: 0, count:3, sliceDelegateB).Count);
			Assert.Equal(2, abc.SliceWith(offset: 0, count:2, sliceDelegateB).Count);
			Assert.Equal(1, abc.SliceWith(offset: 0, count:1, sliceDelegateB).Count);
			Assert.Equal(0, abc.SliceWith(offset: 0, count:0, sliceDelegateB).Count);
		}

		[Fact]
		public static void ArrayGetEnumeratorShouldWork()
		{
			char[] source = "abc".ToCharArray();
			GetEnumeratorShouldWork(source, SliceExtensions.Slice);
		}

		[Fact]
		public static void ReadOnlyListGetEnumeratorShouldWork()
		{
			IReadOnlyList<char> source = new List<char>("abc");
			GetEnumeratorShouldWork(source, SliceExtensions.Slice);
		}

		private static void GetEnumeratorShouldWork<TSource>(TSource abc, SliceDelegateB<TSource, char> sliceDelegateB)
		{
			Assert.Equal(""  , new string(abc.SliceWith(0, 0, sliceDelegateB).ToArray()));
			Assert.Equal("a" , new string(abc.SliceWith(0, 1, sliceDelegateB).ToArray()));
			Assert.Equal("ab", new string(abc.SliceWith(0, 2, sliceDelegateB).ToArray()));
			Assert.Equal("bc", new string(abc.SliceWith(1, 2, sliceDelegateB).ToArray()));
			Assert.Equal("c" , new string(abc.SliceWith(2, 1, sliceDelegateB).ToArray()));
			Assert.Equal(""  , new string(abc.SliceWith(3, 0, sliceDelegateB).ToArray()));
		}

		private delegate IReadOnlyList<T> SliceDelegateA<TSource, T>(TSource source, int offset);
		private delegate IReadOnlyList<T> SliceDelegateB<TSource, T>(TSource source, int offset, int count);

		private static IReadOnlyList<T> SliceWith<TSource, T>(this TSource source, int offset, SliceDelegateA<TSource, T> sliceDelegate)
		{
			return sliceDelegate(source, offset);
		}
		private static IReadOnlyList<T> SliceWith<TSource, T>(this TSource source, int offset, int count, SliceDelegateB<TSource, T> sliceDelegate)
		{
			return sliceDelegate(source, offset, count);
		}
	}
}
