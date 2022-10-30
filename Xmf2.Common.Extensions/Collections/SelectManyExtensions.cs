using System;
using System.Collections.Generic;
using System.Linq;

namespace Xmf2.Common.Collections
{
	public static class SelectManyExtensions
	{
		/// <summary>
		/// Add a protection to selector, if the return is null we replace it with an empty enumerable to prevent crash of classic SelectMany
		/// </summary>
		public static IEnumerable<TOutput> SelectManySafe<TInput, TOutput>(this IEnumerable<TInput> source, Func<TInput, IEnumerable<TOutput>> selector)
		{
			return source.SelectMany(x => selector(x) ?? Enumerable.Empty<TOutput>());
		}
	}
}