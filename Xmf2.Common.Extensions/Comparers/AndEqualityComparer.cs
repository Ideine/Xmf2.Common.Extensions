using System.Collections.Generic;
using System.Linq;

namespace Xmf2.Common.Comparers
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
			return _equalityComparers.Aggregate(0, (current, t) => current ^ t.GetHashCode(obj));
		}
	}
}
