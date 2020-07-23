using System;
using Xmf2.Common.Extensions;
using Xunit;

namespace Xmf2.Common.Tests.Extensions
{
	public static class EndOfWeekUnitTest
	{
		[Fact]
		public static void IsAlreadyEndOfWeekTest()
		{
			// sunday may 24
			var sunday = new DateTime(2020, 05, 24);
			DateTime end = sunday.EndOfWeek();
			Assert.Equal(end, sunday);
		}

		[Fact]
		public static void BeginningOfWeekTest()
		{
			// tuesday may 19 
			var tuesday = new DateTime(2020, 05, 19);
			DateTime end = tuesday.EndOfWeek();
			Assert.Equal(new DateTime(2020, 05, 24), end);
		}

		[Fact]
		public static void WednesdayBeginningOfWeek()
		{
			//friday may 22 
			var friday = new DateTime(2020, 05, 22);
			DateTime end = friday.EndOfWeek(DayOfWeek.Wednesday);
			Assert.Equal(new DateTime(2020, 05, 27), end);
		}
	}
}
