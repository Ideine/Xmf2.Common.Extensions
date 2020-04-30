using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
	public static class NullIfEmptyExtensions
	{
		public static List<T> NullIfEmpty<T>(this List<T> source)
		{
			return source == null || source.Count == 0 ? null : source;
		}

		public static T[] NullIfEmpty<T>(this T[] source)
		{
			return source == null || source.Length == 0 ? null : source;
		}
	}
}