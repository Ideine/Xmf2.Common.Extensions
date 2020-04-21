using System;
using System.Security.Cryptography;
using System.Text;

namespace Xmf2.Common.Extensions
{
	public static class StringsExtensions
	{
		public static bool IsNullOrEmpty(this string s) => string.IsNullOrEmpty(s);

		public static string NormalizeEmail(this string email) => string.IsNullOrEmpty(email) ? email : email.Trim().ToLowerInvariant();

		public static bool NotNullOrEmpty(this string s) => !string.IsNullOrEmpty(s);

		public static bool AssertMandatory(this string s) => s == null || s != string.Empty;

		public static string NullIfEmpty(this string source) => string.IsNullOrEmpty(source) ? null : source;

		public static bool IsPriceOrNull(this decimal? price) => price is null || price >= 0;

		public static string[] Split(this string s, char separator, StringSplitOptions options) => s.Split(new[]
		{
			separator
		}, options);

		public static string AsSha256(this string input)
		{
			using var algorithm = SHA256.Create();
			byte[] hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
			var formatted = new StringBuilder(2 * hash.Length);
			foreach (byte b in hash)
			{
				formatted.AppendFormat("{0:X2}", b);
			}

			return formatted.ToString();
		}
	}
}