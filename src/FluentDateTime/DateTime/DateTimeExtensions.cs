﻿using System.Globalization;
using FluentDate;

namespace FluentDateTime;

/// <summary>
/// Static class containing Fluent <see cref="DateTime"/> extension methods.
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// Returns a new <see cref="DateTime"/> that adds the value of the specified <see cref="FluentTimeSpan"/> to the value of this instance.
    /// </summary>
    [Pure]
    public static DateTime AddFluentTimeSpan(this DateTime dateTime, FluentTimeSpan timeSpan) =>
        dateTime.AddMonths(timeSpan.Months)
            .AddYears(timeSpan.Years)
            .Add(timeSpan.TimeSpan);

    /// <summary>
    /// Returns a new <see cref="DateTime"/> that subtracts the value of the specified <see cref="FluentTimeSpan"/> to the value of this instance.
    /// </summary>
    [Pure]
    public static DateTime SubtractFluentTimeSpan(this DateTime dateTime, FluentTimeSpan timeSpan) =>
        dateTime.AddMonths(-timeSpan.Months)
            .AddYears(-timeSpan.Years)
            .Subtract(timeSpan.TimeSpan);

    /// <summary>
    /// Returns the very end of the given day (the last millisecond of the last hour for the given <see cref="DateTime"/>).
    /// </summary>
    [Pure]
    public static DateTime EndOfDay(this DateTime date) =>
        new(date.Year, date.Month, date.Day, 23, 59, 59, 999, date.Kind);

    /// <summary>
    /// Returns the timezone-adjusted very end of the given day (the last millisecond of the last hour for the given <see cref="DateTime"/>).
    /// </summary>
    [Pure]
    public static DateTime EndOfDay(this DateTime date, int timeZoneOffset) =>
        new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999, date.Kind)
            .AddHours(timeZoneOffset);

    /// <summary>
    /// Returns the last day of the week changing the time to the very end of the day. Eg, 2011-12-24T06:40:20.005 => 2011-12-25T23:59:59.999
    /// </summary>
    [Pure]
    public static DateTime EndOfWeek(this DateTime date) =>
        date.LastDayOfWeek().EndOfDay();

    /// <summary>
    /// Returns the last day of the week changing the time to the very end of the day with timezone-adjusted. Eg, 2011-12-24T06:40:20.005 => 2011-12-25T23:59:59.999
    /// </summary>
    [Pure]
    public static DateTime EndOfWeek(this DateTime date, int timeZoneOffset) =>
        date.LastDayOfWeek().EndOfDay(timeZoneOffset);

    /// <summary>
    /// Returns the last day of the month changing the time to the very end of the day. Eg, 2011-12-24T06:40:20.005 => 2011-12-31T23:59:59.999
    /// </summary>
    [Pure]
    public static DateTime EndOfMonth(this DateTime date) =>
        date.LastDayOfMonth().EndOfDay();

    /// <summary>
    /// Returns the last day of the month changing the time to the very end of the day with timezone-adjusted. Eg, 2011-12-24T06:40:20.005 => 2011-12-31T23:59:59.999
    /// </summary>
    [Pure]
    public static DateTime EndOfMonth(this DateTime date, int timeZoneOffset) =>
        date.LastDayOfMonth().EndOfDay(timeZoneOffset);

    /// <summary>
    /// Returns the last day of the quarter changing the time to the very end of the day. Eg, 2011-12-24T06:40:20.005 => 2011-12-31T23:59:59.999
    /// </summary>
    [Pure]
    public static DateTime EndOfQuarter(this DateTime date) =>
        date.LastDayOfQuarter().EndOfDay();

    /// <summary>
    /// Returns the last day of the quarter changing the time to the very end of the day with timezone-adjusted. Eg, 2011-12-24T06:40:20.005 => 2011-12-31T23:59:59.999
    /// </summary>
    [Pure]
    public static DateTime EndOfQuarter(this DateTime date, int timeZoneOffset) =>
        date.LastDayOfQuarter().EndOfDay(timeZoneOffset);

    /// <summary>
    /// Returns the last day of the year changing the time to the very end of the day. Eg, 2011-12-24T06:40:20.005 => 2011-12-31T23:59:59.999
    /// </summary>
    [Pure]
    public static DateTime EndOfYear(this DateTime date) =>
        date.LastDayOfYear().EndOfDay();

    /// <summary>
    /// Returns the last day of the year changing the time to the very end of the day with timezone-adjusted. Eg, 2011-12-24T06:40:20.005 => 2011-12-31T23:59:59.999
    /// </summary>
    [Pure]
    public static DateTime EndOfYear(this DateTime date, int timeZoneOffset) =>
        date.LastDayOfYear().EndOfDay(timeZoneOffset);

    /// <summary>
    /// Returns the Start of the given day (the first millisecond of the given <see cref="DateTime"/>).
    /// </summary>
    [Pure]
    public static DateTime BeginningOfDay(this DateTime date) =>
        new(date.Year, date.Month, date.Day, 0, 0, 0, 0, date.Kind);

    /// <summary>
    /// Returns the timezone-adjusted Start of the given day (the first millisecond of the given <see cref="DateTime"/>).
    /// </summary>
    [Pure]
    public static DateTime BeginningOfDay(this DateTime date, int timezoneOffset) =>
        new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0, date.Kind)
            .AddHours(timezoneOffset);

    /// <summary>
    /// Returns the Start day of the week changing the time to the very start of the day. Eg, 2011-12-24T06:40:20.005 => 2011-12-19T00:00:00.000. <see cref="DateTime"/>
    /// </summary>
    [Pure]
    public static DateTime BeginningOfWeek(this DateTime date) =>
        date.FirstDayOfWeek().BeginningOfDay();

    /// <summary>
    /// Returns the Start day of the week changing the time to the very start of the day with timezone-adjusted. Eg, 2011-12-24T06:40:20.005 => 2011-12-19T00:00:00.000. <see cref="DateTime"/>
    /// </summary>
    [Pure]
    public static DateTime BeginningOfWeek(this DateTime date, int timezoneOffset) =>
        date.FirstDayOfWeek().BeginningOfDay(timezoneOffset);

    /// <summary>
    /// Returns the Start day of the month changing the time to the very start of the day. Eg, 2011-12-24T06:40:20.005 => 2011-12-01T00:00:00.000. <see cref="DateTime"/>
    /// </summary>
    [Pure]
    public static DateTime BeginningOfMonth(this DateTime date) =>
        date.FirstDayOfMonth().BeginningOfDay();

    /// <summary>
    /// Returns the Start day of the month changing the time to the very start of the day with timezone-adjusted. Eg, 2011-12-24T06:40:20.005 => 2011-12-01T00:00:00.000. <see cref="DateTime"/>
    /// </summary>
    [Pure]
    public static DateTime BeginningOfMonth(this DateTime date, int timezoneOffset) =>
        date.FirstDayOfMonth().BeginningOfDay(timezoneOffset);

    /// <summary>
    /// Returns the Start day of the quarter changing the time to the very start of the day. Eg, 2011-12-24T06:40:20.005 => 2011-10-01T00:00:00.000. <see cref="DateTime"/>
    /// </summary>
    [Pure]
    public static DateTime BeginningOfQuarter(this DateTime date) =>
        date.FirstDayOfQuarter().BeginningOfDay();

    /// <summary>
    /// Returns the Start day of the quarter changing the time to the very start of the day with timezone-adjusted. Eg, 2011-12-24T06:40:20.005 => 2011-10-01T00:00:00.000. <see cref="DateTime"/>
    /// </summary>
    [Pure]
    public static DateTime BeginningOfQuarter(this DateTime date, int timezoneOffset) =>
        date.FirstDayOfQuarter().BeginningOfDay(timezoneOffset);

    /// <summary>
    /// Returns the Start day of the year changing the time to the very start of the day. Eg, 2011-12-24T06:40:20.005 => 2011-01-01T00:00:00.000. <see cref="DateTime"/>
    /// </summary>
    [Pure]
    public static DateTime BeginningOfYear(this DateTime date) =>
        date.FirstDayOfYear().BeginningOfDay();

    /// <summary>
    /// Returns the Start day of the year changing the time to the very start of the day with timezone-adjusted. Eg, 2011-12-24T06:40:20.005 => 2011-01-01T00:00:00.000. <see cref="DateTime"/>
    /// </summary>
    [Pure]
    public static DateTime BeginningOfYear(this DateTime date, int timezoneOffset) =>
        date.FirstDayOfYear().BeginningOfDay(timezoneOffset);

    /// <summary>
    /// Returns the same date (same Day, Month, Hour, Minute, Second etc) in the next calendar year.
    /// If that day does not exist in next year in same month, number of missing days is added to the last day in same month next year.
    /// </summary>
    [Pure]
    public static DateTime NextYear(this DateTime start)
    {
        var nextYear = start.Year + 1;
        var numberOfDaysInSameMonthNextYear = DateTime.DaysInMonth(nextYear, start.Month);

        if (numberOfDaysInSameMonthNextYear < start.Day)
        {
            var differenceInDays = start.Day - numberOfDaysInSameMonthNextYear;
            var dateTime = new DateTime(nextYear, start.Month, numberOfDaysInSameMonthNextYear, start.Hour, start.Minute, start.Second, start.Millisecond, start.Kind);
            return dateTime + differenceInDays.Days();
        }
        return new(nextYear, start.Month, start.Day, start.Hour, start.Minute, start.Second, start.Millisecond, start.Kind);
    }

    /// <summary>
    /// Returns the same date (same Day, Month, Hour, Minute, Second etc) in the previous calendar year.
    /// If that day does not exist in previous year in same month, number of missing days is added to the last day in same month previous year.
    /// </summary>
    [Pure]
    public static DateTime PreviousYear(this DateTime start)
    {
        var previousYear = start.Year - 1;
        var numberOfDaysInSameMonthPreviousYear = DateTime.DaysInMonth(previousYear, start.Month);

        if (numberOfDaysInSameMonthPreviousYear < start.Day)
        {
            var differenceInDays = start.Day - numberOfDaysInSameMonthPreviousYear;
            var dateTime = new DateTime(previousYear, start.Month, numberOfDaysInSameMonthPreviousYear, start.Hour, start.Minute, start.Second, start.Millisecond, start.Kind);
            return dateTime + differenceInDays.Days();
        }
        return new(previousYear, start.Month, start.Day, start.Hour, start.Minute, start.Second, start.Millisecond, start.Kind);
    }

    /// <summary>
    /// Returns <see cref="DateTime"/> increased by 24 hours ie Next Day.
    /// </summary>
    [Pure]
    public static DateTime NextDay(this DateTime start) =>
        start + 1.Days();

    /// <summary>
    /// Returns <see cref="DateTime"/> decreased by 24h period ie Previous Day.
    /// </summary>
    [Pure]
    public static DateTime PreviousDay(this DateTime start) =>
        start - 1.Days();

    /// <summary>
    /// Returns first next occurrence of specified <see cref="DayOfWeek"/>.
    /// </summary>
    [Pure]
    public static DateTime Next(this DateTime start, DayOfWeek day)
    {
        do
        {
            start = start.NextDay();
        } while (start.DayOfWeek != day);

        return start;
    }

    /// <summary>
    /// Returns first next occurrence of specified <see cref="DayOfWeek"/>.
    /// </summary>
    [Pure]
    public static DateTime Previous(this DateTime start, DayOfWeek day)
    {
        do
        {
            start = start.PreviousDay();
        } while (start.DayOfWeek != day);

        return start;
    }

    /// <summary>
    /// Increases supplied <see cref="DateTime"/> for 7 days ie returns the Next Week.
    /// </summary>
    [Pure]
    public static DateTime WeekAfter(this DateTime start) =>
        start + 1.Weeks();

    /// <summary>
    /// Decreases supplied <see cref="DateTime"/> for 7 days ie returns the Previous Week.
    /// </summary>
    [Pure]
    public static DateTime WeekEarlier(this DateTime start) =>
        start - 1.Weeks();

    /// <summary>
    /// Increases the <see cref="DateTime"/> object with given <see cref="TimeSpan"/> value.
    /// </summary>
    [Pure]
    public static DateTime IncreaseTime(this DateTime startDate, TimeSpan toAdd) =>
        startDate + toAdd;

    /// <summary>
    /// Decreases the <see cref="DateTime"/> object with given <see cref="TimeSpan"/> value.
    /// </summary>
    [Pure]
    public static DateTime DecreaseTime(this DateTime startDate, TimeSpan toSubtract) =>
        startDate - toSubtract;

    /// <summary>
    /// Returns the original <see cref="DateTime"/> with Hour part changed to supplied hour parameter.
    /// </summary>
    [Pure]
    public static DateTime SetTime(this DateTime originalDate, int hour) =>
        new(originalDate.Year, originalDate.Month, originalDate.Day, hour, originalDate.Minute, originalDate.Second, originalDate.Millisecond, originalDate.Kind);

    /// <summary>
    /// Returns the original <see cref="DateTime"/> with Hour and Minute parts changed to supplied hour and minute parameters.
    /// </summary>
    [Pure]
    public static DateTime SetTime(this DateTime originalDate, int hour, int minute) =>
        new(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, originalDate.Second, originalDate.Millisecond, originalDate.Kind);

    /// <summary>
    /// Returns the original <see cref="DateTime"/> with Hour, Minute and Second parts changed to supplied hour, minute and second parameters.
    /// </summary>
    [Pure]
    public static DateTime SetTime(this DateTime originalDate, int hour, int minute, int second) =>
        new(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, second, originalDate.Millisecond, originalDate.Kind);

    /// <summary>
    /// Returns the original <see cref="DateTime"/> with Hour, Minute, Second and Millisecond parts changed to supplied hour, minute, second and millisecond parameters.
    /// </summary>
    [Pure]
    public static DateTime SetTime(this DateTime originalDate, int hour, int minute, int second, int millisecond) =>
        new(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, second, millisecond, originalDate.Kind);

    /// <summary>
    /// Returns <see cref="DateTime"/> with changed Hour part.
    /// </summary>
    [Pure]
    public static DateTime SetHour(this DateTime originalDate, int hour) =>
        new(originalDate.Year, originalDate.Month, originalDate.Day, hour, originalDate.Minute, originalDate.Second, originalDate.Millisecond, originalDate.Kind);

    /// <summary>
    /// Returns <see cref="DateTime"/> with changed Minute part.
    /// </summary>
    [Pure]
    public static DateTime SetMinute(this DateTime originalDate, int minute) =>
        new(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, minute, originalDate.Second, originalDate.Millisecond, originalDate.Kind);

    /// <summary>
    /// Returns <see cref="DateTime"/> with changed Second part.
    /// </summary>
    [Pure]
    public static DateTime SetSecond(this DateTime originalDate, int second) =>
        new(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, originalDate.Minute, second, originalDate.Millisecond, originalDate.Kind);

    /// <summary>
    /// Returns <see cref="DateTime"/> with changed Millisecond part.
    /// </summary>
    [Pure]
    public static DateTime SetMillisecond(this DateTime originalDate, int millisecond) =>
        new(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, originalDate.Minute, originalDate.Second, millisecond, originalDate.Kind);

    /// <summary>
    /// Returns original <see cref="DateTime"/> value with time part set to midnight (alias for <see cref="BeginningOfDay(DateTime)"/> method).
    /// </summary>
    [Pure]
    public static DateTime Midnight(this DateTime value) =>
        value.BeginningOfDay();

    /// <summary>
    /// Returns original <see cref="DateTime"/> value with time part set to Noon (12:00:00h).
    /// </summary>
    /// <param name="value">The <see cref="DateTime"/> find Noon for.</param>
    /// <returns>A <see cref="DateTime"/> value with time part set to Noon (12:00:00h).</returns>
    [Pure]
    public static DateTime Noon(this DateTime value) =>
        value.SetTime(12, 0, 0, 0);

    /// <summary>
    /// Returns <see cref="DateTime"/> with changed Year part.
    /// </summary>
    [Pure]
    public static DateTime SetDate(this DateTime value, int year) =>
        new(year, value.Month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Kind);

    /// <summary>
    /// Returns <see cref="DateTime"/> with changed Year and Month part.
    /// </summary>
    [Pure]
    public static DateTime SetDate(this DateTime value, int year, int month) =>
        new(year, month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Kind);

    /// <summary>
    /// Returns <see cref="DateTime"/> with changed Year, Month and Day part.
    /// </summary>
    [Pure]
    public static DateTime SetDate(this DateTime value, int year, int month, int day) =>
        new(year, month, day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Kind);

    /// <summary>
    /// Returns <see cref="DateTime"/> with changed Year part.
    /// </summary>
    [Pure]
    public static DateTime SetYear(this DateTime value, int year) =>
        new(year, value.Month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Kind);

    /// <summary>
    /// Returns <see cref="DateTime"/> with changed Month part.
    /// </summary>
    [Pure]
    public static DateTime SetMonth(this DateTime value, int month) =>
        new(value.Year, month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Kind);

    /// <summary>
    /// Returns <see cref="DateTime"/> with changed Day part.
    /// </summary>
    [Pure]
    public static DateTime SetDay(this DateTime value, int day) =>
        new(value.Year, value.Month, day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Kind);

    /// <summary>
    /// Determines whether the specified <see cref="DateTime"/> is before then current value.
    /// </summary>
    /// <param name="current">The current value.</param>
    /// <param name="toCompareWith">Value to compare with.</param>
    /// <returns>
    /// <c>true</c> if the specified current is before; otherwise, <c>false</c>.
    /// </returns>
    [Pure]
    public static bool IsBefore(this DateTime current, DateTime toCompareWith) =>
        current < toCompareWith;

    /// <summary>
    /// Determines whether the specified <see cref="DateTime"/> value is After then current value.
    /// </summary>
    /// <param name="current">The current value.</param>
    /// <param name="toCompareWith">Value to compare with.</param>
    /// <returns>
    /// <c>true</c> if the specified current is after; otherwise, <c>false</c>.
    /// </returns>
    [Pure]
    public static bool IsAfter(this DateTime current, DateTime toCompareWith) =>
        current > toCompareWith;

    /// <summary>
    /// Returns the given <see cref="DateTime"/> with hour and minutes set At given values.
    /// </summary>
    /// <param name="current">The current <see cref="DateTime"/> to be changed.</param>
    /// <param name="hour">The hour to set time to.</param>
    /// <param name="minute">The minute to set time to.</param>
    /// <returns><see cref="DateTime"/> with hour and minute set to given values.</returns>
    [Pure]
    public static DateTime At(this DateTime current, int hour, int minute) =>
        current.SetTime(hour, minute);

    /// <summary>
    /// Returns the given <see cref="DateTime"/> with hour and minutes and seconds set At given values.
    /// </summary>
    /// <param name="current">The current <see cref="DateTime"/> to be changed.</param>
    /// <param name="hour">The hour to set time to.</param>
    /// <param name="minute">The minute to set time to.</param>
    /// <param name="second">The second to set time to.</param>
    /// <returns><see cref="DateTime"/> with hour and minutes and seconds set to given values.</returns>
    [Pure]
    public static DateTime At(this DateTime current, int hour, int minute, int second) =>
        current.SetTime(hour, minute, second);

    /// <summary>
    /// Returns the given <see cref="DateTime"/> with hour and minutes and seconds and milliseconds set At given values.
    /// </summary>
    /// <param name="current">The current <see cref="DateTime"/> to be changed.</param>
    /// <param name="hour">The hour to set time to.</param>
    /// <param name="minute">The minute to set time to.</param>
    /// <param name="second">The second to set time to.</param>
    /// <param name="milliseconds">The milliseconds to set time to.</param>
    /// <returns><see cref="DateTime"/> with hour and minutes and seconds set to given values.</returns>
    [Pure]
    public static DateTime At(this DateTime current, int hour, int minute, int second, int milliseconds) =>
        current.SetTime(hour, minute, second, milliseconds);

    /// <summary>
    /// Sets the day of the <see cref="DateTime"/> to the first day in that calendar quarter.
    /// credit to http://www.devcurry.com/2009/05/find-first-and-last-day-of-current.html
    /// </summary>
    /// <returns>given <see cref="DateTime"/> with the day part set to the first day in the quarter.</returns>
    [Pure]
    public static DateTime FirstDayOfQuarter(this DateTime current)
    {
        var currentQuarter = (current.Month - 1) / 3 + 1;
        var firstDay = new DateTime(current.Year, 3 * currentQuarter - 2, 1);

        return current.SetDate(firstDay.Year, firstDay.Month, firstDay.Day);
    }

    /// <summary>
    /// Sets the day of the <see cref="DateTime"/> to the first day in that month.
    /// </summary>
    /// <param name="current">The current <see cref="DateTime"/> to be changed.</param>
    /// <returns>given <see cref="DateTime"/> with the day part set to the first day in that month.</returns>
    [Pure]
    public static DateTime FirstDayOfMonth(this DateTime current) =>
        current.SetDay(1);

    /// <summary>
    /// Sets the day of the <see cref="DateTime"/> to the last day in that calendar quarter.
    /// credit to http://www.devcurry.com/2009/05/find-first-and-last-day-of-current.html
    /// </summary>
    /// <returns>given <see cref="DateTime"/> with the day part set to the last day in the quarter.</returns>
    [Pure]
    public static DateTime LastDayOfQuarter(this DateTime current)
    {
        var currentQuarter = (current.Month - 1) / 3 + 1;
        var firstDay = current.SetDate(current.Year, 3 * currentQuarter - 2, 1);
        return firstDay.SetMonth(firstDay.Month + 2).LastDayOfMonth();
    }

    /// <summary>
    /// Sets the day of the <see cref="DateTime"/> to the last day in that month.
    /// </summary>
    /// <param name="current">The current DateTime to be changed.</param>
    /// <returns>given <see cref="DateTime"/> with the day part set to the last day in that month.</returns>
    [Pure]
    public static DateTime LastDayOfMonth(this DateTime current) =>
        current.SetDay(DateTime.DaysInMonth(current.Year, current.Month));

    /// <summary>
    /// Adds the given number of business days to the <see cref="DateTime"/>.
    /// </summary>
    /// <param name="current">The date to be changed.</param>
    /// <param name="days">Number of business days to be added.</param>
    /// <returns>A <see cref="DateTime"/> increased by a given number of business days.</returns>
    [Pure]
    public static DateTime AddBusinessDays(this DateTime current, int days)
    {
        var sign = Math.Sign(days);
        var unsignedDays = Math.Abs(days);
        for (var i = 0; i < unsignedDays; i++)
        {
            current = current.AddDays(sign);
            if (current.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
            {
                i--;
            }
        }
        return current;
    }

    /// <summary>
    /// Subtracts the given number of business days to the <see cref="DateTime"/>.
    /// </summary>
    /// <param name="current">The date to be changed.</param>
    /// <param name="days">Number of business days to be subtracted.</param>
    /// <returns>A <see cref="DateTime"/> increased by a given number of business days.</returns>
    [Pure]
    public static DateTime SubtractBusinessDays(this DateTime current, int days) =>
        AddBusinessDays(current, -days);

    /// <summary>
    /// Determine if a <see cref="DateTime"/> is in the future.
    /// </summary>
    /// <param name="dateTime">The date to be checked.</param>
    /// <returns><c>true</c> if <paramref name="dateTime"/> is in the future; otherwise <c>false</c>.</returns>
    [Pure]
    public static bool IsInFuture(this DateTime dateTime) =>
        dateTime > DateTime.Now;

    /// <summary>
    /// Determine if a <see cref="DateTime"/> is in the past.
    /// </summary>
    /// <param name="dateTime">The date to be checked.</param>
    /// <returns><c>true</c> if <paramref name="dateTime"/> is in the past; otherwise <c>false</c>.</returns>
    [Pure]
    public static bool IsInPast(this DateTime dateTime) =>
        dateTime < DateTime.Now;

    /// <summary>
    /// Rounds <paramref name="dateTime"/> to the nearest <see cref="RoundTo"/>.
    /// </summary>
    /// <returns>The rounded <see cref="DateTime"/>.</returns>
    [Pure]
    public static DateTime Round(this DateTime dateTime, RoundTo rt)
    {
        DateTime rounded;

        switch (rt)
        {
            case RoundTo.Second:
            {
                rounded = new(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Kind);
                if (dateTime.Millisecond >= 500)
                {
                    rounded = rounded.AddSeconds(1);
                }
                break;
            }
            case RoundTo.Minute:
            {
                rounded = new(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0, dateTime.Kind);
                if (dateTime.Second >= 30)
                {
                    rounded = rounded.AddMinutes(1);
                }
                break;
            }
            case RoundTo.Hour:
            {
                rounded = new(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 0, 0, dateTime.Kind);
                if (dateTime.Minute >= 30)
                {
                    rounded = rounded.AddHours(1);
                }
                break;
            }
            case RoundTo.Day:
            {
                rounded = new(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, dateTime.Kind);
                if (dateTime.Hour >= 12)
                {
                    rounded = rounded.AddDays(1);
                }
                break;
            }
            default:
            {
                throw new ArgumentOutOfRangeException(nameof(rt));
            }
        }

        return rounded;
    }

    /// <summary>
    /// Returns a DateTime adjusted to the beginning of the week.
    /// </summary>
    /// <param name="dateTime">The DateTime to adjust</param>
    /// <returns>A DateTime instance adjusted to the beginning of the current week</returns>
    /// <remarks>the beginning of the week is controlled by the current Culture</remarks>
    [Pure]
    public static DateTime FirstDayOfWeek(this DateTime dateTime)
    {
        var currentCulture = CultureInfo.CurrentCulture;
        var firstDayOfWeek = currentCulture.DateTimeFormat.FirstDayOfWeek;
        var offset = dateTime.DayOfWeek - firstDayOfWeek < 0 ? 7 : 0;
        var numberOfDaysSinceBeginningOfTheWeek = dateTime.DayOfWeek + offset - firstDayOfWeek;

        return dateTime.AddDays(-numberOfDaysSinceBeginningOfTheWeek);
    }

    /// <summary>
    /// Obsolete. This method has been renamed to FirstDayOfWeek to be more consistent with existing conventions.
    /// </summary>
    [Obsolete("This method has been renamed to FirstDayOfWeek to be more consistent with existing conventions.")]
    [Pure]
    public static DateTime StartOfWeek(this DateTime dateTime) =>
        FirstDayOfWeek(dateTime);

    /// <summary>
    /// Returns the first day of the year keeping the time component intact. Eg, 2011-02-04T06:40:20.005 => 2011-01-01T06:40:20.005
    /// </summary>
    /// <param name="current">The DateTime to adjust</param>
    [Pure]
    public static DateTime FirstDayOfYear(this DateTime current) =>
        current.SetDate(current.Year, 1, 1);

    /// <summary>
    /// Returns the last day of the week keeping the time component intact. Eg, 2011-12-24T06:40:20.005 => 2011-12-25T06:40:20.005
    /// </summary>
    /// <param name="current">The DateTime to adjust</param>
    [Pure]
    public static DateTime LastDayOfWeek(this DateTime current) =>
        current.FirstDayOfWeek().AddDays(6);

    /// <summary>
    /// Returns the last day of the year keeping the time component intact. Eg, 2011-12-24T06:40:20.005 => 2011-12-31T06:40:20.005
    /// </summary>
    /// <param name="current">The DateTime to adjust</param>
    [Pure]
    public static DateTime LastDayOfYear(this DateTime current) =>
        current.SetDate(current.Year, 12, 31);

    /// <summary>
    /// Returns the previous month keeping the time component intact. Eg, 2010-01-20T06:40:20.005 => 2009-12-20T06:40:20.005
    /// If the previous month doesn't have that many days the last day of the previous month is used. Eg, 2009-03-31T06:40:20.005 => 2009-02-28T06:40:20.005
    /// </summary>
    /// <param name="current">The DateTime to adjust</param>
    [Pure]
    public static DateTime PreviousMonth(this DateTime current)
    {
        var year = current.Month == 1 ? current.Year - 1 : current.Year;

        var month = current.Month == 1 ? 12 : current.Month - 1;

        var firstDayOfPreviousMonth = current.SetDate(year, month, 1);

        var lastDayOfPreviousMonth = firstDayOfPreviousMonth.LastDayOfMonth().Day;

        var day = current.Day > lastDayOfPreviousMonth ? lastDayOfPreviousMonth : current.Day;

        return firstDayOfPreviousMonth.SetDay(day);
    }

    /// <summary>
    /// Returns the next month keeping the time component intact. Eg, 2012-12-05T06:40:20.005 => 2013-01-05T06:40:20.005
    /// If the next month doesn't have that many days the last day of the next month is used. Eg, 2013-01-31T06:40:20.005 => 2013-02-28T06:40:20.005
    /// </summary>
    /// <param name="current">The DateTime to adjust</param>
    [Pure]
    public static DateTime NextMonth(this DateTime current)
    {

        var year = current.Month == 12 ? current.Year + 1 : current.Year;

        var month = current.Month == 12 ? 1 : current.Month + 1;

        var firstDayOfNextMonth = current.SetDate(year, month, 1);

        var lastDayOfPreviousMonth = firstDayOfNextMonth.LastDayOfMonth().Day;

        var day = current.Day > lastDayOfPreviousMonth ? lastDayOfPreviousMonth : current.Day;

        return firstDayOfNextMonth.SetDay(day);
    }

    /// <summary>
    /// Determines whether the specified <see cref="DateTime"/> value is exactly the same day (day + month + year) then current
    /// </summary>
    /// <param name="current">The current value</param>
    /// <param name="date">Value to compare with</param>
    /// <returns>
    /// <c>true</c> if the specified date is exactly the same year then current; otherwise, <c>false</c>.
    /// </returns>
    [Pure]
    public static bool SameDay(this DateTime current, DateTime date) =>
        current.Date == date.Date;

    /// <summary>
    /// Determines whether the specified <see cref="DateTime"/> value is exactly the same month (month + year) then current. Eg, 2015-12-01 and 2014-12-01 => False
    /// </summary>
    /// <param name="current">The current value</param>
    /// <param name="date">Value to compare with</param>
    /// <returns>
    /// <c>true</c> if the specified date is exactly the same month and year then current; otherwise, <c>false</c>.
    /// </returns>
    [Pure]
    public static bool SameMonth(this DateTime current, DateTime date) =>
        current.Month == date.Month && current.Year == date.Year;

    /// <summary>
    /// Determines whether the specified <see cref="DateTime"/> value is exactly the same year then current. Eg, 2015-12-01 and 2015-01-01 => True
    /// </summary>
    /// <param name="current">The current value</param>
    /// <param name="date">Value to compare with</param>
    /// <returns>
    /// <c>true</c> if the specified date is exactly the same date then current; otherwise, <c>false</c>.
    /// </returns>
    [Pure]
    public static bool SameYear(this DateTime current, DateTime date) =>
        current.Year == date.Year;
}