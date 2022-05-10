using System;
using System.Collections.Generic;

namespace Xmf2.Common.Collections
{
	public static class TakeExtensions
	{
#if NET6_0
		[Obsolete("Use MaxBy from Linq")]
#endif
		public static TInput TakeMax<TInput, TOutput>(this IEnumerable<TInput> source, Func<TInput, TOutput> map)
			where TOutput : IComparable<TOutput>
		{
			var init = false;
			TInput container = default;

			foreach (var input in source)
			{
				TOutput output = map(input);
				TOutput toCompare = default;
				if (!init || toCompare.CompareTo(output) < 0)
				{
					container = input;
					toCompare = output;
					init = true;
				}
			}

			return container;
		}
	}
}