namespace FluentDate;

/// <summary>
/// Static class containing Fluent <see cref="DateTime"/> extension methods.
/// </summary>
public static class NumberExtensions
{
    /// <summary>
    /// Generates <see cref="TimeSpan"/> value for given number of Years.
    /// </summary>
    [Pure]
    public static FluentTimeSpan Years(this int years) =>
        new() {Years = years};

    /// <summary>
    /// Generates <see cref="TimeSpan"/> value for given number of Quarters.
    /// </summary>
    /// <param name="quarters"></param>
    /// <returns></returns>
    [Pure]
    public static FluentTimeSpan Quarters(this int quarters) =>
        new() {Months = quarters * 3};

    /// <summary>
    /// Returns <see cref="TimeSpan"/> value for given number of Months.
    /// </summary>
    public static FluentTimeSpan Months(this int months) =>
        new() {Months = months};

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Weeks (number of weeks * 7).
    /// </summary>
    [Pure]
    public static FluentTimeSpan Weeks(this int weeks) =>
        new() {TimeSpan = TimeSpan.FromDays(weeks * 7)};

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Weeks (number of weeks * 7).
    /// </summary>
    [Pure]
    public static FluentTimeSpan Weeks(this double weeks) =>
        new() {TimeSpan = TimeSpan.FromDays(weeks * 7)};

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Days.
    /// </summary>
    [Pure]
    public static FluentTimeSpan Days(this int days) =>
        new() {TimeSpan = TimeSpan.FromDays(days)};

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Days.
    /// </summary>
    [Pure]
    public static FluentTimeSpan Days(this double days) =>
        new() {TimeSpan = TimeSpan.FromDays(days)};

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Hours.
    /// </summary>
    [Pure]
    public static FluentTimeSpan Hours(this int hours) =>
        new() {TimeSpan = TimeSpan.FromHours(hours)};

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Hours.
    /// </summary>
    [Pure]
    public static FluentTimeSpan Hours(this double hours) =>
        new() {TimeSpan = TimeSpan.FromHours(hours)};

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Minutes.
    /// </summary>
    [Pure]
    public static FluentTimeSpan Minutes(this int minutes) =>
        new() {TimeSpan = TimeSpan.FromMinutes(minutes)};

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Minutes.
    /// </summary>
    [Pure]
    public static FluentTimeSpan Minutes(this double minutes) =>
        new() {TimeSpan = TimeSpan.FromMinutes(minutes)};

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Seconds.
    /// </summary>
    public static FluentTimeSpan Seconds(this int seconds) =>
        new() {TimeSpan = TimeSpan.FromSeconds(seconds)};

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Seconds.
    /// </summary>
    [Pure]
    public static FluentTimeSpan Seconds(this double seconds) =>
        new() {TimeSpan = TimeSpan.FromSeconds(seconds)};

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Milliseconds.
    /// </summary>
    [Pure]
    public static FluentTimeSpan Milliseconds(this int milliseconds) =>
        new() {TimeSpan = TimeSpan.FromMilliseconds(milliseconds)};

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of Milliseconds.
    /// </summary>
    [Pure]
    public static FluentTimeSpan Milliseconds(this double milliseconds) =>
        new() {TimeSpan = TimeSpan.FromMilliseconds(milliseconds)};

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of ticks.
    /// </summary>
    [Pure]
    public static FluentTimeSpan Ticks(this int ticks) =>
        new() {TimeSpan = TimeSpan.FromTicks(ticks)};

    /// <summary>
    /// Returns <see cref="TimeSpan"/> for given number of ticks.
    /// </summary>
    [Pure]
    public static FluentTimeSpan Ticks(this long ticks) =>
        new() {TimeSpan = TimeSpan.FromTicks(ticks)};
}