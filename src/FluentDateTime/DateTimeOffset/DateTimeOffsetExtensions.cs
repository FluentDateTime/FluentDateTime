using System.Globalization;
using FluentDate;

namespace FluentDateTimeOffset;

/// <summary>
/// Static class containing Fluent <see cref="DateTimeOffset"/> extension methods.
/// </summary>
public static class DateTimeOffsetExtensions
{
    /// <summary>
    /// Returns a new <see cref="DateTime"/> that adds the value of the specified <see cref="FluentTimeSpan"/> to the value of this instance.
    /// </summary>
    public static DateTimeOffset AddFluentTimeSpan(this DateTimeOffset dateTimeOffset, FluentTimeSpan timeSpan) =>
        dateTimeOffset.AddMonths(timeSpan.Months)
            .AddYears(timeSpan.Years)
            .Add(timeSpan.TimeSpan);

    /// <summary>
    /// Returns a new <see cref="DateTime"/> that subtracts the value of the specified <see cref="FluentTimeSpan"/> to the value of this instance.
    /// </summary>
    public static DateTimeOffset SubtractFluentTimeSpan(this DateTimeOffset dateTimeOffset, FluentTimeSpan timeSpan) =>
        dateTimeOffset.AddMonths(-timeSpan.Months)
            .AddYears(-timeSpan.Years)
            .Subtract(timeSpan.TimeSpan);

    /// <summary>
    /// Returns the very end of the given day (the last millisecond of the last hour for the given <see cref="DateTimeOffset"/>).
    /// </summary>
    public static DateTimeOffset EndOfDay(this DateTimeOffset date) =>
        new(date.Year, date.Month, date.Day, 23, 59, 59, 999, date.Offset);

    /// <summary>
    /// Returns the Start of the given day (the first millisecond of the given <see cref="DateTimeOffset"/>).
    /// </summary>
    public static DateTimeOffset BeginningOfDay(this DateTimeOffset date) =>
        new(date.Year, date.Month, date.Day, 0, 0, 0, date.Offset);

    /// <summary>
    /// Returns the same date (same Day, Month, Hour, Minute, Second etc) in the next calendar year.
    /// If that day does not exist in next year in same month, number of missing days is added to the last day in same month next year.
    /// </summary>
    public static DateTimeOffset NextYear(this DateTimeOffset start)
    {
        var nextYear = start.Year + 1;
        var numberOfDaysInSameMonthNextYear = DateTime.DaysInMonth(nextYear, start.Month);

        if (numberOfDaysInSameMonthNextYear < start.Day)
        {
            var differenceInDays = start.Day - numberOfDaysInSameMonthNextYear;
            var dateTimeOffset = new DateTimeOffset(nextYear, start.Month, numberOfDaysInSameMonthNextYear, start.Hour, start.Minute, start.Second, start.Millisecond, start.Offset);
            return dateTimeOffset + differenceInDays.Days();
        }

        return new(nextYear, start.Month, start.Day, start.Hour, start.Minute, start.Second, start.Millisecond, start.Offset);
    }

    /// <summary>
    /// Returns the same date (same Day, Month, Hour, Minute, Second etc) in the previous calendar year.
    /// If that day does not exist in previous year in same month, number of missing days is added to the last day in same month previous year.
    /// </summary>
    public static DateTimeOffset PreviousYear(this DateTimeOffset start)
    {
        var previousYear = start.Year - 1;
        var numberOfDaysInSameMonthPreviousYear = DateTime.DaysInMonth(previousYear, start.Month);

        if (numberOfDaysInSameMonthPreviousYear < start.Day)
        {
            var differenceInDays = start.Day - numberOfDaysInSameMonthPreviousYear;
            var dateTime = new DateTimeOffset(previousYear, start.Month, numberOfDaysInSameMonthPreviousYear, start.Hour, start.Minute, start.Second, start.Millisecond, start.Offset);
            return dateTime + differenceInDays.Days();
        }

        return new(previousYear, start.Month, start.Day, start.Hour, start.Minute, start.Second, start.Millisecond, start.Offset);
    }

    /// <summary>
    /// Returns <see cref="DateTimeOffset"/> increased by 24 hours ie Next Day.
    /// </summary>
    public static DateTimeOffset NextDay(this DateTimeOffset start) =>
        start + 1.Days();

    /// <summary>
    /// Returns <see cref="DateTimeOffset"/> decreased by 24h period ie Previous Day.
    /// </summary>
    public static DateTimeOffset PreviousDay(this DateTimeOffset start) =>
        start - 1.Days();

    /// <summary>
    /// Returns first next occurrence of specified <see cref="DayOfWeek"/>.
    /// </summary>
    public static DateTimeOffset Next(this DateTimeOffset start, DayOfWeek day)
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
    public static DateTimeOffset Previous(this DateTimeOffset start, DayOfWeek day)
    {
        do
        {
            start = start.PreviousDay();
        } while (start.DayOfWeek != day);

        return start;
    }

    /// <summary>
    /// Increases supplied <see cref="DateTimeOffset"/> for 7 days ie returns the Next Week.
    /// </summary>
    public static DateTimeOffset WeekAfter(this DateTimeOffset start) =>
        start + 1.Weeks();

    /// <summary>
    /// Decreases supplied <see cref="DateTimeOffset"/> for 7 days ie returns the Previous Week.
    /// </summary>
    public static DateTimeOffset WeekEarlier(this DateTimeOffset start) =>
        start - 1.Weeks();

    /// <summary>
    /// Increases the <see cref="DateTimeOffset"/> object with given <see cref="TimeSpan"/> value.
    /// </summary>
    public static DateTimeOffset IncreaseTime(this DateTimeOffset startDate, TimeSpan toAdd) =>
        startDate + toAdd;

    /// <summary>
    /// Decreases the <see cref="DateTimeOffset"/> object with given <see cref="TimeSpan"/> value.
    /// </summary>
    public static DateTimeOffset DecreaseTime(this DateTimeOffset startDate, TimeSpan toSubtract) =>
        startDate - toSubtract;

    /// <summary>
    /// Returns the original <see cref="DateTimeOffset"/> with Hour part changed to supplied hour parameter.
    /// </summary>
    public static DateTimeOffset SetTime(this DateTimeOffset originalDate, int hour) =>
        new(originalDate.Year, originalDate.Month, originalDate.Day, hour, originalDate.Minute, originalDate.Second, originalDate.Millisecond, originalDate.Offset);

    /// <summary>
    /// Returns the original <see cref="DateTimeOffset"/> with Hour and Minute parts changed to supplied hour and minute parameters.
    /// </summary>
    public static DateTimeOffset SetTime(this DateTimeOffset originalDate, int hour, int minute) =>
        new(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, originalDate.Second, originalDate.Millisecond, originalDate.Offset);

    /// <summary>
    /// Returns the original <see cref="DateTimeOffset"/> with Hour, Minute and Second parts changed to supplied hour, minute and second parameters.
    /// </summary>
    public static DateTimeOffset SetTime(this DateTimeOffset originalDate, int hour, int minute, int second) =>
        new(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, second, originalDate.Millisecond, originalDate.Offset);

    /// <summary>
    /// Returns the original <see cref="DateTimeOffset"/> with Hour, Minute, Second and Millisecond parts changed to supplied hour, minute, second and millisecond parameters.
    /// </summary>
    public static DateTimeOffset SetTime(this DateTimeOffset originalDate, int hour, int minute, int second, int millisecond) =>
        new(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, second, millisecond, originalDate.Offset);

    /// <summary>
    /// Returns <see cref="DateTimeOffset"/> with changed Hour part.
    /// </summary>
    public static DateTimeOffset SetHour(this DateTimeOffset originalDate, int hour) =>
        new(originalDate.Year, originalDate.Month, originalDate.Day, hour, originalDate.Minute, originalDate.Second, originalDate.Millisecond, originalDate.Offset);

    /// <summary>
    /// Returns <see cref="DateTimeOffset"/> with changed Minute part.
    /// </summary>
    public static DateTimeOffset SetMinute(this DateTimeOffset originalDate, int minute) =>
        new(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, minute, originalDate.Second, originalDate.Millisecond, originalDate.Offset);

    /// <summary>
    /// Returns <see cref="DateTimeOffset"/> with changed Second part.
    /// </summary>
    public static DateTimeOffset SetSecond(this DateTimeOffset originalDate, int second) =>
        new(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, originalDate.Minute, second, originalDate.Millisecond, originalDate.Offset);

    /// <summary>
    /// Returns <see cref="DateTimeOffset"/> with changed Millisecond part.
    /// </summary>
    public static DateTimeOffset SetMillisecond(this DateTimeOffset originalDate, int millisecond) =>
        new(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, originalDate.Minute, originalDate.Second, millisecond, originalDate.Offset);

    /// <summary>
    /// Returns original <see cref="DateTimeOffset"/> value with time part set to midnight (alias for <see cref="BeginningOfDay"/> method).
    /// </summary>
    public static DateTimeOffset Midnight(this DateTimeOffset value) =>
        value.BeginningOfDay();

    /// <summary>
    /// Returns original <see cref="DateTimeOffset"/> value with time part set to Noon (12:00:00h).
    /// </summary>
    /// <param name="value">The <see cref="DateTimeOffset"/> find Noon for.</param>
    /// <returns>A <see cref="DateTimeOffset"/> value with time part set to Noon (12:00:00h).</returns>
    public static DateTimeOffset Noon(this DateTimeOffset value) =>
        value.SetTime(12, 0, 0, 0);

    /// <summary>
    /// Returns <see cref="DateTimeOffset"/> with changed Year part.
    /// </summary>
    public static DateTimeOffset SetDate(this DateTimeOffset value, int year) =>
        new(year, value.Month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);

    /// <summary>
    /// Returns <see cref="DateTimeOffset"/> with changed Year and Month part.
    /// </summary>
    public static DateTimeOffset SetDate(this DateTimeOffset value, int year, int month) =>
        new(year, month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);

    /// <summary>
    /// Returns <see cref="DateTimeOffset"/> with changed Year, Month and Day part.
    /// </summary>
    public static DateTimeOffset SetDate(this DateTimeOffset value, int year, int month, int day) =>
        new(year, month, day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);

    /// <summary>
    /// Returns <see cref="DateTimeOffset"/> with changed Year part.
    /// </summary>
    public static DateTimeOffset SetYear(this DateTimeOffset value, int year) =>
        new(year, value.Month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);

    /// <summary>
    /// Returns <see cref="DateTimeOffset"/> with changed Month part.
    /// </summary>
    public static DateTimeOffset SetMonth(this DateTimeOffset value, int month) =>
        new(value.Year, month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);

    /// <summary>
    /// Returns <see cref="DateTimeOffset"/> with changed Day part.
    /// </summary>
    public static DateTimeOffset SetDay(this DateTimeOffset value, int day) =>
        new(value.Year, value.Month, day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);

    /// <summary>
    /// Determines whether the specified <see cref="DateTimeOffset"/> is before then current value.
    /// </summary>
    /// <param name="current">The current value.</param>
    /// <param name="toCompareWith">Value to compare with.</param>
    /// <returns>
    /// 	<c>true</c> if the specified current is before; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsBefore(this DateTimeOffset current, DateTimeOffset toCompareWith) =>
        current < toCompareWith;

    /// <summary>
    /// Determines whether the specified <see cref="DateTimeOffset"/> value is After then current value.
    /// </summary>
    /// <param name="current">The current value.</param>
    /// <param name="toCompareWith">Value to compare with.</param>
    /// <returns>
    /// 	<c>true</c> if the specified current is after; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsAfter(this DateTimeOffset current, DateTimeOffset toCompareWith) =>
        current > toCompareWith;

    /// <summary>
    /// Returns the given <see cref="DateTimeOffset"/> with hour and minutes set At given values.
    /// </summary>
    /// <param name="current">The current <see cref="DateTimeOffset"/> to be changed.</param>
    /// <param name="hour">The hour to set time to.</param>
    /// <param name="minute">The minute to set time to.</param>
    /// <returns><see cref="DateTimeOffset"/> with hour and minute set to given values.</returns>
    public static DateTimeOffset At(this DateTimeOffset current, int hour, int minute) =>
        current.SetTime(hour, minute);

    /// <summary>
    /// Returns the given <see cref="DateTimeOffset"/> with hour and minutes and seconds set At given values.
    /// </summary>
    /// <param name="current">The current <see cref="DateTimeOffset"/> to be changed.</param>
    /// <param name="hour">The hour to set time to.</param>
    /// <param name="minute">The minute to set time to.</param>
    /// <param name="second">The second to set time to.</param>
    /// <returns><see cref="DateTimeOffset"/> with hour and minutes and seconds set to given values.</returns>
    public static DateTimeOffset At(this DateTimeOffset current, int hour, int minute, int second) =>
        current.SetTime(hour, minute, second);

    /// <summary>
    /// Returns the given <see cref="DateTimeOffset"/> with hour and minutes and seconds and milliseconds set At given values.
    /// </summary>
    /// <param name="current">The current <see cref="DateTimeOffset"/> to be changed.</param>
    /// <param name="hour">The hour to set time to.</param>
    /// <param name="minute">The minute to set time to.</param>
    /// <param name="second">The second to set time to.</param>
    /// <param name="milliseconds">The milliseconds to set time to.</param>
    /// <returns><see cref="DateTimeOffset"/> with hour and minutes and seconds set to given values.</returns>
    public static DateTimeOffset At(this DateTimeOffset current, int hour, int minute, int second, int milliseconds) =>
        current.SetTime(hour, minute, second, milliseconds);

    /// <summary>
    /// Sets the day of the <see cref="DateTimeOffset"/> to the first day in that calendar quarter.
    /// credit to http://www.devcurry.com/2009/05/find-first-and-last-day-of-current.html
    /// </summary>
    /// <param name="current"></param>
    /// <returns>given <see cref="DateTimeOffset"/> with the day part set to the first day in the quarter.</returns>
    public static DateTimeOffset FirstDayOfQuarter(this DateTimeOffset current)
    {
        var currentQuarter = (current.Month - 1) / 3 + 1;
        return current.SetDate(current.Year, 3 * currentQuarter - 2, 1);
    }

    /// <summary>
    /// Sets the day of the <see cref="DateTimeOffset"/> to the first day in that month.
    /// </summary>
    /// <param name="current">The current <see cref="DateTimeOffset"/> to be changed.</param>
    /// <returns>given <see cref="DateTimeOffset"/> with the day part set to the first day in that month.</returns>
    public static DateTimeOffset FirstDayOfMonth(this DateTimeOffset current) =>
        current.SetDay(1);

    /// <summary>
    /// Sets the day of the <see cref="DateTimeOffset"/> to the last day in that calendar quarter.
    /// credit to http://www.devcurry.com/2009/05/find-first-and-last-day-of-current.html
    /// </summary>
    /// <param name="current"></param>
    /// <returns>given <see cref="DateTimeOffset"/> with the day part set to the last day in the quarter.</returns>
    public static DateTimeOffset LastDayOfQuarter(this DateTimeOffset current)
    {
        var currentQuarter = (current.Month - 1) / 3 + 1;
        var firstDay = current.SetDate(current.Year, 3 * currentQuarter - 2, 1);
        return firstDay.SetMonth(firstDay.Month + 2).LastDayOfMonth();
    }

    /// <summary>
    /// Sets the day of the <see cref="DateTimeOffset"/> to the last day in that month.
    /// </summary>
    /// <param name="current">The current DateTimeOffset to be changed.</param>
    /// <returns>given <see cref="DateTimeOffset"/> with the day part set to the last day in that month.</returns>
    public static DateTimeOffset LastDayOfMonth(this DateTimeOffset current) =>
        current.SetDay(DateTime.DaysInMonth(current.Year, current.Month));

    /// <summary>
    /// Adds the given number of business days to the <see cref="DateTimeOffset"/>.
    /// </summary>
    /// <param name="current">The date to be changed.</param>
    /// <param name="days">Number of business days to be added.</param>
    /// <returns>A <see cref="DateTimeOffset"/> increased by a given number of business days.</returns>
    public static DateTimeOffset AddBusinessDays(this DateTimeOffset current, int days)
    {
        var sign = Math.Sign(days);
        var unsignedDays = Math.Abs(days);
        for (var i = 0; i < unsignedDays; i++)
        {
            do
            {
                current = current.AddDays(sign);
            } while (current.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday);
        }

        return current;
    }

    /// <summary>
    /// Subtracts the given number of business days to the <see cref="DateTimeOffset"/>.
    /// </summary>
    /// <param name="current">The date to be changed.</param>
    /// <param name="days">Number of business days to be subtracted.</param>
    /// <returns>A <see cref="DateTimeOffset"/> increased by a given number of business days.</returns>
    public static DateTimeOffset SubtractBusinessDays(this DateTimeOffset current, int days) =>
        AddBusinessDays(current, -days);

    /// <summary>
    /// Determine if a <see cref="DateTimeOffset"/> is in the future.
    /// </summary>
    /// <param name="dateTime">The date to be checked.</param>
    /// <returns><c>true</c> if <paramref name="dateTime"/> is in the future; otherwise <c>false</c>.</returns>
    public static bool IsInFuture(this DateTimeOffset dateTime) =>
        dateTime > DateTimeOffset.Now;

    /// <summary>
    /// Determine if a <see cref="DateTimeOffset"/> is in the past.
    /// </summary>
    /// <param name="dateTime">The date to be checked.</param>
    /// <returns><c>true</c> if <paramref name="dateTime"/> is in the past; otherwise <c>false</c>.</returns>
    public static bool IsInPast(this DateTimeOffset dateTime) =>
        dateTime < DateTimeOffset.Now;

    /// <summary>
    /// Rounds <paramref name="dateTime"/> to the nearest <see cref="RoundTo"/>.
    /// </summary>
    /// <returns>The rounded <see cref="DateTimeOffset"/>.</returns>
    public static DateTimeOffset Round(this DateTimeOffset dateTime, RoundTo rt)
    {
        DateTimeOffset rounded;

        switch (rt)
        {
            case RoundTo.Second:
            {
                rounded = new(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Offset);
                if (dateTime.Millisecond >= 500)
                {
                    rounded = rounded.AddSeconds(1);
                }

                break;
            }
            case RoundTo.Minute:
            {
                rounded = new(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0, dateTime.Offset);
                if (dateTime.Second >= 30)
                {
                    rounded = rounded.AddMinutes(1);
                }

                break;
            }
            case RoundTo.Hour:
            {
                rounded = new(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 0, 0, dateTime.Offset);
                if (dateTime.Minute >= 30)
                {
                    rounded = rounded.AddHours(1);
                }

                break;
            }
            case RoundTo.Day:
            {
                rounded = new(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, dateTime.Offset);
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
    /// Returns a DateTimeOffset adjusted to the beginning of the week.
    /// </summary>
    /// <param name="dateTime">The DateTimeOffset to adjust</param>
    /// <returns>A DateTimeOffset instance adjusted to the beginning of the current week</returns>
    /// <remarks>the beginning of the week is controlled by the current Culture</remarks>
    public static DateTimeOffset FirstDayOfWeek(this DateTimeOffset dateTime)
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
    /// <param name="dateTime"></param>
    /// <returns></returns>
    [Obsolete("This method has been renamed to FirstDayOfWeek to be more consistent with existing conventions.")]
    public static DateTimeOffset StartOfWeek(this DateTimeOffset dateTime) =>
        FirstDayOfWeek(dateTime);

    /// <summary>
    /// Returns the first day of the year keeping the time component intact. Eg, 2011-02-04T06:40:20.005 => 2011-01-01T06:40:20.005
    /// </summary>
    /// <param name="current">The DateTimeOffset to adjust</param>
    /// <returns></returns>
    public static DateTimeOffset FirstDayOfYear(this DateTimeOffset current) =>
        current.SetDate(current.Year, 1, 1);

    /// <summary>
    /// Returns the last day of the week keeping the time component intact. Eg, 2011-12-24T06:40:20.005 => 2011-12-25T06:40:20.005
    /// </summary>
    /// <param name="current">The DateTimeOffset to adjust</param>
    /// <returns></returns>
    public static DateTimeOffset LastDayOfWeek(this DateTimeOffset current) =>
        current.FirstDayOfWeek().AddDays(6);

    /// <summary>
    /// Returns the last day of the year keeping the time component intact. Eg, 2011-12-24T06:40:20.005 => 2011-12-31T06:40:20.005
    /// </summary>
    /// <param name="current">The DateTimeOffset to adjust</param>
    /// <returns></returns>
    public static DateTimeOffset LastDayOfYear(this DateTimeOffset current) =>
        current.SetDate(current.Year, 12, 31);

    /// <summary>
    /// Returns the previous month keeping the time component intact. Eg, 2010-01-20T06:40:20.005 => 2009-12-20T06:40:20.005
    /// If the previous month doesn't have that many days the last day of the previous month is used. Eg, 2009-03-31T06:40:20.005 => 2009-02-28T06:40:20.005
    /// </summary>
    /// <param name="current">The DateTimeOffset to adjust</param>
    /// <returns></returns>
    public static DateTimeOffset PreviousMonth(this DateTimeOffset current)
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
    /// <param name="current">The DateTimeOffset to adjust</param>
    /// <returns></returns>
    public static DateTimeOffset NextMonth(this DateTimeOffset current)
    {

        var year = current.Month == 12 ? current.Year + 1 : current.Year;

        var month = current.Month == 12 ? 1 : current.Month + 1;

        var firstDayOfNextMonth = current.SetDate(year, month, 1);

        var lastDayOfPreviousMonth = firstDayOfNextMonth.LastDayOfMonth().Day;

        var day = current.Day > lastDayOfPreviousMonth ? lastDayOfPreviousMonth : current.Day;

        return firstDayOfNextMonth.SetDay(day);
    }

    /// <summary>
    /// Determines whether the specified <see cref="DateTimeOffset"/> value is exactly the same day (day + month + year) then current
    /// </summary>
    /// <param name="current">The current value</param>
    /// <param name="date">Value to compare with</param>
    /// <returns>
    /// 	<c>true</c> if the specified date is exactly the same year then current; otherwise, <c>false</c>.
    /// </returns>
    public static bool SameDay(this DateTimeOffset current, DateTimeOffset date) =>
        current.Date == date.Date;

    /// <summary>
    /// Determines whether the specified <see cref="DateTimeOffset"/> value is exactly the same month (month + year) then current. Eg, 2015-12-01 and 2014-12-01 => False
    /// </summary>
    /// <param name="current">The current value</param>
    /// <param name="date">Value to compare with</param>
    /// <returns>
    /// 	<c>true</c> if the specified date is exactly the same month and year then current; otherwise, <c>false</c>.
    /// </returns>
    public static bool SameMonth(this DateTimeOffset current, DateTimeOffset date) =>
        current.Month == date.Month && current.Year == date.Year;

    /// <summary>
    /// Determines whether the specified <see cref="DateTimeOffset"/> value is exactly the same year then current. Eg, 2015-12-01 and 2015-01-01 => True
    /// </summary>
    /// <param name="current">The current value</param>
    /// <param name="date">Value to compare with</param>
    /// <returns>
    /// 	<c>true</c> if the specified date is exactly the same date then current; otherwise, <c>false</c>.
    /// </returns>
    public static bool SameYear(this DateTimeOffset current, DateTimeOffset date) =>
        current.Year == date.Year;
}