using System;
using System.Security.Cryptography;
using System.Text;

namespace Xmf2.Common.Extensions
{
	public static class GuidExtensions
	{
		public static Guid HashToGuid(this string id)
		{
			using var algorithm = SHA1.Create();
			string x = algorithm.ComputeHash(Encoding.UTF8.GetBytes(id)).ToHexString();
			return Guid.Parse(x[..32]);
		}

		public static Guid Xor(this Guid a, Guid b)
		{
			byte[] arrayA = a.ToByteArray();
			byte[] arrayB = b.ToByteArray();
			for (int i = 0 ; i < 16 ; i++)
			{
				arrayA[i] ^= arrayB[i];
			}

			return new Guid(arrayA);
		}
	}
}