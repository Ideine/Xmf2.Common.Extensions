using System;
using System.Threading.Tasks;

namespace Xmf2.Common.Extensions
{
	public static class NullExtensions
	{
		#region value if null

		public static string ValueIfNull(this string s, string value) => s ?? value;

		public static int? ValueIfNull(this int? s, int? value) => s ?? value;

		public static bool? ValueIfNull(this bool? s, bool? value) => s ?? value;

		public static bool ValueIfNull(this bool? s, bool value) => s ?? value;

		public static double? ValueIfNull(this double? s, double? value) => s ?? value;

		public static DateTime? ValueIfNull(this DateTime? date, DateTime? @default) => date ?? @default;

		public static DateTimeOffset? ValueIfNull(this DateTimeOffset? date, DateTimeOffset? @default) => date ?? @default;

		public static decimal? ValueIfNull(this decimal? s, decimal? value) => s ?? value;

		public static Guid? ValueIfNull(this Guid? s, Guid? value) => s ?? value;

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