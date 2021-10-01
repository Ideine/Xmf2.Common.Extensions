using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xmf2.Common.Collections
{
	public static class FirstOrDefaultExtensions
	{
		public static async Task<TElement> FirstOrDefault<TElement>(this Task<IEnumerable<TElement>> source)
		{
			return (await source).FirstOrDefault();
		}

		public static async Task<TElement> FirstOrDefault<TElement>(this Task<List<TElement>> source)
		{
			return (await source).FirstOrDefault();
		}

		/// <summary>
		/// Alternative to <see cref="Enumerable.FirstOrDefault{TSource}(System.Collections.Generic.IEnumerable{TSource})"/> in case of default value is in the list
		/// In this case impossible to know if default is from the list or if there is nothing that match predicate
		/// </summary>
		public static bool TryGetFirst<T>(this IEnumerable<T> source, out T value)
		{
			foreach (var item in source)
			{
				value = item;
				return true;
			}
			value = default;
			return false;
		}

		/// <summary>
		/// Alternative to <see cref="Enumerable.FirstOrDefault{TSource}(System.Collections.Generic.IEnumerable{TSource})"/> in case of default value is in the list
		/// In this case impossible to know if default is from the list or if there is nothing that match predicate
		/// </summary>
		public static bool TryGetFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate, out T value)
		{
			foreach (var item in source)
			{
				if (predicate(item))
				{
					value = item;
					return true;
				}
			}
			value = default;
			return false;
		}
	}
}