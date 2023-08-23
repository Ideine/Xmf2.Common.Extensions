using System;
using System.Text.RegularExpressions;

namespace Xmf2.Common.Extensions
{
	public static class EmailExtensions
	{
		private const string ROUGH_EMAIL_REGEX_PATTERN = "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$";
		private static readonly Lazy<Regex> ROUGH_EMAIL_REGEX = new(() => new Regex(ROUGH_EMAIL_REGEX_PATTERN, RegexOptions.Compiled));

		public static bool ValidateEmailFormat(this string email) => ROUGH_EMAIL_REGEX.Value.IsMatch(email);
	}
}