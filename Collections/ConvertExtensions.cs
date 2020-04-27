using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xmf2.Common.Collections
{
	public static class ConvertExtensions
	{
		public static async Task<List<T>> ToListAsync<T>(this Task<IEnumerable<T>> source) => (await source).ToList();

		public static TOutput[] ToArray<TInput, TOutput>(this IReadOnlyList<TInput> list, Func<TInput, TOutput> selector)
		{
			var result = new TOutput[list.Count];
			for (int i = 0 ; i < list.Count ; i++)
			{
				result[i] = selector(list[i]);
			}

			return result;
		}

		public static List<T> ToList<T>(this IEnumerable<T> source, int capacity)
		{
			var list = new List<T>(capacity);
			list.AddRange(source);
			return list;
		}
	}
}