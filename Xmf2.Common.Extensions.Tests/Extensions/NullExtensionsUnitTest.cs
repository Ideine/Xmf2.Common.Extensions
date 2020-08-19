using System;
using Xmf2.Common.Extensions;
using Xunit;

namespace Xmf2.Common.Tests.Extensions
{
	public class NullExtensionsUnitTest
	{
		[Fact]
		public static void WorksWithBool() => CheckWithType(nonDefaultValue: !default(bool));

		[Fact]
		public static void WorksWithInt() => CheckWithType(nonDefaultValue: 1);

		[Fact]
		public static void WorksWithFloat() => CheckWithType(nonDefaultValue: 1f);

		[Fact]
		public static void WorksWithDouble() => CheckWithType(nonDefaultValue: 1d);

		[Fact]
		public static void WorksWithDatetime() => CheckWithType(nonDefaultValue: DateTime.Now);

		[Fact]
		public static void WorksWithDateTimeOffset() => CheckWithType(nonDefaultValue: DateTimeOffset.Now);

		[Fact]
		public static void WorksWithDecimal() => CheckWithType(nonDefaultValue: 1m);

		[Fact]
		public static void WorksWithGuid() => CheckWithType(nonDefaultValue: Guid.NewGuid());

		private static void CheckWithType<T>(T nonDefaultValue)
			where T : struct, IEquatable<T>
		{
			T? nullT = null;
			Assert.True(nullT.IsNullOrNotDefault());

			T? nonDefaultNullableT = nonDefaultValue;
			Assert.True(nonDefaultNullableT.IsNullOrNotDefault());

			T? defaultT = default(T);
			Assert.False(defaultT.IsNullOrNotDefault());
		}
	}
}
