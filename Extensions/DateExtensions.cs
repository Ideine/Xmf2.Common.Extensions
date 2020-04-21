using System;
using System.Collections.Generic;
using System.Linq;

namespace Xmf2.Common.Extensions
{
	public static class DateExtensions
	{
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
		public static DateTime MaxMany(this IEnumerable<IEnumerable<DateTime>> enums) => enums.SelectMany(x => x ?? new List<DateTime>(0)).Max();
	}
}