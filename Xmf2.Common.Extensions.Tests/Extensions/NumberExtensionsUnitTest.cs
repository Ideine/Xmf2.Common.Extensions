using Xunit;
using Xmf2.Common.Extensions;

namespace Xmf2.Common.Tests.Extensions
{
	public static class NumberExtensionsUnitTest
	{
		[Fact]
		public static void ReturnMinTest()
		{
			int intRes = 0.Clamp(5, 15);
			Assert.Equal(5, intRes);

			float floatRes = 0f.Clamp(5, 15);
			Assert.Equal(5,floatRes);

			double doubleRes = 0d.Clamp(5, 15);
			Assert.Equal(5, doubleRes);

			decimal decimalRes = 0m.Clamp(5, 15);
			Assert.Equal(5,decimalRes);
		}

		[Fact]
		public static void ReturnMaxTest()
		{
			int intRes = 20.Clamp(5, 15);
			Assert.Equal(15, intRes);

			float floatRes = 20f.Clamp(5, 15);
			Assert.Equal(15,floatRes);

			double doubleRes = 20d.Clamp(5, 15);
			Assert.Equal(15, doubleRes);

			decimal decimalRes = 20m.Clamp(5, 15);
			Assert.Equal(15,decimalRes);
		}

		[Fact]
		public static void ReturnValueTest()
		{
			int intRes = 10.Clamp(5, 15);
			Assert.Equal(10, intRes);

			float floatRes = 10f.Clamp(5, 15);
			Assert.Equal(10,floatRes);

			double doubleRes = 10d.Clamp(5, 15);
			Assert.Equal(10, doubleRes);

			decimal decimalRes = 10m.Clamp(5, 15);
			Assert.Equal(10,decimalRes);
		}
	}
}