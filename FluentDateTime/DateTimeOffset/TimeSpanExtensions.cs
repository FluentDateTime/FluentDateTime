namespace FluentDateTimeOffset
{

    using System;
    using FluentDate;


	/// <summary>
	/// Static class containing Fluent <see cref="TimeSpan"/> extension methods.
	/// </summary>
	public static class TimeSpanOffsetExtensions
	{

		/// <summary>
		/// Subtracts given <see cref="TimeSpan"/> from current date (<see cref="DateTime.Now"/>) and returns resulting <see cref="DateTime"/> in the past.
		/// </summary>
        public static DateTimeOffset Ago(this TimeSpan from)
		{
            return from.Before(DateTimeOffset.Now);
		}

		/// <summary>
        /// Subtracts given <see cref="FluentTimeSpan"/> from current date (<see cref="DateTimeOffset.Now"/>) and returns resulting <see cref="DateTime"/> in the past.
		/// </summary>
        public static DateTimeOffset Ago(this FluentTimeSpan from)
		{
            return from.Before(DateTimeOffset.Now);
		}


		/// <summary>
		/// Subtracts given <see cref="TimeSpan"/> from <paramref name="originalValue"/> <see cref="DateTime"/> and returns resulting <see cref="DateTime"/> in the past.
		/// </summary>
		public static DateTimeOffset Ago(this TimeSpan from, DateTimeOffset originalValue)
		{
			return from.Before(originalValue);
		}

		/// <summary>
		/// Subtracts given <see cref="TimeSpan"/> from <paramref name="originalValue"/> <see cref="DateTime"/> and returns resulting <see cref="DateTime"/> in the past.
		/// </summary>
		public static DateTimeOffset Ago(this FluentTimeSpan from, DateTimeOffset originalValue)
		{
			return from.Before(originalValue);
		}

		/// <summary>
		/// Subtracts given <see cref="TimeSpan"/> from <paramref name="originalValue"/> <see cref="DateTime"/> and returns resulting <see cref="DateTime"/> in the past.
		/// </summary>
		public static DateTimeOffset Before(this TimeSpan from, DateTimeOffset originalValue)
		{
			return originalValue - from;
		}

		/// <summary>
		/// Subtracts given <see cref="TimeSpan"/> from <paramref name="originalValue"/> <see cref="DateTime"/> and returns resulting <see cref="DateTime"/> in the past.
		/// </summary>
		public static DateTimeOffset Before(this FluentTimeSpan from, DateTimeOffset originalValue)
		{
			return originalValue.AddMonths(-from.Months).AddYears(-from.Years).Add(-from.TimeSpan);
		}


		/// <summary>
		/// Adds given <see cref="TimeSpan"/> to current <see cref="DateTime.Now"/> and returns resulting <see cref="DateTime"/> in the future.
		/// </summary>
		public static DateTimeOffset FromNow(this TimeSpan from)
		{
            return from.From(DateTimeOffset.Now);
		}

		/// <summary>
		/// Adds given <see cref="TimeSpan"/> to current <see cref="DateTime.Now"/> and returns resulting <see cref="DateTime"/> in the future.
		/// </summary>
		public static DateTimeOffset FromNow(this FluentTimeSpan from)
		{
            return from.From(DateTimeOffset.Now);
		}

		/// <summary>
		/// Adds given <see cref="TimeSpan"/> to supplied <paramref name="originalValue"/> <see cref="DateTime"/> and returns resulting <see cref="DateTime"/> in the future.
		/// </summary>
		public static DateTimeOffset From(this TimeSpan from, DateTimeOffset originalValue)
		{
			return originalValue + from;
		}

		/// <summary>
		/// Adds given <see cref="TimeSpan"/> to supplied <paramref name="originalValue"/> <see cref="DateTime"/> and returns resulting <see cref="DateTime"/> in the future.
		/// </summary>
		public static DateTimeOffset From(this FluentTimeSpan from, DateTimeOffset originalValue)
		{
			return originalValue.AddMonths(from.Months).AddYears(from.Years).Add(from.TimeSpan);
		}

		/// <summary>
		/// Adds given <see cref="TimeSpan"/> to supplied <paramref name="originalValue"/> <see cref="DateTime"/> and returns resulting <see cref="DateTime"/> in the future.
		/// </summary>
		/// <seealso cref="From(System.TimeSpan,System.DateTimeOffset)"/>
		/// <remarks>
		/// Synonym of <see cref="From(System.TimeSpan,System.DateTimeOffset)"/> method.
		/// </remarks>
		public static DateTimeOffset Since(this TimeSpan from, DateTimeOffset originalValue)
		{
			return From(from, originalValue);
		}

		/// <summary>
		/// Adds given <see cref="TimeSpan"/> to supplied <paramref name="originalValue"/> <see cref="DateTime"/> and returns resulting <see cref="DateTime"/> in the future.
		/// </summary>
		/// <seealso cref="From(System.TimeSpan,System.DateTimeOffset)"/>
		/// <remarks>
		/// Synonym of <see cref="From(System.TimeSpan,System.DateTimeOffset)"/> method.
		/// </remarks>
		public static DateTimeOffset Since(this FluentTimeSpan from, DateTimeOffset originalValue)
		{
			return From(from, originalValue);
		}


		/// <summary>
		/// Convert a <see cref="TimeSpan"/> to a human readable string.
		/// </summary>
		/// <param name="timeSpan">The <see cref="TimeSpan"/> to convert</param>
		/// <returns>A human readable string for <paramref name="timeSpan"/></returns>
		public static string ToDisplayString(this FluentTimeSpan timeSpan)
		{
			return ((TimeSpan)timeSpan).ToDisplayString();
		}

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

      
		public static TimeSpan Round(this TimeSpan timeSpan, RoundTo rt)
		{
			TimeSpan rounded;

			switch (rt)
			{
				case RoundTo.Second:
					{
						rounded = new TimeSpan(timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
						if (timeSpan.Milliseconds >= 500)
						{
							rounded = rounded + 1.Seconds();
						}
						break;
					}
				case RoundTo.Minute:
					{
						rounded = new TimeSpan(timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, 0);
						if (timeSpan.Seconds >= 30)
						{
							rounded = rounded + 1.Minutes();
						}
						break;
					}
				case RoundTo.Hour:
					{
						rounded = new TimeSpan(timeSpan.Days, timeSpan.Hours, 0, 0);
						if (timeSpan.Minutes >= 30)
						{
							rounded = rounded + 1.Hours();
						}
						break;
					}
				case RoundTo.Day:
					{
						rounded = new TimeSpan(timeSpan.Days, 0, 0, 0);
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

    


		//TODO: equality tests: DateIsEqual() TimeIsEqual() 
	}
}