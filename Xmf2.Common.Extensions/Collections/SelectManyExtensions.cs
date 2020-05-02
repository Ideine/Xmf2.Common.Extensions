using System;
using System.Collections.Generic;
using System.Linq;

namespace Xmf2.Common.Collections
{
	public static class SelectManyExtensions
	{
		public static IEnumerable<TOutput> SelectManySafe<TInput, TOutput>(this IEnumerable<TInput> source, Func<TInput, IEnumerable<TOutput>> func)
		{
			return source.SelectMany(x => func(x) ?? Enumerable.Empty<TOutput>());
		}
	}
}