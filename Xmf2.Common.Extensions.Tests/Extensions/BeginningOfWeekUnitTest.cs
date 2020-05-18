using System;
using Xmf2.Common.Extensions;
using Xunit;

namespace Xmf2.Common.Tests.Extensions
{
	public static class BeginningOfWeekUnitTest
	{
		[Fact]
		public static void IsAlreadyBeginningOfWeekTest()
		{
			// lundi 18 mai
			var monday = new DateTime(2020, 05, 18);
			DateTime beginning = monday.BeginningOfWeek();
			Assert.Equal(beginning, monday);
		}

		[Fact]
		public static void BeginningOfWeekTest()
		{
			// mardi 19 mai
			var tuesday = new DateTime(2020, 05, 19);
			DateTime beginning = tuesday.BeginningOfWeek();
			Assert.Equal(new DateTime(2020, 05, 18), beginning);
		}

		[Fact]
		public static void SundayTest()
		{
			//dimanche 24 mai
			var sunday = new DateTime(2020, 05, 24);
			DateTime beginning = sunday.BeginningOfWeek();
			Assert.Equal(new DateTime(2020, 05, 18), beginning);
		}

		[Fact]
		public static void WednesdayBeginningOfWeek()
		{
			//friday 22 mai
			var friday = new DateTime(2020, 05, 22);
			DateTime beginning = friday.BeginningOfWeek(DayOfWeek.Wednesday);
			Assert.Equal(new DateTime(2020, 05, 20), beginning);
		}
	}
}