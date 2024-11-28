using System;
using System.Globalization;

namespace Xmf2.Common.Extensions
{
	public static class DateOnlyExtensions
	{
#if NET6_0_OR_GREATER
		public static DateOnly BeginningOfWeek(this DateOnly date, DayOfWeek startDayOfWeek = DayOfWeek.Monday)
		{
			int diff = (7 + (date.DayOfWeek - startDayOfWeek)) % 7;
			return date.AddDays(-1 * diff);
		}

		public static DateOnly EndOfWeek(this DateOnly date, DayOfWeek startDayOfWeek = DayOfWeek.Monday) => date.AddDays(7).BeginningOfWeek(startDayOfWeek).AddDays(-1);

		public static DateOnly BeginningOfMonth(this DateOnly date) => new(date.Year, date.Month, 1);

		public static bool IsSameDay(this DateOnly firstDate, DateOnly secondDate) => firstDate.IsSameMonth(secondDate) && firstDate.Day == secondDate.Day;

		public static bool IsSameWeek(this DateOnly firstDate, DateOnly secondDate, DayOfWeek startDayOfWeek = DayOfWeek.Monday)
		{
			DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;

			int firstDateWeek = dfi.Calendar.GetWeekOfYear(firstDate.ToDateTime(TimeOnly.MinValue), dfi.CalendarWeekRule, startDayOfWeek);
			int secondDateWeek = dfi.Calendar.GetWeekOfYear(secondDate.ToDateTime(TimeOnly.MinValue), dfi.CalendarWeekRule, startDayOfWeek);

			return firstDateWeek == secondDateWeek;
		}

		public static bool IsSameMonth(this DateOnly firstDate, DateOnly secondDate) => firstDate.IsSameYear(secondDate) && firstDate.Month == secondDate.Month;

		public static bool IsSameYear(this DateOnly firstDate, DateOnly secondDate) => firstDate.Year == secondDate.Year;
#endif
	}
}