using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xmf2.Common.Extensions;

namespace Xmf2.Common.Collections
{
	public static class ConvertAllExtensions
	{
		public static List<TDest> ConvertAll<TSource, TDest>(this IEnumerable<TSource> source, Func<TSource, TDest> converter)
			=> source.Select(converter).ToList();

		public static List<TOut> ConvertAll<TIn1, TIn2, TOut>(this List<Tuple<TIn1, TIn2>> list, Func<TIn1, TIn2, TOut> func)
			=> list.ConvertAll(x => x.ToArguments(func));

		public static List<TOut> ConvertAll<TIn1, TIn2, TIn3, TOut>(this List<Tuple<TIn1, TIn2, TIn3>> list, Func<TIn1, TIn2, TIn3, TOut> func)
			=> list.ConvertAll(x => x.ToArguments(func));

		public static List<TOut> ConvertAll<TIn1, TIn2, TIn3, TIn4, TOut>(this List<Tuple<TIn1, TIn2, TIn3, TIn4>> list, Func<TIn1, TIn2, TIn3, TIn4, TOut> func)
			=> list.ConvertAll(x => x.ToArguments(func));

		public static List<TOut> ConvertAll<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(this List<Tuple<TIn1, TIn2, TIn3, TIn4, TIn5>> list, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> func)
			=> list.ConvertAll(x => x.ToArguments(func));

		public static List<TOut> ConvertAll<TSource, TOut>(this IReadOnlyCollection<TSource> source, Func<TSource, int, TOut> converter)
		{
			List<TOut> result = new(capacity: source.Count);
			result.AddRange(source.Select(converter));
			return result;
		}

		public static async Task<List<TDest>> ConvertAllAsync<TSource, TDest>(this IReadOnlyList<TSource> source, Func<TSource, Task<TDest>> map)
		{
			List<TDest> result = new(source.Count);
			foreach (TSource item in source)
			{
				result.Add(await map(item));
			}

			return result;
		}

		public static async Task<List<TDest>> ConvertAllAsync<TSource, TDest>(this IReadOnlyList<TSource> source, Func<TSource, int, Task<TDest>> map)
		{
			List<TDest> result = new(source.Count);
			for (int i = 0 ; i < source.Count ; i++)
			{
				result.Add(await map(source[i], i));
			}

			return result;
		}

		public static async Task<List<TDest>> ConvertAllAsync<TSource, TDest>(this Task<List<TSource>> sourceTask, Func<TSource, Task<TDest>> map)
			=> await (await sourceTask).ConvertAllAsync(map);

		public static async Task<List<TDest>> ConvertAllAsync<TSource, TDest>(this Task<List<TSource>> sourceTask, Func<TSource, TDest> map)
			=> (await sourceTask).ConvertAll(map);

		public static async Task<List<TDest>> ConvertAllAsync<TSource, TDest>(this Task<IReadOnlyList<TSource>> sourceTask, Func<TSource, Task<TDest>> map)
			=> await (await sourceTask).ConvertAllAsync(map);

		public static async Task<List<TDest>> ConvertAllAsync<TSource, TDest>(this Task<IReadOnlyList<TSource>> sourceTask, Func<TSource, TDest> map)
			=> (await sourceTask).ConvertAll(map);

		public static async Task<List<TDest>> ConvertAllAsync<TSource, TDest>(this IEnumerable<TSource> source, Func<TSource, Task<TDest>> map)
		{
			List<TDest> result = new();
			foreach (TSource item in source)
			{
				result.Add(await map(item));
			}

			return result;
		}
	}
}