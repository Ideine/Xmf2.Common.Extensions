﻿using System;
using System.Collections.Generic;

namespace Xmf2.Common.Extensions
{
	public static class ByPropEqualityComparer<T>
	{
		public static IEqualityComparer<T> Instanciate<TProp>(Func<T, TProp> selector)
		{
			return new ByPropEqualityComparer<T, TProp>(selector);
		}
		public static IEqualityComparer<T> Instanciate<TPropA, TPropB>(
			Func<T, TPropA> selectorA,
			Func<T, TPropB> selectorB)
		{
			return new AndEqualityComparer<T>(
				Instanciate(selectorA),
				Instanciate(selectorB)
			);
		}
		public static IEqualityComparer<T> Instanciate<TPropA, TPropB, TPropC>(
			Func<T, TPropA> selectorA,
			Func<T, TPropB> selectorB,
			Func<T, TPropC> selectorC)
		{
			return new AndEqualityComparer<T>(
				Instanciate(selectorA),
				Instanciate(selectorB),
				Instanciate(selectorC)
			);
		}
		public static IEqualityComparer<T> Instanciate<TPropA, TPropB, TPropC, TPropD>(
			Func<T, TPropA> selectorA,
			Func<T, TPropB> selectorB,
			Func<T, TPropC> selectorC)
		{
			return new AndEqualityComparer<T>(
				Instanciate(selectorA),
				Instanciate(selectorB),
				Instanciate(selectorC)
			);
		}
		public static IEqualityComparer<T> Instanciate<TPropA, TPropB, TPropC, TPropD, TPropE>(
			Func<T, TPropA> selectorA,
			Func<T, TPropB> selectorB,
			Func<T, TPropC> selectorC,
			Func<T, TPropD> selectorD,
			Func<T, TPropE> selectorE)
		{
			return new AndEqualityComparer<T>(
				Instanciate(selectorA),
				Instanciate(selectorB),
				Instanciate(selectorC),
				Instanciate(selectorD),
				Instanciate(selectorE)
			);
		}
		public static IEqualityComparer<T> Instanciate<TPropA, TPropB, TPropC, TPropD, TPropE, TPropF>(
			Func<T, TPropA> selectorA,
			Func<T, TPropB> selectorB,
			Func<T, TPropC> selectorC,
			Func<T, TPropD> selectorD,
			Func<T, TPropE> selectorE,
			Func<T, TPropF> selectorF)
		{
			return new AndEqualityComparer<T>(
				Instanciate(selectorA),
				Instanciate(selectorB),
				Instanciate(selectorC),
				Instanciate(selectorD),
				Instanciate(selectorE),
				Instanciate(selectorF)
			);
		}
		public static IEqualityComparer<T> Instanciate<TPropA, TPropB, TPropC, TPropD, TPropE, TPropF, TPropG>(
			Func<T, TPropA> selectorA,
			Func<T, TPropB> selectorB,
			Func<T, TPropC> selectorC,
			Func<T, TPropD> selectorD,
			Func<T, TPropE> selectorE,
			Func<T, TPropF> selectorF,
			Func<T, TPropG> selectorG)
		{
			return new AndEqualityComparer<T>(
				Instanciate(selectorA),
				Instanciate(selectorB),
				Instanciate(selectorC),
				Instanciate(selectorD),
				Instanciate(selectorE),
				Instanciate(selectorF),
				Instanciate(selectorG)
			);
		}
		public static IEqualityComparer<T> Instanciate<TPropA, TPropB, TPropC, TPropD, TPropE, TPropF, TPropG, TPropH>(
			Func<T, TPropA> selectorA,
			Func<T, TPropB> selectorB,
			Func<T, TPropC> selectorC,
			Func<T, TPropD> selectorD,
			Func<T, TPropE> selectorE,
			Func<T, TPropF> selectorF,
			Func<T, TPropG> selectorG,
			Func<T, TPropH> selectorH)
		{
			return new AndEqualityComparer<T>(
				Instanciate(selectorA),
				Instanciate(selectorB),
				Instanciate(selectorC),
				Instanciate(selectorD),
				Instanciate(selectorE),
				Instanciate(selectorF),
				Instanciate(selectorG),
				Instanciate(selectorH)
			);
		}

		public static IEqualityComparer<T> Instanciate<TProp>(Func<T, TProp> selector, IEqualityComparer<TProp> equalityComparer)
		{
			return new ByPropEqualityComparer<T, TProp>(selector, equalityComparer);
		}
	}

	public class ByPropEqualityComparer<T, TPropA> : IEqualityComparer<T>
	{
		private readonly Func<T, TPropA> _selector;
		private readonly IEqualityComparer<TPropA> _propEqualityComparer;

		public ByPropEqualityComparer(Func<T, TPropA> selector)
		{
			if (selector is null)
			{
				throw new ArgumentNullException(nameof(selector));
			}
			_selector = selector;
			_propEqualityComparer = EqualityComparer<TPropA>.Default;
		}

		public ByPropEqualityComparer(Func<T, TPropA> selector, IEqualityComparer<TPropA> equalityComparer)
		{
			if (selector is null)
			{
				throw new ArgumentNullException(nameof(selector));
			}
			if (equalityComparer is null)
			{
				throw new ArgumentNullException(nameof(equalityComparer));
			}
			_selector = selector;
			_propEqualityComparer = equalityComparer;
		}

		public bool Equals(T x, T y)
		{
			return x == null
				 ? y == null
				 : y == null ? false
							 : _propEqualityComparer.Equals(_selector(x), _selector(y));
		}

		public int GetHashCode(T obj)
		{
			return obj == null
				 ? 0
				 : _propEqualityComparer.GetHashCode(_selector(obj));
		}
	}
}
