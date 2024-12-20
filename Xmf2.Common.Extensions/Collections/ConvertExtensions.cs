using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xmf2.Common.Collections
{
	public static class ConvertExtensions
	{
		/// <summary>
		/// Awaits tasks sequentially. See <see cref="Task.WhenAll(IEnumerable{Task})"/> for concurrent execution.
		/// </summary>
		public static async Task<List<T>> ToListAsync<T>(this IEnumerable<Task<T>> source, int? capacity = null)
		{
			List<T> result = capacity.HasValue ? new(capacity.Value) : new List<T>();
			foreach (Task<T> item in source)
			{
				result.Add(await item);
			}

			return result;
		}

		public static async Task<List<T>> ToListAsync<T>(this Task<IEnumerable<T>> source) => (await source).ToList();

		public static TOutput[] ToArray<TInput, TOutput>(this IReadOnlyList<TInput> list, Func<TInput, TOutput> selector)
		{
			TOutput[] result = new TOutput[list.Count];
			for (int i = 0 ; i < list.Count ; i++)
			{
				result[i] = selector(list[i]);
			}

			return result;
		}

		public static List<T> ToList<T>(this IEnumerable<T> source, int capacity)
		{
			List<T> list = new(capacity);
			list.AddRange(source);
			return list;
		}
	}
}