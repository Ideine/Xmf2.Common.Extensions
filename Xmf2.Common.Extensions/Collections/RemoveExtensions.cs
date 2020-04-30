using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
	public static class RemoveExtensions
	{
		public static void RemoveRange<T>(this List<T> list, IEnumerable<T> items)
		{
			foreach (var item in items)
			{
				list.Remove(item);
			}
		}
	}
}