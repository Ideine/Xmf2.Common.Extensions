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
			return Guid.Parse(x.Substring(0, 32));
		}
	}
}