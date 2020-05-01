using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Xmf2.Common.Collections
{
	public static class SliceExtensions
	{
		public static IReadOnlyList<T> Slice<T>(this T[] source, int offset)
		{
			return source.Slice(offset, source.Length - offset);
		}

		public static IReadOnlyList<T> Slice<T>(this T[] source, int offset, int count)
		{
			return new ArraySegment<T>(source, offset, count);
		}

		public static IReadOnlyList<T> Slice<T>(this IReadOnlyList<T> source, int offset)
		{
			return source.Slice(offset, source.Count - offset);
		}

		public static IReadOnlyList<T> Slice<T>(this IReadOnlyList<T> source, int offset, int count)
		{
			return new ReadOnlyListSegment<T>(source, offset, count);
		}

		private readonly struct ReadOnlyListSegment<T> : IReadOnlyList<T>
		{
			private readonly IReadOnlyList<T> _source;
			private readonly int _offset;
			public readonly int Count { get; }

			public ReadOnlyListSegment(IReadOnlyList<T> source, int offset, int count)
			{
				if (source is null)
				{
					throw new ArgumentNullException(nameof(source));
				}
				if (offset < 0)
				{
					throw new ArgumentOutOfRangeException(nameof(offset));
				}
				if (count < 0)
				{
					throw new ArgumentOutOfRangeException(nameof(count));
				}
				if (offset + count > source.Count)
				{
					throw new ArgumentException($"{nameof(offset)} and {nameof(count)} where out of bound of {nameof(source)}");
				}
				_source = source;
				_offset = offset;
				Count = count;
			}

			public T this[int index]
			{
				get
				{
					if (index < 0)
					{
						throw new ArgumentOutOfRangeException(nameof(index));
					}
					if (index >= Count)
					{
						throw new ArgumentOutOfRangeException(nameof(index));
					}
					return _source[_offset + index];
				}
			}

			public IEnumerator<T> GetEnumerator() => _source.Skip(_offset).Take(Count).GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator() => _source.Skip(_offset).Take(Count).GetEnumerator();
		}
	}
}
