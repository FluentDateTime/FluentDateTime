namespace FluentDate
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct FluentTimeSpan : IEquatable<FluentTimeSpan>, IComparable<TimeSpan>, IComparable<FluentTimeSpan>
	{
		public const int daysPerYear = 365;
		public int Months { get; set; }
		public int Years { get; set; }
		public TimeSpan TimeSpan { get; set; }
    
        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(FluentTimeSpan other)
        {
            return this == other;
        }



        /// <summary>
        /// Adds two fluentTimeSpan according operator +.
        /// </summary>
        /// <param name="number">The number to add to this fluentTimeSpan.</param>
        /// <returns>The result of the addition operation.</returns>
        public FluentTimeSpan Add(FluentTimeSpan number)
        {
            return AddInternal(this, number);
        }


        /// <summary>
        /// Subtracts the number according -.
        /// </summary>
        /// <param name="fluentTimeSpan">The matrix to subtract from this fluentTimeSpan.</param>
        /// <returns>The result of the subtraction.</returns>
        public FluentTimeSpan Subtract(FluentTimeSpan fluentTimeSpan)
        {
            return SubtractInternal(this, fluentTimeSpan);
        }

        
        /// <summary>
        /// Overload of the operator + 
        /// </summary>
        /// <param name="left">The left hand fluentTimeSpan.</param>
        /// <param name="right">The right hand fluentTimeSpan.</param>
        /// <returns>The result of the addition.</returns>
        public static FluentTimeSpan operator +(FluentTimeSpan left, FluentTimeSpan right)
        {
            return AddInternal(left, right);
        }
        public static FluentTimeSpan operator +(FluentTimeSpan left, TimeSpan right)
        {
            return AddInternal(left, right);
        }


        public static FluentTimeSpan operator +(TimeSpan left, FluentTimeSpan right)
        {
            return AddInternal(left, right);
        }


        /// <summary>
        /// Overload of the operator - 
        /// </summary>
        /// <param name="left">The left hand fluentTimeSpan.</param>
        /// <param name="right">The right hand fluentTimeSpan.</param>
        /// <returns>The result of the subtraction.</returns>
        public static FluentTimeSpan operator -(FluentTimeSpan left, FluentTimeSpan right)
        {
            return SubtractInternal(left, right);
        }
        public static FluentTimeSpan operator -(TimeSpan left, FluentTimeSpan right)
        {
            return SubtractInternal(left, right);
        }
        public static FluentTimeSpan operator -(FluentTimeSpan left, TimeSpan right)
        {
            return SubtractInternal(left, right);
        }
        

        /// <summary>
        /// Equals operator.
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns><c>true</c> is <paramref name="left"/> is equal to <paramref name="right"/>; otherwise <c>false</c>.</returns>
        public static bool operator ==(FluentTimeSpan left, FluentTimeSpan right)
        {
            return (left.Years == right.Years) && (left.Months == right.Months) && (left.TimeSpan == right.TimeSpan);
        }
        public static bool operator ==(TimeSpan left, FluentTimeSpan right)
        {
            return (FluentTimeSpan)left == right;
        }
        public static bool operator ==(FluentTimeSpan left, TimeSpan right)
        {
            return left == (FluentTimeSpan)right;
        }



        /// <summary>
        /// Not Equals operator.
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns><c>true</c> is <paramref name="left"/> is not equal to <paramref name="right"/>; otherwise <c>false</c>.</returns>
        public static bool operator !=(FluentTimeSpan left, FluentTimeSpan right)
        {
            return !(left == right);
        }
        public static bool operator !=(TimeSpan left, FluentTimeSpan right)
        {
            return !(left == right);
        }
        public static bool operator !=(FluentTimeSpan left, TimeSpan right)
        {
            return !(left == right);
        }


        public static FluentTimeSpan operator -(FluentTimeSpan value)
        {
            return value.Negate();
        }
        public static bool operator <(FluentTimeSpan left, FluentTimeSpan right)
        {
            return ((TimeSpan)left < (TimeSpan)right);
        }
        public static bool operator <(FluentTimeSpan left, TimeSpan right)
        {
            return ((TimeSpan)left < right);
        }
        public static bool operator <(TimeSpan left, FluentTimeSpan right)
        {
            return (left < (TimeSpan)right);
        }

        public static bool operator <=(FluentTimeSpan left, FluentTimeSpan right)
        {
            return ((TimeSpan)left <= (TimeSpan)right);
        }
        public static bool operator <=(FluentTimeSpan left, TimeSpan right)
        {
            return ((TimeSpan)left <= right);
        }

        public static bool operator <=(TimeSpan left, FluentTimeSpan right)
        {
            return (left <= (TimeSpan)right);
        }

        public static bool operator >(FluentTimeSpan left, FluentTimeSpan right)
        {
            return ((TimeSpan)left > (TimeSpan)right);
        }
        public static bool operator >(FluentTimeSpan left, TimeSpan right)
        {
            return ((TimeSpan)left > right);
        }
        public static bool operator >(TimeSpan left, FluentTimeSpan right)
        {
            return (left > (TimeSpan)right);
        }

        public static bool operator >=(FluentTimeSpan left, FluentTimeSpan right)
        {
            return ((TimeSpan)left >= (TimeSpan)right);
        }
        public static bool operator >=(FluentTimeSpan left, TimeSpan right)
        {
            return ((TimeSpan)left >= right);
        }
        public static bool operator >=(TimeSpan left, FluentTimeSpan right)
        {
            return (left >= (TimeSpan)right);
        }


        /// <summary>
        /// Performs an explicit conversion from <see cref="FluentTimeSpan"/> to <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="fluentTimeSpan">The FluentTimeSpan.</param>
        /// <returns>The result of the conversion.</returns>
		public static implicit operator TimeSpan(FluentTimeSpan fluentTimeSpan)
        {
        	var daysFromYears = daysPerYear*fluentTimeSpan.Years;
        	var daysFromMonths = 30*fluentTimeSpan.Months;
        	var days = daysFromMonths + daysFromYears;
        	return new TimeSpan(days, 0, 0, 0) + fluentTimeSpan.TimeSpan;
        }

    	/// <summary>
        /// Performs an implicit conversion from a <see cref="TimeSpan"/> to <see cref="FluentTimeSpan"/>.
        /// </summary>
        /// <param name="timeSpan">The <see cref="TimeSpan"/> that will be converted.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator FluentTimeSpan(TimeSpan timeSpan)
        {
            return new FluentTimeSpan { TimeSpan = timeSpan };
        }
  



        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            return new FluentTimeSpan
                   {
                       TimeSpan = TimeSpan,
                       Months = Months,
                       Years = Years
                   };
        }
        

        /// <inheritdoc />
        public override string ToString()
        {
            return ((TimeSpan)this).ToString();
        }


        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            var type = obj.GetType();
            if (type == typeof(FluentTimeSpan))
            {
                return this == (FluentTimeSpan)obj;
            }
            if (type == typeof(TimeSpan))
            {
                return this == (TimeSpan)obj;
            }
            return false;
        }


        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Months.GetHashCode() ^ Years.GetHashCode() ^ TimeSpan.GetHashCode();
        }


        static FluentTimeSpan AddInternal(FluentTimeSpan left, FluentTimeSpan right)
        {
            return new FluentTimeSpan
            {
                Years = left.Years + right.Years,
                Months = left.Months + right.Months,
                TimeSpan = left.TimeSpan + right.TimeSpan
            };
        }

        static FluentTimeSpan SubtractInternal(FluentTimeSpan left, FluentTimeSpan right)
        {

            return new FluentTimeSpan
            {
                Years = left.Years - right.Years,
                Months = left.Months - right.Months,
                TimeSpan = left.TimeSpan - right.TimeSpan
            };
        }

        /// <summary>
        /// Gets the number of ticks that represent the value of the current <see cref="TimeSpan"/> structure.
        /// </summary>
        public long Ticks => ((TimeSpan)this).Ticks;

        public int Days => ((TimeSpan)this).Days;

        public int Hours => ((TimeSpan)this).Hours;

        public int Milliseconds => ((TimeSpan)this).Milliseconds;

        public int Minutes => ((TimeSpan)this).Minutes;

        public int Seconds => ((TimeSpan)this).Seconds;

        public double TotalDays => ((TimeSpan)this).TotalDays;
        public double TotalHours => ((TimeSpan)this).TotalHours;
        public double TotalMilliseconds => ((TimeSpan)this).TotalMilliseconds;
        public double TotalMinutes => ((TimeSpan)this).TotalMinutes;
        public double TotalSeconds => ((TimeSpan)this).TotalSeconds;

        public int CompareTo(TimeSpan other)
        {
            return ((TimeSpan)this).CompareTo(other);
        }
        public int CompareTo(object value)
        {
            if (value is TimeSpan)
            {
                return ((TimeSpan)this).CompareTo((TimeSpan) value);
            }
            throw new ArgumentException("Value must be a TimeSpan", "value");
        }
        public int CompareTo(FluentTimeSpan value)
        {
            return ((TimeSpan)this).CompareTo(value);
        }
        public TimeSpan Negate()
        {
            return new FluentTimeSpan
            {
                TimeSpan = -TimeSpan,
                Months = -Months,
                Years = -Years
            };
        }


    }
}