using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
	public static class RemoveExtensions
	{
		public static void RemoveRange<T>(this List<T> list, IEnumerable<T> items)
		{
			//TODO VJU : O(nm) horrible, try add a hashset or dictionary to be O(n+m)
			foreach (T item in items)
			{
				list.Remove(item);
			}
		}
	}
}