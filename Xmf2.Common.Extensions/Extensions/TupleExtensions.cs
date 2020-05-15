using System;
namespace Xmf2.Common.Extensions
{
	/// <remarks>
	/// Prefixed 'Xmf' to avoid any naming conflicts with <see cref="System.TupleExtensions"/>
	/// </remarks>
	public static class XmfTupleExtensions
	{
		public static TOut ToArguments<TIn1, TIn2, TOut>(this Tuple<TIn1, TIn2> tuple, Func<TIn1, TIn2, TOut> func)
			=> func(tuple.Item1, tuple.Item2);

		public static TOut ToArguments<TIn1, TIn2, TIn3, TOut>(this Tuple<TIn1, TIn2, TIn3> tuple, Func<TIn1, TIn2, TIn3, TOut> func)
			=> func(tuple.Item1, tuple.Item2, tuple.Item3);

		public static TOut ToArguments<TIn1, TIn2, TIn3, TIn4, TOut>(this Tuple<TIn1, TIn2, TIn3, TIn4> tuple, Func<TIn1, TIn2, TIn3, TIn4, TOut> func)
			=> func(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);

		public static TOut ToArguments<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(this Tuple<TIn1, TIn2, TIn3, TIn4, TIn5> tuple, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> func)
			=> func(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5);
	}
}
