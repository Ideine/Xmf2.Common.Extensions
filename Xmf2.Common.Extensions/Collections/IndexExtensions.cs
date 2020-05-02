using System;
using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
	public static class IndexExtensions
	{
		public static bool TryFindIndex<T>(this List<T> list, Predicate<T> match, out int index)
		{
			return (index = list.FindIndex(match)) != -1;
		}

		public static bool TryFindIndex<T>(this List<T> list, int startIndex, Predicate<T> match, out int index)
		{
			if (startIndex >= list.Count)
			{
				index = -1;
				return false;
			}
			else
			{
				return (index = list.FindIndex(startIndex, match)) != -1;
			}
		}

		public static bool TryFindByIndex<T>(this List<T> list, Predicate<T> match, out T found)
		{
			if (list.TryFindIndex(match, out int index))
			{
				found = list[index];
				return true;
			}
			else
			{
				found = default;
				return false;
			}
		}

		public static bool TryFindByIndex<T>(this List<T> list, int startIndex, Predicate<T> match, out T found)
		{
			if (list.TryFindIndex(startIndex, match, out int index))
			{
				found = list[index];
				return true;
			}
			else
			{
				found = default;
				return false;
			}
		}
	}
}