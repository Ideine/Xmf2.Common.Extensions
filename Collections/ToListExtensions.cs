using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
	public static class ToListExtensions
	{
		public static List<T> ToList<T>(this IEnumerable<T> source, int capacity)
		{
			var list = new List<T>(capacity);
			list.AddRange(source);
			return list;
		}
	}
}