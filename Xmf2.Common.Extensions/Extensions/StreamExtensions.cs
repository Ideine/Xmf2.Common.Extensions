using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Xmf2.Common.Extensions
{
	public static class StreamExtensions
	{
		public static byte[] ToArray(this Stream stream)
		{
			if (stream is MemoryStream memStream)
			{
				return memStream.ToArray();
			}
			else if (stream.TryGetLength(out var length))
			{
				var bytes = new byte[length];
				stream.Read(bytes, 0, (int)length);
				return bytes;
			}
			else
			{
				using (var tempStream = new MemoryStream())
				{
					stream.CopyTo(tempStream);
					return tempStream.ToArray();
				}
			}
		}

		public static async Task<byte[]> ToArrayAsync(this Stream stream, CancellationToken ct = default)
		{
			if (stream is MemoryStream memStream)
			{
				return memStream.ToArray();
			}
			else if (stream.TryGetLength(out var length))
			{
				var bytes = new byte[length];
				await stream.ReadAsync(bytes, 0, (int)length, ct);
				return bytes;
			}
			else
			{
				using (var tempStream = new MemoryStream())
				{
					await stream.CopyToAsync(tempStream, 4096, ct);
					return tempStream.ToArray();
				}
			}
		}

		private static bool TryGetLength(this Stream stream, out long length)
		{
			try
			{
				length = stream.Length;
				return true;
			}
			catch (NotSupportedException)
			{
				length = default;
				return false;
			}
		}
	}
}
