using System;
using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
#if NET6_0
	[Obsolete("Use Take with sequence")]
#endif
	public static class SliceExtensions
	{
		public static IReadOnlyList<T> Slice<T>(this T[] source, int offset) => source.Slice(offset, source.Length - offset);

		public static IReadOnlyList<T> Slice<T>(this T[] source, int offset, int count) => new ArraySegment<T>(source, offset, count);

		public static IReadOnlyList<T> Slice<T>(this IReadOnlyList<T> source, int offset) => source.Slice(offset, source.Count - offset);

		public static IReadOnlyList<T> Slice<T>(this IReadOnlyList<T> source, int offset, int count) => new ReadOnlyListSegment<T>(source, offset, count);
	}
}