namespace FluentDate;

/// <summary>
/// Static class containing Fluent <see cref="TimeSpan"/> extension methods.
/// </summary>
public static class TimeSpanExtensions
{
    /// <summary>
    /// Adds the given <see cref="FluentTimeSpan"/> from a <see cref="TimeSpan"/> and returns resulting <see cref="FluentTimeSpan"/>.
    /// </summary>
    public static FluentTimeSpan AddFluentTimeSpan(this TimeSpan timeSpan, FluentTimeSpan fluentTimeSpan) =>
        fluentTimeSpan.Add(timeSpan);

    /// <summary>
    /// Subtracts the given <see cref="FluentTimeSpan"/> from a <see cref="TimeSpan"/> and returns resulting <see cref="FluentTimeSpan"/>.
    /// </summary>
    public static FluentTimeSpan SubtractFluentTimeSpan(this TimeSpan timeSpan, FluentTimeSpan fluentTimeSpan) =>
        FluentTimeSpan.SubtractInternal(timeSpan, fluentTimeSpan);

    /// <summary>
    /// Convert a <see cref="TimeSpan"/> to a human readable string.
    /// </summary>
    /// <param name="timeSpan">The <see cref="TimeSpan"/> to convert</param>
    /// <returns>A human readable string for <paramref name="timeSpan"/></returns>
    public static string ToDisplayString(this FluentTimeSpan timeSpan) =>
        ((TimeSpan) timeSpan).ToDisplayString();

    /// <summary>
    /// Convert a <see cref="TimeSpan"/> to a human readable string.
    /// </summary>
    /// <param name="timeSpan">The <see cref="TimeSpan"/> to convert</param>
    /// <returns>A human readable string for <paramref name="timeSpan"/></returns>
    public static string ToDisplayString(this TimeSpan timeSpan)
    {
        if (timeSpan.TotalDays > 1)
        {
            var round = timeSpan.Round(RoundTo.Hour);
            return $"{round.Days} days and {round.Hours} hours";
        }

        if (timeSpan.TotalHours > 1)
        {
            var round = timeSpan.Round(RoundTo.Minute);
            return $"{round.Hours} hours and {round.Minutes} minutes";
        }

        if (timeSpan.TotalMinutes > 1)
        {
            var round = timeSpan.Round(RoundTo.Second);
            return $"{round.Minutes} minutes and {round.Seconds} seconds";
        }

        if (timeSpan.TotalSeconds > 1)
        {
            return $"{timeSpan.TotalSeconds} seconds";
        }

        return $"{timeSpan.Milliseconds} milliseconds";
    }

    /// <summary>
    /// Rounds <paramref name="timeSpan"/> to the nearest <see cref="RoundTo"/>.
    /// </summary>
    /// <returns>The rounded <see cref="TimeSpan"/>.</returns>
    public static TimeSpan Round(this TimeSpan timeSpan, RoundTo rt)
    {
        TimeSpan rounded;

        switch (rt)
        {
            case RoundTo.Second:
            {
                rounded = new(timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
                if (timeSpan.Milliseconds >= 500)
                {
                    rounded = rounded + 1.Seconds();
                }

                break;
            }
            case RoundTo.Minute:
            {
                rounded = new(timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, 0);
                if (timeSpan.Seconds >= 30)
                {
                    rounded = rounded + 1.Minutes();
                }

                break;
            }
            case RoundTo.Hour:
            {
                rounded = new(timeSpan.Days, timeSpan.Hours, 0, 0);
                if (timeSpan.Minutes >= 30)
                {
                    rounded = rounded + 1.Hours();
                }

                break;
            }
            case RoundTo.Day:
            {
                rounded = new(timeSpan.Days, 0, 0, 0);
                if (timeSpan.Hours >= 12)
                {
                    rounded = rounded + 1.Days();
                }

                break;
            }
            default:
            {
                throw new NotImplementedException();
            }
        }

        return rounded;
    }
}