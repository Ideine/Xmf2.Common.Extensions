using System;
using System.Security.Cryptography;
using System.Text;

namespace Xmf2.Common.Extensions
{
	public static class StringsExtensions
	{
		public static bool TryGetLastIndexOf(this string s, char value, out int lastIndex)
			=> (lastIndex = s.LastIndexOf(value)) != -1;

		public static bool TryGetLastIndexOf(this string s, char value, int startIndex, out int lastIndex)
			=> (lastIndex = s.LastIndexOf(value, startIndex)) != -1;

		public static bool TryGetLastIndexOf(this string s, char value, int startIndex, int count, out int lastIndex)
			=> (lastIndex = s.LastIndexOf(value, startIndex, count)) != -1;

		public static bool TryGetLastIndexOf(this string s, string value, out int lastIndex)
			=> (lastIndex = s.LastIndexOf(value)) != -1;

		public static bool TryGetLastIndexOf(this string s, string value, int startIndex, out int lastIndex)
			=> (lastIndex = s.LastIndexOf(value, startIndex)) != -1;

		public static bool TryGetLastIndexOf(this string s, string value, int startIndex, int count, out int lastIndex)
			=> (lastIndex = s.LastIndexOf(value, startIndex, count)) != -1;

		public static bool TryGetLastIndexOf(this string s, string value, int startIndex, int count, StringComparison comparisonType, out int lastIndex)
			=> (lastIndex = s.LastIndexOf(value, startIndex, count, comparisonType)) != -1;

		public static bool TryGetLastIndexOf(this string s, string value, int startIndex, StringComparison comparisonType, out int lastIndex)
			=> (lastIndex = s.LastIndexOf(value, startIndex, comparisonType)) != -1;

		public static bool TryGetLastIndexOf(this string s, string value, StringComparison comparisonType, out int lastIndex)
			=> (lastIndex = s.LastIndexOf(value, comparisonType)) != -1;

		public static string NormalizeEmail(this string email) => string.IsNullOrEmpty(email) ? email : email.Trim().ToLowerInvariant();

		public static bool AssertMandatory(this string s) => s == null || s != string.Empty;

		public static string NullIfEmpty(this string source) => string.IsNullOrEmpty(source) ? null : source;

		public static string[] Split(this string s, char separator, StringSplitOptions options) => s.Split(new[]
		{
			separator
		}, options);

		public static string[] Split(this string input, string separator, StringSplitOptions options) => input.Split(new[]
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