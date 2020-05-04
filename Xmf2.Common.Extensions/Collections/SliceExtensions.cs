using System;
using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
	public static class SliceExtensions
	{
		public static IReadOnlyList<T> Slice<T>(this T[] source, int offset)
		{
			return source.Slice(offset, source.Length - offset);
		}

		public static IReadOnlyList<T> Slice<T>(this T[] source, int offset, int count)
		{
			return new ArraySegment<T>(source, offset, count);
		}

		public static IReadOnlyList<T> Slice<T>(this IReadOnlyList<T> source, int offset)
		{
			return source.Slice(offset, source.Count - offset);
		}

		public static IReadOnlyList<T> Slice<T>(this IReadOnlyList<T> source, int offset, int count)
		{
			return new ReadOnlyListSegment<T>(source, offset, count);
		}
	}
}
