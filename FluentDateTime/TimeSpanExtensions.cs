using System;

namespace FluentDate
{
    /// <summary>
    /// Static class containing Fluent <see cref="TimeSpan"/> extension methods.
    /// </summary>
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Adds the given <see cref="FluentTimeSpan"/> from a <see cref="TimeSpan"/> and returns resulting <see cref="FluentTimeSpan"/>.
        /// </summary>
        public static FluentTimeSpan AddFluentTimeSpan(this TimeSpan timeSpan, FluentTimeSpan fluentTimeSpan)
        {
            return fluentTimeSpan.Add(timeSpan);
        }

        /// <summary>
        /// Subtracts the given <see cref="FluentTimeSpan"/> from a <see cref="TimeSpan"/> and returns resulting <see cref="FluentTimeSpan"/>.
        /// </summary>
        public static FluentTimeSpan SubtractFluentTimeSpan(this TimeSpan timeSpan, FluentTimeSpan fluentTimeSpan)
        {
            return FluentTimeSpan.SubtractInternal(timeSpan, fluentTimeSpan);
        }
    }
}