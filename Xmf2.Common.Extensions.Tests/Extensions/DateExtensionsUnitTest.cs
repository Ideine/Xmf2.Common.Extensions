using System;
using Xmf2.Common.Extensions;
using Xunit;

namespace Xmf2.Common.Tests.Extensions
{
	public static class DateExtensionsUnitTest
	{
		[Fact]
		public static void BeginningOfDayTest()
		{
			Assert.Equal(new DateTime(2021, 10, 31, 0, 0, 0), new DateTime(2021, 10, 31, 16, 21, 30).BeginningOfDay());

			Assert.NotEqual(new DateTime(2021, 10, 31, 12, 0, 0), new DateTime(2021, 10, 31, 16, 21, 30).BeginningOfDay());

			Assert.NotEqual(new DateTime(2021, 10, 30, 10, 0, 0), new DateTime(2021, 10, 31, 16, 21, 30).BeginningOfDay());

			Assert.NotEqual(new DateTime(2021, 10, 30, 23, 59, 59), new DateTime(2021, 10, 31, 16, 21, 30).BeginningOfDay());

			Assert.Equal(new DateTimeOffset(2021, 10, 31, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2021, 10, 31, 16, 21, 30, TimeSpan.Zero).BeginningOfDay());

			Assert.NotEqual(new DateTimeOffset(2021, 10, 31, 12, 0, 0, TimeSpan.Zero), new DateTimeOffset(2021, 10, 31, 16, 21, 30, TimeSpan.Zero).BeginningOfDay());

			Assert.NotEqual(new DateTimeOffset(2021, 10, 30, 0, 0, 0, TimeSpan.Zero), new DateTime(2021, 10, 31, 16, 21, 30).BeginningOfDay());

			Assert.NotEqual(new DateTimeOffset(2021, 10, 30, 23, 59, 59, TimeSpan.Zero), new DateTimeOffset(2021, 10, 31, 16, 21, 30, TimeSpan.Zero).BeginningOfDay());
		}

		[Fact]
		public static void EndOfDayTest()
		{
			Assert.Equal(new DateTime(637713215999999999), new DateTime(2021, 10, 31, 16, 21, 30).EndOfDay());

			Assert.NotEqual(new DateTime(2021, 10, 31, 12, 0, 0), new DateTime(2021, 10, 31, 16, 21, 30).EndOfDay());

			Assert.NotEqual(new DateTime(2021, 11, 1, 0, 0, 0), new DateTime(2021, 10, 31, 16, 21, 30).EndOfDay());

			Assert.NotEqual(new DateTime(637712351999999999), new DateTime(2021, 10, 31, 16, 21, 30).EndOfDay());

			Assert.Equal(new DateTimeOffset(637713215999999999, TimeSpan.Zero), new DateTimeOffset(2021, 10, 31, 16, 21, 30, TimeSpan.Zero).EndOfDay());

			Assert.NotEqual(new DateTimeOffset(2021, 10, 31, 12, 0, 0, TimeSpan.Zero), new DateTimeOffset(2021, 10, 31, 16, 21, 30, TimeSpan.Zero).EndOfDay());

			Assert.NotEqual(new DateTimeOffset(2021, 11, 1, 0, 0, 0, TimeSpan.Zero), new DateTime(2021, 10, 31, 16, 21, 30).EndOfDay());

			Assert.NotEqual(new DateTimeOffset(637712351999999999, TimeSpan.Zero), new DateTimeOffset(2021, 10, 31, 16, 21, 30, TimeSpan.Zero).EndOfDay());
		}
	}
}