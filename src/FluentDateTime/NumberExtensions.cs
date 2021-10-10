namespace FluentDate;

/// <summary>
/// Static class containing Fluent <see cref="DateTime"/> extension methods.
/// </summary>
public static class NumberExtensions
{
    /// <summary>
    /// Generates <see cref="TimeSpan"/> value for given number of Years.
    /// </summary>
    public static FluentTimeSpan Years(this int years)
    {
        return new() {Years = years};
    }

    /// <summary>
    /// Generates <see cref="TimeSpan"/> value for given number of Quarters.
    /// </summary>
    /// <param name="quarters"></param>
    /// <returns></returns>
    public static FluentTimeSpan Quarters(this int quarters)
    {
        return new() {Months = quarters * 3};
    }

    /// <summary>
    /// Returns <see cref="TimeSpan"/> value for given number of Months.
    /// </summary>
    public static FluentTimeSpan Months(this int months)
    {
        return new() {Months = months};
    }

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Weeks (number of weeks * 7).
    /// </summary>
    public static FluentTimeSpan Weeks(this int weeks)
    {
        return new() {TimeSpan = TimeSpan.FromDays(weeks * 7)};
    }

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Weeks (number of weeks * 7).
    /// </summary>
    public static FluentTimeSpan Weeks(this double weeks)
    {
        return new() {TimeSpan = TimeSpan.FromDays(weeks * 7)};
    }

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Days.
    /// </summary>
    public static FluentTimeSpan Days(this int days)
    {
        return new() {TimeSpan = TimeSpan.FromDays(days)};
    }

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Days.
    /// </summary>
    public static FluentTimeSpan Days(this double days)
    {
        return new() {TimeSpan = TimeSpan.FromDays(days)};
    }

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Hours.
    /// </summary>
    public static FluentTimeSpan Hours(this int hours)
    {
        return new() {TimeSpan = TimeSpan.FromHours(hours)};
    }

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Hours.
    /// </summary>
    public static FluentTimeSpan Hours(this double hours)
    {
        return new() {TimeSpan = TimeSpan.FromHours(hours)};
    }

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Minutes.
    /// </summary>
    public static FluentTimeSpan Minutes(this int minutes)
    {
        return new() {TimeSpan = TimeSpan.FromMinutes(minutes)};
    }

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Minutes.
    /// </summary>
    public static FluentTimeSpan Minutes(this double minutes)
    {
        return new() {TimeSpan = TimeSpan.FromMinutes(minutes)};
    }

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Seconds.
    /// </summary>
    public static FluentTimeSpan Seconds(this int seconds)
    {
        return new() {TimeSpan = TimeSpan.FromSeconds(seconds)};
    }

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Seconds.
    /// </summary>
    public static FluentTimeSpan Seconds(this double seconds)
    {
        return new() {TimeSpan = TimeSpan.FromSeconds(seconds)};
    }

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Milliseconds.
    /// </summary>
    public static FluentTimeSpan Milliseconds(this int milliseconds)
    {
        return new() {TimeSpan = TimeSpan.FromMilliseconds(milliseconds)};
    }

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Milliseconds.
    /// </summary>
    public static FluentTimeSpan Milliseconds(this double milliseconds)
    {
        return new() {TimeSpan = TimeSpan.FromMilliseconds(milliseconds)};
    }

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of ticks.
    /// </summary>
    public static FluentTimeSpan Ticks(this int ticks)
    {
        return new() {TimeSpan = TimeSpan.FromTicks(ticks)};
    }

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of ticks.
    /// </summary>
    public static FluentTimeSpan Ticks(this long ticks)
    {
        return new() {TimeSpan = TimeSpan.FromTicks(ticks)};
    }
}