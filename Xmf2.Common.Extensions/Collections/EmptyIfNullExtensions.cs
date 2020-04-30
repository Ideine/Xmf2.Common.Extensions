using System.Collections.Generic;
using System.Linq;

namespace Xmf2.Common.Collections
{
	public static class EmptyIfNullExtensions
	{
		public static IReadOnlyList<T> EmptyIfNull<T>(this IReadOnlyList<T> source)
		{
			return source ?? EmptyArray<T>.SINGLETON;
		}

		public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source)
		{
			return source ?? Enumerable.Empty<T>();
		}

		private static class EmptyArray<T>
		{
			public static readonly T[] SINGLETON = new T[0];
		}
	}
}