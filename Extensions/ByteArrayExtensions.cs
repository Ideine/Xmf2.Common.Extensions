using System.Text;

namespace Xmf2.Common.Extensions
{
	public static class ByteArrayExtensions
	{
		public static string ToHexString(this byte[] input)
		{
			var formatted = new StringBuilder(2 * input.Length);
			foreach (byte b in input)
			{
				formatted.AppendFormat("{0:X2}", b);
			}

			return formatted.ToString();
		}
	}
}