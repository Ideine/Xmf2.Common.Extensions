using System;
using Xmf2.Common.Extensions;
using Xunit;

namespace Xmf2.Common.Tests.Extensions
{
	public class NullExtensionsUnitTest
	{
		[Fact]
		public static void WorksWithString() => CheckWithClass(nonDefaultValue: "hello");

		[Fact]
		public static void WorksWithBool() => CheckWithStruct(nonDefaultValue: !default(bool));

		[Fact]
		public static void WorksWithInt() => CheckWithStruct(nonDefaultValue: 1);

		[Fact]
		public static void WorksWithFloat() => CheckWithStruct(nonDefaultValue: 1f);

		[Fact]
		public static void WorksWithDouble() => CheckWithStruct(nonDefaultValue: 1d);

		[Fact]
		public static void WorksWithDatetime() => CheckWithStruct(nonDefaultValue: DateTime.Now);

		[Fact]
		public static void WorksWithDateTimeOffset() => CheckWithStruct(nonDefaultValue: DateTimeOffset.Now);

		[Fact]
		public static void WorksWithDecimal() => CheckWithStruct(nonDefaultValue: 1m);

		[Fact]
		public static void WorksWithGuid() => CheckWithStruct(nonDefaultValue: Guid.NewGuid());

		private static void CheckWithStruct<T>(T nonDefaultValue)
			where T : struct, IEquatable<T>
		{
			T? nullT = null;
			Assert.Equal(new T?(nonDefaultValue), nullT.ValueIfNull(new T?(nonDefaultValue)));

			T? nonDefaultNullableT = nonDefaultValue;
			Assert.Equal(nonDefaultValue, nonDefaultNullableT.ValueIfNull(new T?(default)));
		}

		private static void CheckWithClass<T>(T nonDefaultValue)
			where T : class, IEquatable<T>
		{
			T nullT = null;
			Assert.Equal(nonDefaultValue, nullT.ValueIfNull(nonDefaultValue));

			T nonDefaultNullableT = nonDefaultValue;
			Assert.Equal(nonDefaultValue, nonDefaultNullableT.ValueIfNull(null));
		}
	}
}
