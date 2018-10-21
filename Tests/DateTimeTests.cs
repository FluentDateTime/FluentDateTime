using System;
using System.Globalization;
using FluentDate;
using FluentDateTime;
using System.Threading;
using Xunit;

public class DateTimeTests
{
    const int DaysPerWeek = 7;

    [Theory]
    [InlineData(1)]
    [InlineData(32)]
    [InlineData(40)]
    [InlineData(100)]
    [InlineData(1000)]
    [InlineData(-1)]
    [InlineData(-100)]
    [InlineData(0)]
    public void Ago_FromFixedDateTime_Tests(int agoValue)
    {
        var originalPointInTime = new DateTime(1976, 12, 31, 17, 0, 0, 0, DateTimeKind.Local);

        DateAssert.Equal(agoValue.Years().Before(originalPointInTime), originalPointInTime.AddYears(-agoValue));
        DateAssert.Equal(agoValue.Months().Before(originalPointInTime), originalPointInTime.AddMonths(-agoValue));
        DateAssert.Equal(agoValue.Weeks().Before(originalPointInTime), originalPointInTime.AddDays(-agoValue * DaysPerWeek));
        DateAssert.Equal(agoValue.Days().Before(originalPointInTime), originalPointInTime.AddDays(-agoValue));

        DateAssert.Equal(agoValue.Hours().Before(originalPointInTime), originalPointInTime.AddHours(-agoValue));
        DateAssert.Equal(agoValue.Minutes().Before(originalPointInTime), originalPointInTime.AddMinutes(-agoValue));
        DateAssert.Equal(agoValue.Seconds().Before(originalPointInTime), originalPointInTime.AddSeconds(-agoValue));
        DateAssert.Equal(agoValue.Milliseconds().Before(originalPointInTime), originalPointInTime.AddMilliseconds(-agoValue));
        DateAssert.Equal(agoValue.Ticks().Before(originalPointInTime), originalPointInTime.AddTicks(-agoValue));
    }

    [Fact]
    public void Ago_FromOneMonth()
    {
        var originalPointInTime = new DateTime(1976, 4, 30, 0, 0, 0, DateTimeKind.Local);

        DateAssert.Equal(1.Months().Before(originalPointInTime), new DateTime(1976, 3, 30, 0, 0, 0, DateTimeKind.Local));
        DateAssert.Equal(1.Months().From(originalPointInTime), new DateTime(1976, 5, 30, 0, 0, 0, DateTimeKind.Local));
    }

    [Fact]
    public void AddFluentTimeSpan()
    {
        var originalPointInTime = new DateTime(1976, 1, 1, 0, 0, 0, DateTimeKind.Local);
        FluentTimeSpan fluentTimeSpan = 1.Months();
        Assert.Equal(new DateTime(1976, 2, 1, 0, 0, 0, DateTimeKind.Local), originalPointInTime.AddFluentTimeSpan(fluentTimeSpan));
    }

    [Fact]
    public void SubtractFluentTimeSpan()
    {
        var originalPointInTime = new DateTime(1976, 2, 1, 0, 0, 0, DateTimeKind.Local);
        FluentTimeSpan fluentTimeSpan = 1.Months();
        Assert.Equal(new DateTime(1976, 1, 1, 0, 0, 0, DateTimeKind.Local), originalPointInTime.SubtractFluentTimeSpan(fluentTimeSpan));
    }

    [Fact]
    public void Ago_FromOneYearLeap()
    {
        var originalPointInTime = new DateTime(2004, 2, 29, 0, 0, 0, DateTimeKind.Local);

        DateAssert.Equal(1.Years().Before(originalPointInTime), new DateTime(2003, 2, 28, 0, 0, 0, DateTimeKind.Local));
        DateAssert.Equal(1.Years().From(originalPointInTime), new DateTime(2005, 2, 28, 0, 0, 0, DateTimeKind.Local));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(32)]
    [InlineData(100)]
    [InlineData(1000)]
    [InlineData(-1)]
    [InlineData(-100)]
    [InlineData(0)]
    public void From_FromFixedDateTime_Tests(int value)
    {
        var originalPointInTime = new DateTime(1976, 12, 31, 17, 0, 0, 0, DateTimeKind.Local);

        DateAssert.Equal(value.Years().From(originalPointInTime), originalPointInTime.AddYears(value));
        DateAssert.Equal(value.Months().From(originalPointInTime), originalPointInTime.AddMonths(value));
        DateAssert.Equal(value.Weeks().From(originalPointInTime), originalPointInTime.AddDays(value * DaysPerWeek));
        DateAssert.Equal(value.Days().From(originalPointInTime), originalPointInTime.AddDays(value));

        DateAssert.Equal(value.Hours().From(originalPointInTime), originalPointInTime.AddHours(value));
        DateAssert.Equal(value.Minutes().From(originalPointInTime), originalPointInTime.AddMinutes(value));
        DateAssert.Equal(value.Seconds().From(originalPointInTime), originalPointInTime.AddSeconds(value));
        DateAssert.Equal(value.Milliseconds().From(originalPointInTime), originalPointInTime.AddMilliseconds(value));
        DateAssert.Equal(value.Ticks().From(originalPointInTime), originalPointInTime.AddTicks(value));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(23)]
    public void ChangeTime_Hour_SimpleTests(int value)
    {
        var toChange = new DateTime(2008, 10, 25, 0, 0, 0, 0, DateTimeKind.Local);

        var result = toChange.SetTime(value);
        var expected = new DateTime(2008, 10, 25, value, 0, 0, 0, DateTimeKind.Local);

        DateAssert.Equal(expected, result);
    }

    [Theory]
    [InlineData(24)]
    [InlineData(-1)]
    public void ChangeTime_Hour_SimpleTests_Arg_Checks(int value)
    {
        var toChange = new DateTime(2008, 10, 25, 0, 0, 0, 0, DateTimeKind.Local);

        Assert.Throws<ArgumentOutOfRangeException>(() => { toChange.SetTime(value); });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(16)]
    [InlineData(59)]
    public void ChangeTime_Minute_SimpleTests(int value)
    {
        var toChange = new DateTime(2008, 10, 25, 0, 0, 0, 0, DateTimeKind.Local);

        var expected = new DateTime(2008, 10, 25, 0, value, 0, 0, DateTimeKind.Local);
        DateAssert.Equal(expected, toChange.SetTime(0, value));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(60)]
    public void ChangeTime_Minute_SimpleTests_Arg_Checks(int value)
    {
        var toChange = new DateTime(2008, 10, 25, 0, 0, 0, 0, DateTimeKind.Local);
        Assert.Throws<ArgumentOutOfRangeException>(() => { toChange.SetTime(0, value); });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(16)]
    [InlineData(59)]
    public void ChangeTime_Second_SimpleTests(int value)
    {
        var toChange = new DateTime(2008, 10, 25, 0, 0, 0, 0, DateTimeKind.Local);

        var changed = toChange.SetTime(0, 0, value);

        var expected = new DateTime(2008, 10, 25, 0, 0, value, 0, DateTimeKind.Local);

        DateAssert.Equal(expected, changed);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(60)]
    public void ChangeTime_Second_SimpleTests_Arg_Checks(int value)
    {
        var toChange = new DateTime(2008, 10, 25, 0, 0, 0, 0, DateTimeKind.Local);

        Assert.Throws<ArgumentOutOfRangeException>(() => { toChange.SetTime(0, 0, value); });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(100)]
    [InlineData(999)]
    public void ChangeTime_Millisecond_SimpleTests(int value)
    {
        var toChange = new DateTime(2008, 10, 25, 0, 0, 0, 0, DateTimeKind.Local);

        var expected = new DateTime(2008, 10, 25, 0, 0, 0, value, DateTimeKind.Local);
        DateAssert.Equal(expected, toChange.SetTime(0, 0, 0, value));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(1000)]
    public void ChangeTime_Millisecond_SimpleTests_Arg_Check(int value)
    {
        var toChange = new DateTime(2008, 10, 25, 0, 0, 0, 0, DateTimeKind.Local);
        Assert.Throws<ArgumentOutOfRangeException>(() => { toChange.SetTime(0, 0, 0, value); });
    }

    [Fact]
    public void TimeZoneTests()
    {
        /* story:
         * 1. a web client submits a request to the server for "today",
         * 2. a developer uses :BeginningOfDay and :EndOfDay to perform clamping server-side.
         *
         * expected:
         * 3. user expects a timezone-correct utc responses from the server,
         *
         * actual:
         * 4. user receives a utc response that is too early (:BeginningOfDay), or
         * 5. user receives a utc response that is too late (:EndOfDay)
         */
        for (var i = -11; i <= 12; i++)
        {
            var beginningOfDayUtc = new DateTime(2015, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var actualDayStart = beginningOfDayUtc.BeginningOfDay(i);
            var actualDayEnd = beginningOfDayUtc.EndOfDay(i);
            var expectedDayStart = beginningOfDayUtc
                .AddHours(i);
            var expectedDayEnd = beginningOfDayUtc
                .SetHour(23).SetMinute(59).SetSecond(59).SetMillisecond(999)
                .AddHours(i);
            DateAssert.Equal(expectedDayStart, actualDayStart);
            DateAssert.Equal(expectedDayEnd, actualDayEnd);
        }
    }

    [Fact]
    public void BasicTests()
    {
        var now = DateTime.Now;
        DateAssert.Equal(new DateTime(now.Year, now.Month, now.Day, 23, 59, 59, 999, DateTimeKind.Local), DateTime.Now.EndOfDay(), " End of the day wrong");
        DateAssert.Equal(new DateTime(now.Year, now.Month, now.Day, 0, 0, 0, 0, DateTimeKind.Local), DateTime.Now.BeginningOfDay(), "Start of the day wrong");

        var firstBirthDay = new DateTime(1977, 12, 31, 17, 0, 0, 0, DateTimeKind.Local);
        DateAssert.Equal(firstBirthDay + new TimeSpan(1, 0, 5, 0, 0), firstBirthDay + 1.Days() + 5.Minutes());

        DateAssert.Equal(now + TimeSpan.FromDays(1), now.NextDay());
        DateAssert.Equal(now - TimeSpan.FromDays(1), now.PreviousDay());

        DateAssert.Equal(now + TimeSpan.FromDays(7), now.WeekAfter());
        DateAssert.Equal(now - TimeSpan.FromDays(7), now.WeekEarlier());

        Assert.Equal(new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2008, 12, 31, 0, 0, 0, DateTimeKind.Local).Add(1.Days()));
        Assert.Equal(new DateTime(2009, 1, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Local).Add(1.Days()));

        var sampleDate = new DateTime(2009, 1, 1, 13, 0, 0, 0, DateTimeKind.Local);
        DateAssert.Equal(new DateTime(2009, 1, 1, 12, 0, 0, 0, DateTimeKind.Local), sampleDate.Noon());
        DateAssert.Equal(new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Local), sampleDate.Midnight());

        Assert.Equal(3.Days() + 3.Days(), 6.Days());
        Assert.Equal(102.Days() - 3.Days(), 99.Days());

        Assert.Equal(24.Hours(), 1.Days());

        sampleDate = new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
        DateAssert.Equal(3.Days().Since(sampleDate), sampleDate + 3.Days());

        var saturday = new DateTime(2008, 10, 25, 12, 0, 0, DateTimeKind.Local);
        DateAssert.Equal(new DateTime(2008, 11, 1, 12, 0, 0, DateTimeKind.Local), saturday.Next(DayOfWeek.Saturday));

        DateAssert.Equal(new DateTime(2008, 10, 18, 12, 0, 0, DateTimeKind.Local), saturday.Previous(DayOfWeek.Saturday));

        // ReSharper disable UnusedVariable
        var nextWeek = DateTime.Now + 1.Weeks();

        var tomorrow = DateTime.Now + 1.Days();
        var yesterday = DateTime.Now - 1.Days();
        var changedHourTo14H = DateTime.Now.SetHour(14);
        var todayNoon = DateTime.Now.Noon();
        var tomorrowNoon = DateTime.Now.NextDay().Noon();
        var fiveDaysAgo = 5.Days().Ago();
        var twoDaysFromNow = 2.Days().FromNow();
        var nextYearSameDateAsTodayNoon = 1.Years().FromNow().Noon();

        var twoWeeksFromNow = 2.Weeks().FromNow();

        // ReSharper restore UnusedVariable
    }

    [Fact]
    public void NextYear_ReturnsTheSameDateButNextYear()
    {
        var birthday = new DateTime(1976, 12, 31, 17, 0, 0, 0, DateTimeKind.Local);
        var nextYear = birthday.NextYear();
        var expected = new DateTime(1977, 12, 31, 17, 0, 0, 0, DateTimeKind.Local);
        DateAssert.Equal(expected, nextYear);
    }

    [Fact]
    public void PreviousYear_ReturnsTheSameDateButPreviousYear()
    {
        var birthday = new DateTime(1976, 12, 31, 17, 0, 0, 0, DateTimeKind.Local);
        var previousYear = birthday.PreviousYear();
        var expected = new DateTime(1975, 12, 31, 17, 0, 0, 0, DateTimeKind.Local);
        DateAssert.Equal(expected, previousYear);
    }

    [Fact]
    public void NextYear_IfNextYearDoesNotHaveTheSameDayInTheSameMonthThenCalculateHowManyDaysIsMissingAndAddThatToTheLastDayInTheSameMonthNextYear()
    {
        var someBirthday = new DateTime(2008, 2, 29, 17, 0, 0, 0, DateTimeKind.Local);
        var nextYear = someBirthday.NextYear();
        var expected = new DateTime(2009, 3, 1, 17, 0, 0, 0, DateTimeKind.Local);
        DateAssert.Equal(expected, nextYear);
    }

    [Fact]
    public void PreviousYear_IfPreviousYearDoesNotHaveTheSameDayInTheSameMonthThenCalculateHowManyDaysIsMissingAndAddThatToTheLastDayInTheSameMonthPreviousYear()
    {
        var someBirthday = new DateTime(2012, 2, 29, 17, 0, 0, 0, DateTimeKind.Local);
        var previousYear = someBirthday.PreviousYear();
        var expected = new DateTime(2011, 3, 1, 17, 0, 0, 0, DateTimeKind.Local);
        DateAssert.Equal(expected, previousYear);
    }

    [Fact]
    public void Next_ReturnsNextFridayProperly()
    {
        var friday = new DateTime(2009, 7, 10, 1, 0, 0, 0, DateTimeKind.Local);
        var reallyNextFriday = new DateTime(2009, 7, 17, 1, 0, 0, 0, DateTimeKind.Local);
        var nextFriday = friday.Next(DayOfWeek.Friday);

        DateAssert.Equal(reallyNextFriday, nextFriday);
    }

    [Fact]
    public void Next_ReturnsPreviousFridayProperly()
    {
        var friday = new DateTime(2009, 7, 17, 1, 0, 0, 0, DateTimeKind.Local);
        var reallyPreviousFriday = new DateTime(2009, 7, 10, 1, 0, 0, 0, DateTimeKind.Local);
        var previousFriday = friday.Previous(DayOfWeek.Friday);

        DateAssert.Equal(reallyPreviousFriday, previousFriday);
    }

    [Fact]
    public void IsBefore_ReturnsTrueForGivenDateThatIsInTheFuture()
    {
        // arrange
        var toCompareWith = DateTime.Today + 1.Days();

        // assert
        Assert.True(DateTime.Today.IsBefore(toCompareWith));
    }

    [Fact]
    public void IsBefore_ReturnsFalseForGivenDateThatIsSame()
    {
        // arrange
        var toCompareWith = DateTime.Today;

        // assert
        Assert.False(toCompareWith.IsBefore(toCompareWith));
    }

    [Fact]
    public void IsAfter_ReturnsTrueForGivenDateThatIsInThePast()
    {
        // arrange
        var toCompareWith = DateTime.Today - 1.Days();

        // assert
        Assert.True(DateTime.Today.IsAfter(toCompareWith));
    }

    [Fact]
    public void IsAfter_ReturnsFalseForGivenDateThatIsSame()
    {
        // arrange
        var toCompareWith = DateTime.Today;

        // assert
        Assert.False(toCompareWith.IsAfter(toCompareWith));
    }

    [Fact]
    public void At_SetsHourAndMinutesProperly()
    {
        var expected = new DateTime(2002, 12, 17, 18, 06, 01, DateTimeKind.Local);
        DateAssert.Equal(expected, new DateTime(2002, 12, 17, 17, 05, 01, DateTimeKind.Local).At(18, 06));
    }

    [Fact]
    public void At_SetsHourAndMinutesAndSecondsProperly()
    {
        var expected = new DateTime(2002, 12, 17, 18, 06, 02, DateTimeKind.Local);
        DateAssert.Equal(expected, new DateTime(2002, 12, 17, 17, 05, 01, DateTimeKind.Local).At(18, 06, 02));
    }

    [Fact]
    public void At_SetsHourAndMinutesAndMillisecondsProperly()
    {
        var expected = new DateTime(2002, 12, 17, 18, 06, 02, 03, DateTimeKind.Local);
        DateAssert.Equal(expected, new DateTime(2002, 12, 17, 17, 05, 01, DateTimeKind.Local).At(18, 06, 02, 03));
    }

    [Fact]
    public void FirstDayOfMonth_SetsTheDayToOne()
    {
        var expected = new DateTime(2002, 12, 1, 17, 05, 01, DateTimeKind.Local);
        DateAssert.Equal(expected, new DateTime(2002, 12, 17, 17, 05, 01, DateTimeKind.Local).FirstDayOfMonth());
    }

    [Fact]
    public void PreviousQuarter_FirstDay_SetsTheDayToOne()
    {
        var expected = new DateTime(2001, 10, 1, 3, 5, 6, DateTimeKind.Local);
        DateAssert.Equal(expected.BeginningOfDay(), 1.Quarters().Ago(new DateTime(2002, 1, 10, 4, 5, 6, DateTimeKind.Local).FirstDayOfQuarter().BeginningOfDay()));
    }

    [Fact]
    public void PreviousQuarter_LastDay_SetsTheDayToLastDayOfQuarter()
    {
        var expected = new DateTime(2001, 12, 31, 3, 5, 6, DateTimeKind.Local);
        DateAssert.Equal(expected.BeginningOfDay(), 1.Quarters().Ago(new DateTime(2002, 1, 10, 4, 5, 6, DateTimeKind.Local).LastDayOfQuarter().BeginningOfDay()));
    }

    [Fact]
    public void NextQuarter_FirstDay_SetsTheDayToOne()
    {
        var expected = new DateTime(2002, 4, 1, 3, 5, 6, DateTimeKind.Local);
        DateAssert.Equal(expected.BeginningOfDay(), 1.Quarters().From(new DateTime(2002, 1, 10, 4, 5, 6, DateTimeKind.Local).FirstDayOfQuarter().BeginningOfDay()));
    }

    [Fact]
    public void NextQuarter_LastDay_SetsTheDayToLastDayOfQuarter()
    {
        var expected = new DateTime(2002, 6, 30, 3, 5, 6, DateTimeKind.Local);
        DateAssert.Equal(expected.BeginningOfDay(), 1.Quarters().From(new DateTime(2002, 1, 10, 4, 5, 6, DateTimeKind.Local).LastDayOfQuarter().BeginningOfDay()));
    }

    [Fact]
    public void FirstDayOfQuarter_SetsTheDayToOne()
    {
        var expected = new DateTime(2002, 1, 1, 7, 8, 9, DateTimeKind.Local);
        DateAssert.Equal(expected.BeginningOfDay(), new DateTime(2002, 3, 22, 12, 12, 12, DateTimeKind.Local).FirstDayOfQuarter().BeginningOfDay());
    }

    [Fact]
    public void LastDayOfQuarter_SetsTheDayToLastDayOfQuarter()
    {
        var expected = new DateTime(2002, 3, 31, 4, 5, 6, DateTimeKind.Local);
        DateAssert.Equal(expected.BeginningOfDay(), new DateTime(2002, 3, 22, 12, 12, 12, DateTimeKind.Local).LastDayOfQuarter().BeginningOfDay());
    }

    [Fact]
    public void FirstDayOfQuarter_Q4_SetsDayToFirstDay()
    {
        var expected = new DateTime(2002, 10, 1, 7, 8, 9, DateTimeKind.Local);
        DateAssert.Equal(expected.BeginningOfDay(), new DateTime(2002, 11, 22, 12, 12, 12, DateTimeKind.Local).FirstDayOfQuarter().BeginningOfDay());
    }

    [Fact]
    public void LastDayOfQuarter_Q4_SetsTheDayToLastDayOfQuarter()
    {
        var expected = new DateTime(2002, 12, 31, 4, 5, 6, DateTimeKind.Local);
        DateAssert.Equal(expected.BeginningOfDay(), new DateTime(2002, 11, 22, 12, 12, 12, DateTimeKind.Local).LastDayOfQuarter().BeginningOfDay());
    }

    [Fact]
    public void LastDayOfMonth_SetsTheDayToLastDayInThatMonth()
    {
        var expected = new DateTime(2002, 1, 31, 17, 05, 01, DateTimeKind.Local);
        DateAssert.Equal(expected, new DateTime(2002, 1, 1, 17, 05, 01, DateTimeKind.Local).LastDayOfMonth());
    }

    [Fact]
    public void AddBusinessDays_AdsDaysProperlyWhenThereIsWeekendAhead()
    {
        var expected = new DateTime(2009, 7, 13, 0, 0, 0, DateTimeKind.Local);
        DateAssert.Equal(expected, new DateTime(2009, 7, 9, 0, 0, 0, DateTimeKind.Local).AddBusinessDays(2));
    }

    [Fact]
    public void AddBusinessDays_Negative()
    {
        var expected = new DateTime(2009, 7, 9, 0, 0, 0, DateTimeKind.Local);
        DateAssert.Equal(expected, new DateTime(2009, 7, 13, 0, 0, 0, DateTimeKind.Local).AddBusinessDays(-2));
    }

    [Fact]
    public void SubtractBusinessDays_SubtractsDaysProperlyWhenThereIsWeekend()
    {
        var expected = new DateTime(2009, 7, 9, 0, 0, 0, DateTimeKind.Local);
        DateAssert.Equal(expected, new DateTime(2009, 7, 13, 0, 0, 0, DateTimeKind.Local).SubtractBusinessDays(2));
    }

    [Fact]
    public void SubtractBusinessDays_Negative()
    {
        var expected = new DateTime(2009, 7, 13, 0, 0, 0, DateTimeKind.Local);
        DateAssert.Equal(expected, new DateTime(2009, 7, 9, 0, 0, 0, DateTimeKind.Local).SubtractBusinessDays(-2));
    }

    [Fact]
    public void IsInFuture()
    {
        var now = DateTime.Now;
        Assert.False(now.Subtract(2.Seconds()).IsInFuture());
        Assert.False(now.IsInFuture());
        Assert.True(now.Add(2.Seconds()).IsInFuture());
    }

    [Fact]
    public void IsInPast()
    {
        var now = DateTime.Now;
        Assert.True(now.Subtract(2.Seconds()).IsInPast());
        Assert.False(now.Add(2.Seconds()).IsInPast());
    }

    [Theory]
    [InlineData(24)]
    [InlineData(25)]
    [InlineData(26)]
    [InlineData(27)]
    [InlineData(28)]
    [InlineData(29)]
    [InlineData(30)]
    public void FirstDayOfWeek_FirstDayOfWeekIsMonday(int value)
    {
        var ci = Thread.CurrentThread.CurrentCulture;
        var currentCulture = new CultureInfo("en-AU")
        {
            DateTimeFormat =
            {
                FirstDayOfWeek = DayOfWeek.Monday
            }
        };
        Thread.CurrentThread.CurrentCulture = currentCulture;
        var expected = new DateTime(2011, 1, 24, 0, 0, 0, DateTimeKind.Local);
        DateAssert.Equal(expected, new DateTime(2011, 1, value, 0, 0, 0, DateTimeKind.Local).FirstDayOfWeek());
        Thread.CurrentThread.CurrentCulture = ci;
    }

    [Theory]
    [InlineData(23)]
    [InlineData(24)]
    [InlineData(25)]
    [InlineData(26)]
    [InlineData(27)]
    [InlineData(28)]
    [InlineData(29)]
    public void FirstDayOfWeek_FirstDayOfWeekIsSunday(int value)
    {
        var ci = Thread.CurrentThread.CurrentCulture;
        var currentCulture = new CultureInfo("en-AU")
        {
            DateTimeFormat =
            {
                FirstDayOfWeek = DayOfWeek.Sunday
            }
        };
        Thread.CurrentThread.CurrentCulture = currentCulture;
        var expected = new DateTime(2011, 1, 23, 0, 0, 0, DateTimeKind.Local);
        DateAssert.Equal(expected, new DateTime(2011, 1, value, 0, 0, 0, DateTimeKind.Local).FirstDayOfWeek());
        Thread.CurrentThread.CurrentCulture = ci;
    }

    [Theory]
    [InlineData("2011-06-22T06:40:20.005")]
    [InlineData("2011-12-31T06:40:20.005")]
    [InlineData("2011-01-01T06:40:20.005")]
    public void FirstDayOfYear_BasicTest(string value)
    {
        Assert.Equal(new DateTime(2011, 1, 1, 6, 40, 20, 5), DateTime.Parse(value).FirstDayOfYear());
    }

    [Theory]
    [InlineData("2011-12-24T06:40:20.005")]
    [InlineData("2011-12-19T06:40:20.005")]
    [InlineData("2011-12-25T06:40:20.005")]
    public void LastDayOfWeek_BasicTest(string value)
    {
        var ci = Thread.CurrentThread.CurrentCulture;
        var currentCulture = new CultureInfo("en-AU")
        {
            DateTimeFormat =
            {
                FirstDayOfWeek = DayOfWeek.Monday
            }
        };
        Thread.CurrentThread.CurrentCulture = currentCulture;
        Assert.Equal(new DateTime(2011, 12, 25, 06, 40, 20, 5), DateTime.Parse(value).LastDayOfWeek());
        Thread.CurrentThread.CurrentCulture = ci;
    }

    [Theory]
    [InlineData("2011-02-13T06:40:20.005")]
    [InlineData("2011-01-01T06:40:20.005")]
    [InlineData("2011-12-31T06:40:20.005")]
    public void LastDayOfYear_BasicTest(string value)
    {
        Assert.Equal(new DateTime(2011, 12, 31, 06, 40, 20, 5), DateTime.Parse(value).LastDayOfYear());
    }

    [Fact]
    public void PreviousMonth_BasicTest()
    {
        var expected = new DateTime(2009, 12, 20, 06, 40, 20, 5, DateTimeKind.Local);
        DateAssert.Equal(expected, new DateTime(2010, 1, 20, 06, 40, 20, 5, DateTimeKind.Local).PreviousMonth());
    }

    [Fact]
    public void PreviousMonth_PreviousMonthDoesntHaveThatManyDays()
    {
        var expected = new DateTime(2009, 2, 28, 06, 40, 20, 5, DateTimeKind.Local);
        DateAssert.Equal(expected, new DateTime(2009, 3, 31, 06, 40, 20, 5, DateTimeKind.Local).PreviousMonth());
    }

    [Fact]
    public void NextMonth_BasicTest()
    {
        var expected = new DateTime(2013, 1, 5, 06, 40, 20, 5, DateTimeKind.Local);
        DateAssert.Equal(expected, new DateTime(2012, 12, 5, 06, 40, 20, 5, DateTimeKind.Local).NextMonth());
    }

    [Fact]
    public void PreviousMonth_NextMonthDoesntHaveThatManyDays()
    {
        var expected = new DateTime(2013, 2, 28, 06, 40, 20, 5, DateTimeKind.Local);
        DateAssert.Equal(expected, new DateTime(2013, 1, 31, 06, 40, 20, 5, DateTimeKind.Local).NextMonth());
    }

    [Theory]
    [InlineData("2015-11-25T00:00:00.000")]
    [InlineData("2015-12-25T00:00:00.000")]
    [InlineData("2015-10-25T00:00:00.000")]
    public void SameYear_Y(string dateValue)
    {
        var other = DateTime.Parse(dateValue);
        var date = new DateTime(2015, 11, 25);

        Assert.True(date.SameYear(other));
    }

    [Theory]
    [InlineData("2014-11-25T00:00:00.000")]
    [InlineData("2013-11-25T00:00:00.000")]
    [InlineData("1995-11-25T00:00:00.000")]
    public void SameYear_N(string dateValue)
    {
        var other = DateTime.Parse(dateValue);
        var date = new DateTime(2015, 11, 25);

        Assert.False(date.SameYear(other));
    }

    [Theory]
    [InlineData("2015-11-25T00:00:00.000")]
    [InlineData("2015-11-01T00:00:00.000")]
    [InlineData("2015-11-15T00:00:00.000")]
    public void SameMonth_Y(string dateValue)
    {
        var other = DateTime.Parse(dateValue);
        var date = new DateTime(2015, 11, 25);

        Assert.True(date.SameMonth(other));
    }

    [Theory]
    [InlineData("2016-11-25T00:00:00.000")]
    [InlineData("2014-11-01T12:00:00.000")]
    [InlineData("2015-10-15T18:00:00.000")]
    public void SameMonth_N(string dateValue)
    {
        var other = DateTime.Parse(dateValue);
        var date = new DateTime(2015, 11, 25);

        Assert.False(date.SameMonth(other));
    }

    [Theory]
    [InlineData("2015-11-25T12:25:00.000")]
    [InlineData("2015-11-25T23:59:59.999")]
    public void SameDay_Y(string dateValue)
    {
        var other = DateTime.Parse(dateValue);
        var date = new DateTime(2015, 11, 25);

        Assert.True(date.SameDay(other));
    }

    [Theory]
    [InlineData("2014-11-25T12:25:00.000")]
    [InlineData("2015-12-25T23:59:59.999")]
    [InlineData("2015-10-25T23:59:59.999")]
    public void SameDay_N(string dateValue)
    {
        var other = DateTime.Parse(dateValue);
        var date = new DateTime(2015, 11, 25);

        Assert.False(date.SameDay(other));
    }
}