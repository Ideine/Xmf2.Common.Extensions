using Xmf2.Common.Extensions;
using Xunit;

namespace Xmf2.Common.Tests.Extensions
{
	public static class NormalizeStringUnitTest
	{
		[Fact]
		public static void NullOrEmptyString()
		{
			string nullString = null;
			Assert.Null(nullString.NormalizeEmail());

			string emptyString = string.Empty;
			Assert.Equal(string.Empty, emptyString.NormalizeEmail());
		}

		[Fact]
		public static void LowerString()
		{
			string lowerString = "abcdefghijklmnopqrstuvwxyz";
			Assert.Equal("abcdefghijklmnopqrstuvwxyz", lowerString.NormalizeEmail());

			string upperString = "ABCDEFGHIJKLMNNOPQRSTUVWXYZ";
			Assert.Equal("abcdefghijklmnopqrstuvwxyz", upperString.NormalizeEmail());

			string mixedString = "abCDeFghiJKLmnopqRsTuvWXYZ";
			Assert.Equal("abcdefghijklmnopqrstuvwxyz", mixedString.NormalizeEmail());
		}

		[Fact]
		public static void TrimString()
		{
			string noTrimString = "abcde";
			Assert.Equal("abcde", noTrimString.NormalizeEmail());

			string trimString = " abcde";
			Assert.Equal("abcde", trimString.NormalizeEmail());

			string manyTrimString = "  abcde     ";
			Assert.Equal("abcde", manyTrimString.NormalizeEmail());

			string trimAndLowerString = "  ABCde ";
			Assert.Equal("abcde", trimAndLowerString.NormalizeEmail());
		}

		[Fact]
		public static void NotAlphaString()
		{
			string numericalString = "123 ";
			Assert.Equal("123", numericalString.NormalizeEmail());

			string nbspString = " ";
			Assert.Equal(string.Empty, nbspString.NormalizeEmail());

			string carriageString = "\n";
			Assert.Equal(string.Empty, carriageString.NormalizeEmail());

			string emoteString = "🙂";
			Assert.Equal("🙂", emoteString.NormalizeEmail());
		}
	}
}