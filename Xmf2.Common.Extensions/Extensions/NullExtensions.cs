using System;
using System.Threading.Tasks;

namespace Xmf2.Common.Extensions
{
	public static class NullExtensions
	{
		#region value if null

		public static T ValueIfNull<T>(this T s, T value)
			where T : class
		{
			return s ?? value;
		}

		public static T? ValueIfNull<T>(this T? nullable, T? @default)
			where T : struct
		{
			return nullable ?? @default;
		}

		[Obsolete("Use Nullable<T>.GetValueOrDefault(T)")]
		public static bool ValueIfNull(this bool? s, bool value) => s.GetValueOrDefault(value);

		#endregion

		#region to bool

		public static bool NotNull(this object o) => o != null;

		public static bool TrueIfNull(this object o) => o == null;
		public static bool TrueIfNotNull(this object o) => o != null;
		public static bool FalseIfNull(this object o) => o != null;
		public static bool FalseIfNotNull(this object o) => o == null;

		public static async Task<bool> TrueIfNull<T>(this Task<T> o) => (await o).TrueIfNull();
		public static async Task<bool> TrueIfNotNull<T>(this Task<T> o) => (await o).TrueIfNotNull();
		public static async Task<bool> FalseIfNull<T>(this Task<T> o) => (await o).FalseIfNull();
		public static async Task<bool> FalseIfNotNull<T>(this Task<T> o) => (await o).FalseIfNotNull();

		#endregion
	}
}