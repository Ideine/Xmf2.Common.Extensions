using System;
using System.Security.Cryptography;
using System.Text;

namespace Xmf2.Common.Extensions
{
	public static class StringsExtensions
	{
		//TODO: voir en PR. Confusion possible entre Xmf2.Common.Collections.NullOrEmptyExtensions et cette méthode...
		//... d'autant plus que ces méthodes sont désormais dans des espaces de nom différents. Auparavant le compilateur...
		//... choisissait la méthode avec le type le plus spécifique (donc celle ci s'il s'agissait d'une string).
		//2 propositions de résolutions : 
		//	1) Ne conserver que la méthode de l'espace de nom Xmf2.Common.Collections qui au final fait la même chose.
		//	2) Passer cette méthode obsolète et créer une autre méthode StringIsNullOrEmpty(this string s) => ...
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