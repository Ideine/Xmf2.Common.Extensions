using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace Xmf2.Common.Extensions
{
	public static class StringsExtensions
	{
		#region TryGetLastIndexOf

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

		#endregion

		/// <summary>
		/// If input is not null or empty, trim the sequence and apply ToLowerInvariant to it
		/// </summary>
		public static string NormalizeEmail(this string email) => string.IsNullOrEmpty(email) ? email : email.Trim().ToLowerInvariant();

		/// <summary>
		/// <see cref="string.IsNullOrWhiteSpace"/>
		/// </summary>
		public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string s) => string.IsNullOrWhiteSpace(s);

		/// <summary>
		/// Negate the result or <see cref="string.IsNullOrWhiteSpace"/>
		/// </summary>
		public static bool NotNullOrWhiteSpace([NotNullWhen(true)] this string s) => !string.IsNullOrWhiteSpace(s);

		public static bool AssertMandatory(this string s) => s is not "";

		public static string NullIfEmpty(this string source) => string.IsNullOrEmpty(source) ? null : source;

		public static string[] Split(this string input, char separator, StringSplitOptions options) => input.Split([separator], options);

		public static string[] Split(this string input, string separator, StringSplitOptions options) => input.Split([separator], options);

		public static string AsSha256(this string input)
		{
			using SHA256 algorithm = SHA256.Create();
			byte[] hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
			return hash.ToHexString();
		}
	}
}