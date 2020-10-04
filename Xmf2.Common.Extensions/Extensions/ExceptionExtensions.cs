using System;
namespace Xmf2.Common.Extensions
{
	public static class ExceptionExtensions
	{
		public static bool AnyToDescendant(this Exception baseEx, Func<Exception, bool> action)
		{
			return AnyToDescendant<Exception>(baseEx, action);
		}

		public static bool AnyToDescendant<T>(this Exception baseEx, Func<T, bool> action)
			where T : Exception
		{
			Exception ex = baseEx;
			while (ex != null)
			{
				if (ex is T typedException && action(typedException))
				{
					return true;
				}
				ex = ex.InnerException;
			}
			return false;
		}
	}
}
