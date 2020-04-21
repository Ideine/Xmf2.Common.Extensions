using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Xmf2.Common.Collections
{
	public static class EmptyIfNullExtensions
	{
		public static T[] EmptyIfNull<T>(this T[] source)
		{
			return source ?? EmptyArray<T>.Singleton;
		}

		public static IReadOnlyList<T> EmptyIfNull<T>(this IReadOnlyList<T> source)
		{
			return source ?? EmptyList<T>.Singleton;
		}

		public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source)
		{
			return source ?? Enumerable.Empty<T>();
		}

		private static class EmptyArray<T>
		{
			public static readonly T[] Singleton = new T[0];
		}

		private static class EmptyList<T>
		{
			public static readonly ReadOnlyCollection<T> Singleton = new List<T>(0).AsReadOnly();
		}
	}
}