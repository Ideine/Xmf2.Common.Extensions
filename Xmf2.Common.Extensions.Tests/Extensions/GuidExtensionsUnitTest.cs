using Xunit;
using Xmf2.Common.Extensions;
using System;

namespace Xmf2.Common.Tests.Extensions
{
	public static class GuidExtensionsUnitTest
	{
		[Fact]
		public static void XorTest()
		{
			Guid a = Guid.NewGuid();
			Guid b = Guid.NewGuid();

			Assert.Equal(a.Xor(b), b.Xor(a));
			Assert.NotEqual(a, a.Xor(b));
			Assert.NotEqual(b, a.Xor(b));
			Assert.NotEqual(Guid.Empty, a.Xor(b));
		}
	}
}