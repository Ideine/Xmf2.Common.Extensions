using System;
using System.Collections.Generic;
using Xunit;

namespace Xmf2.Common.Tests.Collections
{
	public static class DictionaryExtensions
	{
		private class A { }

		[Fact]
		public static void GetValueOrDefaultPrimitiveTest()
		{
			var dict = new Dictionary<int, int>
			{
				{
					0, 10
				},
				{
					1, 20
				},
			};

			Assert.Equal(10, dict.GetValueOrDefault(0));
			Assert.NotEqual(10, dict.GetValueOrDefault(1));
			Assert.Equal(default, dict.GetValueOrDefault(2));
		}

		[Fact]
		public static void GetValueOrDefaultClassTest()
		{
			var a1 = new A();
			var a2 = new A();

			var dict = new Dictionary<int, A>
			{
				{
					0, a1
				},
				{
					1, a2
				},
			};

			Assert.Equal(a1, dict.GetValueOrDefault(0));
			Assert.NotEqual(a1, dict.GetValueOrDefault(1));
			Assert.Null(dict.GetValueOrDefault(2));
		}
	}
}