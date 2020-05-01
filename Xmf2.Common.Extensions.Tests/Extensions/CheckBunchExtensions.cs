using System;
using System.Collections.Generic;
using System.Linq;
using Xmf2.Common.Collections;
using Xunit;

namespace Xmf2.Common.Tests.Extensions
{
	public static class CheckBunchExtensions
	{
		[Fact]
		public static void ByBunchWork()
		{
			var range = Enumerable.Range(1, 7);
			var bunches = range.ByBunchOf(3);
			Assert.Equal(range.Skip(0 * 3).Take(3), bunches.First());
			Assert.Equal(range.Skip(1 * 3).Take(3), bunches.Skip(1).First());
			Assert.Equal(range.Skip(2 * 3).Take(3), bunches.Skip(2).First());

			CheckThat(aRangeOf: 00, byBunchOf: 10, shouldMakeThisBunchNumber: 00);
			CheckThat(aRangeOf: 20, byBunchOf: 10, shouldMakeThisBunchNumber: 02);
			CheckThat(aRangeOf: 21, byBunchOf: 10, shouldMakeThisBunchNumber: 03);
			CheckThat(aRangeOf: 21, byBunchOf: 01, shouldMakeThisBunchNumber: 21);
		}

		private static void CheckThat(int aRangeOf, int byBunchOf, int shouldMakeThisBunchNumber)
		{
			var initial = Enumerable.Range(0, aRangeOf);
			var byBunch = initial.ByBunchOf(byBunchOf);
			var rebuild = byBunch.SelectMany(bunch => bunch);
			Assert.Equal(initial, rebuild);
			Assert.Equal(shouldMakeThisBunchNumber, byBunch.Count());
		}
	}
}
