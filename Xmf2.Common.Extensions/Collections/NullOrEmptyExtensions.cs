using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Xmf2.Common.Collections
{
	public static class NullOrEmptyExtensions
	{
		public static bool NotNullOrEmpty<T>([NotNullWhen(true)] this ICollection<T> source)
		{
			return source?.Count > 0;
		}

		public static bool NotNullOrEmpty<T>([NotNullWhen(true)] this T[] source)
		{
			return source?.Length > 0;
		}

		public static bool NotNullOrEmpty<T>([NotNullWhen(true)] this IEnumerable<T> source)
		{
			return source?.Any() ?? false;
		}

		public static bool IsNullOrEmpty<T>([NotNullWhen(false)] this IEnumerable<T> source)
		{
			return source == null || !source.Any();
		}

		public static bool IsNullOrEmpty<T>([NotNullWhen(false)] this IReadOnlyCollection<T> source)
		{
			return source == null || source.Count == 0;
		}
	}
}