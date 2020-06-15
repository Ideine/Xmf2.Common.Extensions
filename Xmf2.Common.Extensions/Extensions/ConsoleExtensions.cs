using System;
using System.Runtime.CompilerServices;

namespace Xmf2.Common.Extensions
{
	public static class ConsoleExtensions
	{
		public static void WriteMethodInfo([CallerFilePath] string fileName = null, [CallerMemberName] string methodName = null, [CallerLineNumber] int line = 0)
		{
			//vju : unfortunately we can not add extensions method to static class
			Console.WriteLine($"In {fileName}:{line} method={methodName}");
		}
	}
}