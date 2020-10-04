using Xmf2.Common.Extensions;
using Xunit;

namespace Xmf2.Common.Tests.Extensions
{
	public static class NullOrWhiteSpaceStringUnitTest
	{
		[Fact]
		public static void IsNullOrWhiteSpace()
		{
			string nullString = null;
			Assert.True(nullString.IsNullOrWhiteSpace());

			string emptyString = string.Empty;
			Assert.True(emptyString.IsNullOrWhiteSpace());

			string whitespaceString = " ";
			Assert.True(whitespaceString.IsNullOrWhiteSpace());

			string nbspString = " ";
			Assert.True(nbspString.IsNullOrWhiteSpace());

			string notEmptyString = "abcde";
			Assert.False(notEmptyString.IsNullOrWhiteSpace());
		}

		[Fact]
		public static void NotNullOrWhiteSpace()
		{
			string nullString = null;
			Assert.False(nullString.NotNullOrWhiteSpace());

			string emptyString = string.Empty;
			Assert.False(emptyString.NotNullOrWhiteSpace());

			string whitespaceString = " ";
			Assert.False(whitespaceString.NotNullOrWhiteSpace());

			string nbspString = " ";
			Assert.False(nbspString.NotNullOrWhiteSpace());

			string notEmptyString = "abcde";
			Assert.True(notEmptyString.NotNullOrWhiteSpace());
		}
	}
}