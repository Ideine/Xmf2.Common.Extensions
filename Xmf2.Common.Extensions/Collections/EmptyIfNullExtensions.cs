using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
	public static class EmptyIfNullExtensions
	{
		public static IReadOnlyList<T> EmptyIfNull<T>(this IReadOnlyList<T> source)
		{
			return source ?? [];
		}

		public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source)
		{
			return source ?? [];
		}
	}
}