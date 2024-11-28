using System.Collections.Generic;
using System.Linq;

namespace Xmf2.Common.Comparers
{
	public class AndEqualityComparer<T>(params IEqualityComparer<T>[] equalityComparers) : IEqualityComparer<T>
	{
		public bool Equals(T x, T y)
		{
			return equalityComparers.All(c => c.Equals(x, y));
		}

		public int GetHashCode(T obj)
		{
			return equalityComparers.Aggregate(0, (current, t) => current ^ t.GetHashCode(obj));
		}
	}
}