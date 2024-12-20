using System.Text;

namespace Xmf2.Common.Extensions
{
	public static class ByteArrayExtensions
	{
		public static string ToHexString(this byte[] input)
		{
			StringBuilder formatted = new(2 * input.Length);
			foreach (byte b in input)
			{
				formatted.Append($"{b:X2}");
			}

			return formatted.ToString();
		}
	}
}