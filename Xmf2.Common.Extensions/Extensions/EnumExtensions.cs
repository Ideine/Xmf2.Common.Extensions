using System;

namespace Xmf2.Common.Extensions
{
	public static class EnumExtensions
	{
		public static NotSupportedException GetNotSupportedException(this Enum enumValue)
		{
			return new NotSupportedException(GetNotSupportedMessage(enumValue));
		}

		public static InvalidOperationException GetInvalidOperationException(this Enum enumValue)
		{
			return new InvalidOperationException(GetInvalidOperationMessage(enumValue));
		}

		public static string GetNotSupportedMessage(this Enum enumValue)
		{
			return $"This {enumValue.GetType().FullName} value is not supported yet. Value: {enumValue}";
		}

		public static string GetInvalidOperationMessage(this Enum enumValue)
		{
			return $"This {enumValue.GetType().FullName} value is not valid. Value: {enumValue}";
		}
	}
}