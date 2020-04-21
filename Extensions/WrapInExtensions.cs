using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Xmf2.Common.Extensions
{
	public static class WrapInExtensions
	{
		public static T[] WrapInArray<T>(this T input)
		{
			return new[]
			{
				input
			};
		}

		public static List<T> WrapInList<T>(this T input)
		{
			return new List<T>
			{
				input
			};
		}

		public static MemoryStream WrapInMemoryStream(this byte[] source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source), "source is null");
			}

			return new MemoryStream(source);
		}

		public static async Task<MemoryStream> WrapInMemoryStream(this Task<byte[]> source)
		{
			return (await source).WrapInMemoryStream();
		}
	}
}