using System.Collections.Generic;
using System.Linq;

namespace Xmf2.Common.Extensions
{
	public class AndEqualityComparer<T> : IEqualityComparer<T>
	{
		private readonly IEqualityComparer<T>[] _equalityComparers;

		public AndEqualityComparer(params IEqualityComparer<T>[] equalityComparers)
		{
			_equalityComparers = equalityComparers;
		}

		public bool Equals(T x, T y)
		{
			return _equalityComparers.All(c => c.Equals(x, y));
		}

		public int GetHashCode(T obj)
		{
			int result = 0;
			for (var i = 0; i < _equalityComparers.Length; i++)
			{
				result ^= _equalityComparers[i].GetHashCode(obj);
			}
			return result;
		}
	}
}
