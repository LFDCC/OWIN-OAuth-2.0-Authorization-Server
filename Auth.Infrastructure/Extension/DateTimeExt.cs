using System;
using System.Collections.Generic;
using System.Linq;

namespace Auth.Infrastructure.Extension
{
    public static class DateTimeExt
    {
        /// <summary>
        /// DateTime 转时间戳
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static long ToUnixTimestamp(this DateTime target)
        {
            DateTimeOffset dto = new DateTimeOffset(target, TimeSpan.Zero);

            var ticks = DateTimeOffset.Now.ToUnixTimeSeconds();

            return ticks;
        }

        /// <summary>
        /// 时间戳转DateTime
        /// </summary>
        /// <param name="unixTime">This Unix Timestamp</param>
        /// <returns></returns>
        public static DateTime FromUnixTimestamp(this long unixTime)
        {
            DateTimeOffset dto = new DateTimeOffset(unixTime, TimeSpan.Zero);

            return dto.DateTime;
        }

        /// <summary>
        /// 获取当天的23:59
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static DateTime ToDayEnd(this DateTime target)
        {
            DateTime dateTime = target.Date;
            dateTime = dateTime.AddDays(1.0);
            return dateTime.AddMilliseconds(-1.0);
        }

        /// <summary>
        /// 获取周的第一天的日期
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="startOfWeek">星期的开始 (星期天/星期一)</param>
        /// <returns>The First Date of the week</returns>
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(-1 * diff).Date;
        }

        /// <summary>
        /// 获取月份的所有日期
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns></returns>
        public static IEnumerable<DateTime> DaysOfMonth(int year, int month)
        {
            return from day in Enumerable.Range(0, DateTime.DaysInMonth(year, month))
                   select new DateTime(year, month, day + 1);
        }

        /// <summary>
        /// 确定一个月中的第n个日期的DayOfWeek实例
        /// </summary>
        /// <returns></returns>
        /// <example>11/29/2011 would return 5, because it is the 5th Tuesday of each month</example>
        public static int WeekDayInstanceOfMonth(this DateTime dateTime)
        {
            int y = 0;
            return (from date in DaysOfMonth(dateTime.Year, dateTime.Month)
                    where dateTime.DayOfWeek.Equals(date.DayOfWeek)
                    select date into x
                    select new
                    {
                        n = ++y,
                        date = x
                    } into x
                    where x.date.Equals(new DateTime(dateTime.Year, dateTime.Month, dateTime.Day))
                    select x.n).FirstOrDefault();
        }

        /// <summary>
        /// Gets the total days in a month
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static int TotalDaysInMonth(this DateTime dateTime)
        {
            return DaysOfMonth(dateTime.Year, dateTime.Month).Count();
        }

        /// <summary>
        /// Takes any date and returns it's value as an Unspecified DateTime
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ToDateTimeUnspecified(this DateTime date)
        {
            if (date.Kind == DateTimeKind.Unspecified)
            {
                return date;
            }
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, DateTimeKind.Unspecified);
        }

        /// <summary>
        /// Trims the milliseconds off of a datetime
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime TrimMilliseconds(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Kind);
        }
    }
}