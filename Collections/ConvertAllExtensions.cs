using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xmf2.Common.Collections
{
	public static class ConvertAllExtensions
	{
		public static List<TDest> ConvertAll<TSource, TDest>(this IEnumerable<TSource> source, Func<TSource, TDest> converter)
			=> source.Select(converter).ToList();

		public static List<TOut> ConvertAll<TIn1, TIn2, TOut>(this List<Tuple<TIn1, TIn2>> list, Func<TIn1, TIn2, TOut> func)
			=> list.ConvertAll(x => func(x.Item1, x.Item2));

		public static List<TOut> ConvertAll<TIn1, TIn2, TIn3, TOut>(this List<Tuple<TIn1, TIn2, TIn3>> list, Func<TIn1, TIn2, TIn3, TOut> func)
			=> list.ConvertAll(x => func(x.Item1, x.Item2, x.Item3));

		public static List<TOut> ConvertAll<TIn1, TIn2, TIn3, TIn4, TOut>(this List<Tuple<TIn1, TIn2, TIn3, TIn4>> list, Func<TIn1, TIn2, TIn3, TIn4, TOut> func)
			=> list.ConvertAll(x => func(x.Item1, x.Item2, x.Item3, x.Item4));

		public static List<TOut> ConvertAll<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(this List<Tuple<TIn1, TIn2, TIn3, TIn4, TIn5>> list, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> func) => list.ConvertAll(x => func(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5));

		public static async Task<List<TDest>> ConvertAllAsync<TSource, TDest>(this IReadOnlyList<TSource> source, Func<TSource, Task<TDest>> map)
		{
			var result = new List<TDest>(source.Count);
			foreach (TSource item in source)
			{
				result.Add(await map(item));
			}

			return result;
		}

		public static async Task<List<TDest>> ConvertAllAsync<TSource, TDest>(this IReadOnlyList<TSource> source, Func<TSource, int, Task<TDest>> map)
		{
			var result = new List<TDest>(source.Count);
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
			var result = new List<TDest>();
			foreach (TSource item in source)
			{
				result.Add(await map(item));
			}

			return result;
		}
	}
}