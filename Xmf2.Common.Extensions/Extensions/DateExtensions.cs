using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xmf2.Common.Collections;

namespace Xmf2.Common.Extensions
{
	public static class DateExtensions
	{
		public static DateTime BeginningOfDay(this DateTime date) => date.Date;

		public static DateTime EndOfDay(this DateTime date)
		{
			var endOfDay = new DateTime(date.Year, date.Month, date.Day);
			endOfDay = endOfDay.AddDays(1);
			endOfDay = endOfDay.AddTicks(-1);

			return endOfDay;
		}

		public static DateTime BeginningOfMonth(this DateTime date)
		{
			return new DateTime(date.Year, date.Month, 1);
		}

		public static DateTime BeginningOfWeek(this DateTime date, DayOfWeek startDayOfWeek = DayOfWeek.Monday)
		{
			int diff = (7 + (date.DayOfWeek - startDayOfWeek)) % 7;
			return date.AddDays(-1 * diff).Date;
		}

		public static DateTime EndOfWeek(this DateTime date, DayOfWeek startDayOfWeek = DayOfWeek.Monday)
		{
			return date.AddDays(7).BeginningOfWeek(startDayOfWeek).AddDays(-1).Date;
		}

		public static bool IsSameDay(this DateTime firstDate, DateTime secondDate)
		{
			return firstDate.IsSameMonth(secondDate) && firstDate.Day == secondDate.Day;
		}

		public static bool IsSameWeek(this DateTime firstDate, DateTime secondDate, DayOfWeek startDayOfWeek = DayOfWeek.Monday)
		{
			DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;

			int firstDateWeek = dfi.Calendar.GetWeekOfYear(firstDate, dfi.CalendarWeekRule, startDayOfWeek);
			int secondDateWeek = dfi.Calendar.GetWeekOfYear(secondDate, dfi.CalendarWeekRule, startDayOfWeek);

			return firstDateWeek == secondDateWeek;
		}

		public static bool IsSameMonth(this DateTime firstDate, DateTime secondDate)
		{
			return firstDate.IsSameYear(secondDate) && firstDate.Month == secondDate.Month;
		}

		public static bool IsSameYear(this DateTime firstDate, DateTime secondDate)
		{
			return firstDate.Year == secondDate.Year;
		}

		#region DateTimeOffset

		public static DateTimeOffset BeginningOfDay(this DateTimeOffset date) => new DateTimeOffset(date.Year, date.Month, date.Day, 0, 0, 0, date.Offset);

		public static DateTimeOffset EndOfDay(this DateTimeOffset date)
		{
			var endOfDay = new DateTimeOffset(date.Year, date.Month, date.Day, 0, 0, 0, date.Offset);
			endOfDay = endOfDay.AddDays(1);
			endOfDay = endOfDay.AddTicks(-1);

			return endOfDay;
		}

		public static DateTimeOffset BeginningOfMonth(this DateTimeOffset date)
		{
			return new DateTimeOffset(date.Year, date.Month, 1, 0, 0, 0, date.Offset);
		}

		public static DateTimeOffset BeginningOfWeek(this DateTimeOffset date, DayOfWeek startDayOfWeek = DayOfWeek.Monday)
		{
			int diff = (7 + (date.DayOfWeek - startDayOfWeek)) % 7;
			return date.AddDays(-1 * diff).Date;
		}

		public static DateTimeOffset EndOfWeek(this DateTimeOffset date, DayOfWeek startDayOfWeek = DayOfWeek.Monday)
		{
			return date.AddDays(7).BeginningOfWeek(startDayOfWeek).AddDays(-1).Date;
		}


		public static bool IsSameDay(this DateTimeOffset firstDate, DateTimeOffset secondDate)
		{
			return firstDate.IsSameMonth(secondDate) && firstDate.Day == secondDate.Day;
		}

		public static bool IsSameWeek(this DateTimeOffset firstDate, DateTimeOffset secondDate, DayOfWeek startDayOfWeek = DayOfWeek.Monday)
		{
			DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;

			int firstDateWeek = dfi.Calendar.GetWeekOfYear(firstDate.Date, dfi.CalendarWeekRule, startDayOfWeek);
			int secondDateWeek = dfi.Calendar.GetWeekOfYear(secondDate.Date, dfi.CalendarWeekRule, startDayOfWeek);

			return firstDateWeek == secondDateWeek;
		}

		public static bool IsSameMonth(this DateTimeOffset firstDate, DateTimeOffset secondDate)
		{
			return firstDate.IsSameYear(secondDate) && firstDate.Month == secondDate.Month;
		}

		public static bool IsSameYear(this DateTimeOffset firstDate, DateTimeOffset secondDate)
		{
			return firstDate.Year == secondDate.Year;
		}

		#endregion

		#region DateTimeCustomOffset

		public static DateTimeOffset BeginningOfDay(this DateTimeOffset date, TimeSpan offset) => BeginningOfDay(date.ToOffset(offset));

		public static DateTimeOffset EndOfDay(this DateTimeOffset date, TimeSpan offset) => EndOfDay(date.ToOffset(offset));

		public static DateTimeOffset BeginningOfMonth(this DateTimeOffset date, TimeSpan offset) => BeginningOfMonth(date.ToOffset(offset));

		public static DateTimeOffset BeginningOfWeek(this DateTimeOffset date, TimeSpan offset, DayOfWeek startDayOfWeek = DayOfWeek.Monday) => BeginningOfWeek(date.ToOffset(offset), startDayOfWeek);

		public static bool IsSameDay(this DateTimeOffset firstDate, DateTimeOffset secondDate, TimeSpan offset) => IsSameDay(firstDate.ToOffset(offset), secondDate.ToOffset(offset));

		public static bool IsSameWeek(this DateTimeOffset firstDate, DateTimeOffset secondDate, TimeSpan offset, DayOfWeek startDayOfWeek = DayOfWeek.Monday) => IsSameWeek(firstDate.ToOffset(offset), secondDate.ToOffset(offset), startDayOfWeek);

		public static bool IsSameMonth(this DateTimeOffset firstDate, DateTimeOffset secondDate, TimeSpan offset) => IsSameMonth(firstDate.ToOffset(offset), secondDate.ToOffset(offset));

		public static bool IsSameYear(this DateTimeOffset firstDate, DateTimeOffset secondDate, TimeSpan offset) => IsSameYear(firstDate.ToOffset(offset), secondDate.ToOffset(offset));

		#endregion

		public static IEnumerable<DateTimeOffset> Range(DateTimeOffset from, DateTimeOffset to, TimeSpan timeSpan)
		{
			for (DateTimeOffset dayIndex = from ; dayIndex <= to ; dayIndex = dayIndex.Add(timeSpan))
			{
				yield return dayIndex;
			}
		}

		/// <summary>
		/// Return the greatest date in all enumerable
		/// </summary>
		public static DateTime MaxMany(params IEnumerable<DateTime>[] enums) => enums.MaxMany();

		/// <summary>
		/// Return the greatest date in all enumerable
		/// </summary>
		public static DateTime MaxMany(this IEnumerable<IEnumerable<DateTime>> enums) => enums.SelectManySafe(x => x).Max();
	}
}