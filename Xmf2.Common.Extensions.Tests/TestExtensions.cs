using System;
namespace Xmf2.Common.Tests
{
	static internal class TestExtensions
	{
		public static void ShoudThrow<TEx>(this Action action)
			where TEx : Exception
		{
			try
			{ action(); }
			catch (TEx) { return; }
			throw new Exception($"{typeof(TEx).Name} expected.");
		}
	}
}
