using System;
using System.Collections.Generic;
using System.Linq;

namespace Xmf2.Common.Collections
{
	public static class DiffExtensions
	{
		public static DiffResult<T> Diff<T>(this IEnumerable<T> firstSet, IEnumerable<T> secondSet, IEqualityComparer<T> equalityComparer = null)
		{
			return new DiffResult<T>(firstSet, secondSet, equalityComparer);
		}

		public static DiffResult<T, T, TKey> Diff<T, TKey>(this IEnumerable<T> firstSet, IEnumerable<T> secondSet, Func<T, TKey> keySelector, IEqualityComparer<TKey> keyComparer = null)
		{
			return new DiffResult<T, T, TKey>(firstSet, secondSet, keySelector, keySelector, keyComparer);
		}

		public static DiffResult<TFirst, TSecond, TKey> Diff<TFirst, TSecond, TKey>(this IEnumerable<TFirst> firstSet, IEnumerable<TSecond> secondSet, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, IEqualityComparer<TKey> keyComparer = null)
		{
			return new DiffResult<TFirst, TSecond, TKey>(firstSet, secondSet, firstKeySelector, secondKeySelector, keyComparer);
		}
	}

	public interface IDiffResult<out TFirst, out TSecond> : IDisposable
	{
		IEnumerable<TFirst> FirstSet { get; }
		IEnumerable<TSecond> SecondSet { get; }
		IEnumerable<TFirst> OnlyInFirstSet { get; }
		IEnumerable<TSecond> OnlyInSecondSet { get; }
		IEnumerable<TFirst> InBothFromFirst { get; }
		IEnumerable<TSecond> InBothFromSecond { get; }
	}

	public class DiffResult<T> : IDiffResult<T, T>
	{
		private HashSet<T> _firstSet;
		private HashSet<T> _secondSet;
		private readonly IEqualityComparer<T> _equalityComparer;

		public DiffResult(IEnumerable<T> firstSet, IEnumerable<T> secondSet, IEqualityComparer<T> equalityComparer = null)
		{
			_equalityComparer = equalityComparer ?? EqualityComparer<T>.Default;
			_firstSet = new HashSet<T>(firstSet, _equalityComparer);
			_secondSet = new HashSet<T>(secondSet, _equalityComparer);
		}

		public IEnumerable<T> FirstSet => _firstSet;
		public IEnumerable<T> SecondSet => _secondSet;
		public IEnumerable<T> OnlyInFirstSet => _firstSet.Where(x => !_secondSet.Contains(x, _equalityComparer));
		public IEnumerable<T> OnlyInSecondSet => _secondSet.Where(x => !_firstSet.Contains(x, _equalityComparer));
		public IEnumerable<T> InBothFromFirst => _firstSet.Where(x => _secondSet.Contains(x, _equalityComparer));
		public IEnumerable<T> InBothFromSecond => _secondSet.Where(x => _firstSet.Contains(x, _equalityComparer));

		#region IDisposable Support

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				_firstSet = null;
				_secondSet = null;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}

		#endregion
	}

	public class DiffResult<TFirst, TSecond, TKey> : IDiffResult<TFirst, TSecond>
	{
		private Dictionary<TKey, TFirst> _firstDictionary;
		private Dictionary<TKey, TSecond> _secondDictionary;

		public DiffResult(IEnumerable<TFirst> firstSet, IEnumerable<TSecond> secondSet, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, IEqualityComparer<TKey> keyComparer = null)
		{
			IEqualityComparer<TKey> notNullKeyComparer = keyComparer ?? EqualityComparer<TKey>.Default;
			_firstDictionary = firstSet.ToDictionary(firstKeySelector, notNullKeyComparer);
			_secondDictionary = secondSet.ToDictionary(secondKeySelector, notNullKeyComparer);
		}

		public IEnumerable<TFirst> OnlyInFirstSet => _firstDictionary.Where(kvp => !_secondDictionary.ContainsKey(kvp.Key)).Select(kvp => kvp.Value);
		public IEnumerable<TSecond> OnlyInSecondSet => _secondDictionary.Where(kvp => !_firstDictionary.ContainsKey(kvp.Key)).Select(kvp => kvp.Value);
		public IEnumerable<TFirst> InBothFromFirst => _firstDictionary.Where(kvp => _secondDictionary.ContainsKey(kvp.Key)).Select(kvp => kvp.Value);
		public IEnumerable<TSecond> InBothFromSecond => _secondDictionary.Where(kvp => _firstDictionary.ContainsKey(kvp.Key)).Select(kvp => kvp.Value);

		public IEnumerable<(TKey key, TFirst firstItem, TSecond secondItem)> InBoth
		{
			get
			{
				foreach (var firstEntry in _firstDictionary)
				{
					if (_secondDictionary.TryGetValue(firstEntry.Key, out var secondEntry))
					{
						yield return (firstEntry.Key, firstEntry.Value, secondEntry);
					}
				}
			}
		}

		public IEnumerable<TFirst> FirstSet => _firstDictionary.Values;
		public IEnumerable<TSecond> SecondSet => _secondDictionary.Values;

		#region IDisposable Support

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				_firstDictionary = null;
				_secondDictionary = null;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}

		#endregion
	}
}