namespace FluentDate;

[StructLayout(LayoutKind.Sequential)]
public readonly struct FluentDate
{
    /// <summary>
    /// Initializes a new instance with the specified date.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="month">
    /// The month (1 through 12).
    /// </param>
    /// <param name="day">
    /// The day (1 through the number of days in <paramref name="month" />).
    /// </param>
    public FluentDate(int year, int month, int day) =>
        Date = new(year, month, day, 0, 0, 0, DateTimeKind.Unspecified);

#if NET6_0_OR_GREATER
    /// <summary>
    /// Gets the current date.
    /// </summary>
    public Date DateOnly => new(Date.Year, Date.Month, Date.Day);
#endif

    /// <summary>
    /// Gets midnight of the current date, with an unspecified time zone.
    /// </summary>
    public DateTime Date { get; }

    /// <summary>
    /// Gets midnight of the current date in the Coordinated Universal Time (UTC) time zone.
    /// </summary>
    public DateTime Utc => AtUtc(0);

    /// <summary>
    /// Gets midnight of the current date in the local time zone.
    /// </summary>
    public DateTime Local => AtLocal(0);

    /// <summary>
    /// Returns specified time at the current date, with an unspecified time zone.
    /// </summary>
    /// <param name="hour">
    /// The hours (0 through 23).
    /// </param>
    /// <param name="minute">
    /// The minutes (0 through 59).
    /// </param>
    /// <param name="second">
    /// The seconds (0 through 59).
    /// </param>
    /// <param name="millisecond">
    /// The milliseconds (0 through 999).
    /// </param>
    [Pure]
    public DateTime At(int hour, int minute = 0, int second = 0, int millisecond = 0) =>
        At(DateTimeKind.Unspecified, hour, minute, second, millisecond);

    /// <summary>
    /// Returns specified time at the current date in the Coordinated Universal Time (UTC) time zone.
    /// </summary>
    [Pure]
    public DateTime AtUtc(int hour, int minute = 0, int second = 0, int millisecond = 0) =>
        At(DateTimeKind.Utc, hour, minute, second, millisecond);

    /// <summary>
    /// Returns specified time at the current date in the local time zone.
    /// </summary>
    /// <param name="hour">
    /// The hours (0 through 23).
    /// </param>
    /// <param name="minute">
    /// The minutes (0 through 59).
    /// </param>
    /// <param name="second">
    /// The seconds (0 through 59).
    /// </param>
    /// <param name="millisecond">
    /// The milliseconds (0 through 999).
    /// </param>
    [Pure]
    public DateTime AtLocal(int hour, int minute = 0, int second = 0, int millisecond = 0) =>
        At(DateTimeKind.Local, hour, minute, second, millisecond);

    /// <summary>
    /// Returns specified time at the current date.
    /// </summary>
    /// <param name="kind">
    /// One of the enumeration values that indicates whether <paramref name="hour" />, <paramref name="minute" />, <paramref name="second" />, and <paramref name="millisecond" /> specify a local time, Coordinated Universal Time (UTC), or neither.
    /// </param>
    /// <param name="hour">
    /// The hours (0 through 23).
    /// </param>
    /// <param name="minute">
    /// The minutes (0 through 59).
    /// </param>
    /// <param name="second">
    /// The seconds (0 through 59).
    /// </param>
    /// <param name="millisecond">
    /// The milliseconds (0 through 999).
    /// </param>
    [Pure]
    public DateTime At(DateTimeKind kind, int hour, int minute = 0, int second = 0, int millisecond = 0) =>
        new(Date.Year, Date.Month, Date.Day, hour, minute, second, millisecond, kind);

    /// <summary>
    /// Returns specified time at the current date and in a time zone expressed through <paramref name="offset" />.
    /// </summary>
    /// <param name="offset">
    /// The time's offset from Coordinated Universal Time (UTC).
    /// </param>
    /// <param name="hour">
    /// The hours (0 through 23).
    /// </param>
    /// <param name="minute">
    /// The minutes (0 through 59).
    /// </param>
    /// <param name="second">
    /// The seconds (0 through 59).
    /// </param>
    /// <param name="millisecond">
    /// The milliseconds (0 through 999).
    /// </param>
    [Pure]
    public DateTimeOffset At(TimeSpan offset, int hour, int minute = 0, int second = 0, int millisecond = 0) =>
        new(Date.Year, Date.Month, Date.Day, hour, minute, second, millisecond, offset);

#if NET6_0_OR_GREATER
    public static implicit operator Date(FluentDate date) => date.DateOnly;
#endif

    public static implicit operator DateTime(FluentDate date) => date.Date;
    public static implicit operator DateTimeOffset(FluentDate date) => (DateTime) date;
}