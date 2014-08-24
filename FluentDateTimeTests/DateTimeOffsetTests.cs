// ReSharper disable InvokeAsExtensionMethod
using System;
using System.Globalization;
using FluentDate;
using FluentDateTimeOffset;
using NUnit.Framework;
using System.Threading;

[TestFixture]
public class DateTimeOffsetTests
{
    const int DAYS_PER_WEEK = 7;

    [Test]
    [TestCase(1)]
    [TestCase(32)]
    [TestCase(40)]
    [TestCase(100)]
    [TestCase(1000)]
    [TestCase(-1)]
    [TestCase(-100)]
    [TestCase(0)]
    public void Ago_FromFixedDateTime_Tests(int agoValue)
    {
        var originalPointInTime = new DateTimeOffset(1976, 12, 31, 17, 0, 0, 0, TimeSpan.Zero);

        Assert.AreEqual(agoValue.Years().Before(originalPointInTime), originalPointInTime.AddYears(-agoValue));
        Assert.AreEqual(agoValue.Months().Before(originalPointInTime), originalPointInTime.AddMonths(-agoValue));
        Assert.AreEqual(agoValue.Weeks().Before(originalPointInTime), originalPointInTime.AddDays(-agoValue*DAYS_PER_WEEK));
        Assert.AreEqual(agoValue.Days().Before(originalPointInTime), originalPointInTime.AddDays(-agoValue));

        Assert.AreEqual(agoValue.Hours().Before(originalPointInTime), originalPointInTime.AddHours(-agoValue));
        Assert.AreEqual(agoValue.Minutes().Before(originalPointInTime), originalPointInTime.AddMinutes(-agoValue));
        Assert.AreEqual(agoValue.Seconds().Before(originalPointInTime), originalPointInTime.AddSeconds(-agoValue));
        Assert.AreEqual(agoValue.Milliseconds().Before(originalPointInTime), originalPointInTime.AddMilliseconds(-agoValue));
        Assert.AreEqual(agoValue.Ticks().Before(originalPointInTime), originalPointInTime.AddTicks(-agoValue));
    }

    [Test]
    public void Ago_FromOneMonth()
    {
        var originalPointInTime = new DateTimeOffset(1976, 4, 30, 0, 0, 0, TimeSpan.Zero);

        Assert.AreEqual(1.Months().Before(originalPointInTime), new DateTimeOffset(1976, 3, 30, 0, 0, 0, TimeSpan.Zero));
        Assert.AreEqual(1.Months().From(originalPointInTime), new DateTimeOffset(1976, 5, 30, 0, 0, 0, TimeSpan.Zero));
    }

    [Test]
    public void Ago_FromOneYearLeap()
    {
        var originalPointInTime = new DateTimeOffset(2004, 2, 29, 0, 0, 0, TimeSpan.Zero);

        Assert.AreEqual(1.Years().Before(originalPointInTime), new DateTimeOffset(2003, 2, 28, 0, 0, 0, TimeSpan.Zero));
        Assert.AreEqual(1.Years().From(originalPointInTime), new DateTimeOffset(2005, 2, 28, 0, 0, 0, TimeSpan.Zero));
    }


    [Test]
    [TestCase(1)]
    [TestCase(32)]
    [TestCase(100)]
    [TestCase(1000)]
    [TestCase(-1)]
    [TestCase(-100)]
    [TestCase(0)]
    public void From_FromFixedDateTime_Tests(int value)
    {
        var originalPointInTime = new DateTimeOffset(1976, 12, 31, 17, 0, 0, 0, TimeSpan.Zero);

        Assert.AreEqual(value.Years().From(originalPointInTime), originalPointInTime.AddYears(value));
        Assert.AreEqual(value.Months().From(originalPointInTime), originalPointInTime.AddMonths(value));
        Assert.AreEqual(value.Weeks().From(originalPointInTime), originalPointInTime.AddDays(value*DAYS_PER_WEEK));
        Assert.AreEqual(value.Days().From(originalPointInTime), originalPointInTime.AddDays(value));

        Assert.AreEqual(value.Hours().From(originalPointInTime), originalPointInTime.AddHours(value));
        Assert.AreEqual(value.Minutes().From(originalPointInTime), originalPointInTime.AddMinutes(value));
        Assert.AreEqual(value.Seconds().From(originalPointInTime), originalPointInTime.AddSeconds(value));
        Assert.AreEqual(value.Milliseconds().From(originalPointInTime), originalPointInTime.AddMilliseconds(value));
        Assert.AreEqual(value.Ticks().From(originalPointInTime), originalPointInTime.AddTicks(value));
    }



    [Test]
    [TestCase(24, ExpectedException = typeof (ArgumentOutOfRangeException))]
    [TestCase(-1, ExpectedException = typeof (ArgumentOutOfRangeException))]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(23)]
    public void ChangeTime_Hour_SimpleTests(int value)
    {
        var toChange = new DateTimeOffset(2008, 10, 25, 0, 0, 0, 0, TimeSpan.Zero);

        var result = toChange.SetTime(value);
        var expected = new DateTimeOffset(2008, 10, 25, value, 0, 0, 0, TimeSpan.Zero);

        Assert.AreEqual(expected, result);
    }


    [Test]
    [TestCase(0)]
    [TestCase(16)]
    [TestCase(59)]
    [TestCase(-1, ExpectedException = typeof (ArgumentOutOfRangeException))]
    [TestCase(60, ExpectedException = typeof (ArgumentOutOfRangeException))]
    public void ChangeTime_Minute_SimpleTests(int value)
    {
        var toChange = new DateTimeOffset(2008, 10, 25, 0, 0, 0, 0, TimeSpan.Zero);

        Assert.AreEqual(new DateTimeOffset(2008, 10, 25, 0, value, 0, 0, TimeSpan.Zero), toChange.SetTime(0, value));
    }

    [Test]
    [TestCase(0)]
    [TestCase(16)]
    [TestCase(59)]
    [TestCase(-1, ExpectedException = typeof (ArgumentOutOfRangeException))]
    [TestCase(60, ExpectedException = typeof (ArgumentOutOfRangeException))]
    public void ChangeTime_Second_SimpleTests(int value)
    {
        var toChange = new DateTimeOffset(2008, 10, 25, 0, 0, 0, 0, TimeSpan.Zero);

        var changed = toChange.SetTime(0, 0, value);


        var expected = new DateTimeOffset(2008, 10, 25, 0, 0, value, 0, TimeSpan.Zero);

        Assert.AreEqual(expected, changed);
    }

    [Test]
    [TestCase(0)]
    [TestCase(100)]
    [TestCase(999)]
    [TestCase(-1, ExpectedException = typeof (ArgumentOutOfRangeException))]
    [TestCase(1000, ExpectedException = typeof (ArgumentOutOfRangeException))]
    public void ChangeTime_Millisecond_SimpleTests(int value)
    {
        var toChange = new DateTimeOffset(2008, 10, 25, 0, 0, 0, 0, TimeSpan.Zero);

        Assert.AreEqual(new DateTimeOffset(2008, 10, 25, 0, 0, 0, value, TimeSpan.Zero), toChange.SetTime(0, 0, 0, value));
    }

    [Test]
    public void BasicTests()
    {
        var now = DateTimeOffset.UtcNow;
        var expected = new DateTimeOffset(now.Year, now.Month, now.Day, 23, 59, 59, 999, TimeSpan.Zero);
        var actual = now.EndOfDay();
        Assert.AreEqual(expected, actual, " End of the day wrong");
        Assert.AreEqual(new DateTimeOffset(now.Year, now.Month, now.Day, 0, 0, 0, 0, TimeSpan.Zero), now.BeginningOfDay(), "Start of the day wrong");

        var firstBirthDay = new DateTimeOffset(1977, 12, 31, 17, 0, 0, 0, TimeSpan.Zero);
        Assert.AreEqual(firstBirthDay + new TimeSpan(1, 0, 5, 0, 0), firstBirthDay + 1.Days() + 5.Minutes());

        Assert.AreEqual(now + TimeSpan.FromDays(1), now.NextDay());
        Assert.AreEqual(now - TimeSpan.FromDays(1), now.PreviousDay());

        Assert.AreEqual(now + TimeSpan.FromDays(7), now.WeekAfter());
        Assert.AreEqual(now - TimeSpan.FromDays(7), now.WeekEarlier());

        Assert.AreEqual(new DateTimeOffset(2009, 1, 1, 0, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2008, 12, 31, 0, 0, 0, TimeSpan.Zero).Add(1.Days()));
        Assert.AreEqual(new DateTimeOffset(2009, 1, 2, 0, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2009, 1, 1, 0, 0, 0, 0, TimeSpan.Zero).Add(1.Days()));

        var sampleDate = new DateTimeOffset(2009, 1, 1, 13, 0, 0, 0, TimeSpan.Zero);
        Assert.AreEqual(new DateTimeOffset(2009, 1, 1, 12, 0, 0, 0, TimeSpan.Zero), sampleDate.Noon());
        Assert.AreEqual(new DateTimeOffset(2009, 1, 1, 0, 0, 0, 0, TimeSpan.Zero), sampleDate.Midnight());

        Assert.AreEqual(3.Days() + 3.Days(), 6.Days());
        Assert.AreEqual(102.Days() - 3.Days(), 99.Days());

        Assert.AreEqual(24.Hours(), 1.Days());

        sampleDate = new DateTimeOffset(2008, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);
        Assert.AreEqual(3.Days().Since(sampleDate), sampleDate + 3.Days());

        var saturday = new DateTimeOffset(2008, 10, 25, 12, 0, 0, TimeSpan.Zero);
        Assert.AreEqual(new DateTimeOffset(2008, 11, 1, 12, 0, 0, TimeSpan.Zero), saturday.Next(DayOfWeek.Saturday));

        Assert.AreEqual(new DateTimeOffset(2008, 10, 18, 12, 0, 0, TimeSpan.Zero), saturday.Previous(DayOfWeek.Saturday));

        var nextWeek = DateTimeOffset.UtcNow + 1.Weeks();

        var tomorrow = DateTimeOffset.UtcNow + 1.Days();
        var yesterday = DateTimeOffset.UtcNow - 1.Days();
        var changedHourTo14h = DateTimeOffset.UtcNow.SetHour(14);
        var todayNoon = DateTimeOffset.UtcNow.Noon();
        var tomorrowNoon = DateTimeOffset.UtcNow.NextDay().Noon();
        var fiveDaysAgo = TimeSpanOffsetExtensions.Ago(5.Days());
        var twoDaysFromNow = TimeSpanOffsetExtensions.FromNow(2.Days());
        var nextYearSameDateAsTodayNoon = TimeSpanOffsetExtensions.FromNow(1.Years()).Noon();

        var twoWeeksFromNow = TimeSpanOffsetExtensions.FromNow(2.Weeks());

    }

    [Test]
    public void NextYear_ReturnsTheSameDateButNextYear()
    {
        var birthday = new DateTimeOffset(1976, 12, 31, 17, 0, 0, 0, TimeSpan.Zero);
        var nextYear = birthday.NextYear();
        Assert.AreEqual(new DateTimeOffset(1977, 12, 31, 17, 0, 0, 0, TimeSpan.Zero), nextYear);
    }

    [Test]
    public void PreviousYear_ReturnsTheSameDateButPreviousYear()
    {
        var birthday = new DateTimeOffset(1976, 12, 31, 17, 0, 0, 0, TimeSpan.Zero);
        var previousYear = birthday.PreviousYear();
        Assert.AreEqual(new DateTimeOffset(1975, 12, 31, 17, 0, 0, 0, TimeSpan.Zero), previousYear);
    }


    [Test]
    public void NextYear_IfNextYearDoesNotHaveTheSameDayInTheSameMonthThenCalculateHowManyDaysIsMissingAndAddThatToTheLastDayInTheSameMonthNextYear()
    {
        var someBirthday = new DateTimeOffset(2008, 2, 29, 17, 0, 0, 0, TimeSpan.Zero);
        var nextYear = someBirthday.NextYear();
        Assert.AreEqual(new DateTimeOffset(2009, 3, 1, 17, 0, 0, 0, TimeSpan.Zero), nextYear);
    }

    [Test]
    public void PreviousYear_IfPreviousYearDoesNotHaveTheSameDayInTheSameMonthThenCalculateHowManyDaysIsMissingAndAddThatToTheLastDayInTheSameMonthPreviousYear()
    {
        var someBirthday = new DateTimeOffset(2012, 2, 29, 17, 0, 0, 0, TimeSpan.Zero);
        var previousYear = someBirthday.PreviousYear();
        Assert.AreEqual(new DateTimeOffset(2011, 3, 1, 17, 0, 0, 0, TimeSpan.Zero), previousYear);
    }

    [Test]
    public void Next_ReturnsNextFridayProperly()
    {
        var friday = new DateTimeOffset(2009, 7, 10, 1, 0, 0, 0, TimeSpan.Zero);
        var reallyNextFriday = new DateTimeOffset(2009, 7, 17, 1, 0, 0, 0, TimeSpan.Zero);
        var nextFriday = friday.Next(DayOfWeek.Friday);

        Assert.AreEqual(reallyNextFriday, nextFriday);
    }

    [Test]
    public void Next_ReturnsPreviousFridayProperly()
    {
        var friday = new DateTimeOffset(2009, 7, 17, 1, 0, 0, 0, TimeSpan.Zero);
        var reallyPreviousFriday = new DateTimeOffset(2009, 7, 10, 1, 0, 0, 0, TimeSpan.Zero);
        var previousFriday = friday.Previous(DayOfWeek.Friday);

        Assert.AreEqual(reallyPreviousFriday, previousFriday);
    }

    [Test]
    public void IsBefore_ReturnsTrueForGivenDateThatIsInTheFuture()
    {
        // arrange
        var toCompareWith = DateTimeOffset.UtcNow + 1.Days();

        // assert
        Assert.IsTrue(DateTimeOffset.UtcNow.IsBefore(toCompareWith));
    }

    [Test]
    public void IsBefore_ReturnsFalseForGivenDateThatIsSame()
    {
        // arrange
        var toCompareWith = DateTimeOffset.UtcNow;

        // assert
        Assert.IsFalse(toCompareWith.IsBefore(toCompareWith));
    }

    [Test]
    public void IsAfter_ReturnsTrueForGivenDateThatIsInThePast()
    {
        // arrange
        var toCompareWith = DateTimeOffset.UtcNow - 1.Days();

        // assert
        Assert.IsTrue(DateTimeOffset.UtcNow.IsAfter(toCompareWith));
    }

    [Test]
    public void IsAfter_ReturnsFalseForGivenDateThatIsSame()
    {
        // arrange
        var toCompareWith = DateTimeOffset.UtcNow;

        // assert
        Assert.IsFalse(toCompareWith.IsAfter(toCompareWith));
    }

    [Test]
    public void At_SetsHourAndMinutesProperly()
    {
        Assert.AreEqual(new DateTimeOffset(2002, 12, 17, 18, 06, 01, TimeSpan.Zero), new DateTimeOffset(2002, 12, 17, 17, 05, 01, TimeSpan.Zero).At(18, 06));
    }

    [Test]
    public void At_SetsHourAndMinutesAndSecondsProperly()
    {
        Assert.AreEqual(new DateTimeOffset(2002, 12, 17, 18, 06, 02, TimeSpan.Zero), new DateTimeOffset(2002, 12, 17, 17, 05, 01, TimeSpan.Zero).At(18, 06, 02));
    }

    [Test]
    public void At_SetsHourAndMinutesAndMillisecondsProperly()
    {
        Assert.AreEqual(new DateTimeOffset(2002, 12, 17, 18, 06, 02, 03, TimeSpan.Zero), new DateTimeOffset(2002, 12, 17, 17, 05, 01, TimeSpan.Zero).At(18, 06, 02, 03));
    }

    [Test]
    public void PreviousQuarter_FirstDay_SetsTheDayToOne()
    {
        var expected = new DateTimeOffset(2001, 10, 1, 3, 5, 6, TimeSpan.Zero);
        Assert.AreEqual(expected.BeginningOfDay(), 1.Quarters().Ago(new DateTimeOffset(2002, 1, 10, 4, 5, 6, TimeSpan.Zero).FirstDayOfQuarter().BeginningOfDay()));
    }

    [Test]
    public void PreviousQuarter_LastDay_SetsTheDayToLastDayOfQuarter()
    {
        var expected = new DateTimeOffset(2001, 12, 31, 3, 5, 6, TimeSpan.Zero);
        Assert.AreEqual(expected.BeginningOfDay(), 1.Quarters().Ago(new DateTimeOffset(2002, 1, 10, 4, 5, 6, TimeSpan.Zero).LastDayOfQuarter().BeginningOfDay()));
    }

    [Test]
    public void NextQuarter_FirstDay_SetsTheDayToOne()
    {
        var expected = new DateTimeOffset(2002, 4, 1, 3, 5, 6, TimeSpan.Zero);
        Assert.AreEqual(expected.BeginningOfDay(), 1.Quarters().From(new DateTimeOffset(2002, 1, 10, 4, 5, 6, TimeSpan.Zero).FirstDayOfQuarter().BeginningOfDay()));
    }

    [Test]
    public void NextQuarter_LastDay_SetsTheDayToLastDayOfQuarter()
    {
        var expected = new DateTimeOffset(2002, 6, 30, 3, 5, 6, TimeSpan.Zero);
        Assert.AreEqual(expected.BeginningOfDay(), 1.Quarters().From(new DateTimeOffset(2002, 1, 10, 4, 5, 6, TimeSpan.Zero).LastDayOfQuarter().BeginningOfDay()));
    }

    [Test]
    public void FirstDayOfQuarter_SetsTheDayToOne()
    {
        var expected = new DateTimeOffset(2002, 1, 1, 6, 3, 0, TimeSpan.Zero);
        Assert.AreEqual(expected.BeginningOfDay(), new DateTimeOffset(2002, 3, 22, 12, 12, 12, TimeSpan.Zero).FirstDayOfQuarter().BeginningOfDay());
    }

    [Test]
    public void LastDayOfQuarter_SetsTheDayToLastDayInThatQuarter()
    {
        var expected = new DateTimeOffset(2002, 3, 31, 6, 3, 0, TimeSpan.Zero);
        Assert.AreEqual(expected.BeginningOfDay(), new DateTimeOffset(2002, 3, 22, 12, 12, 12, TimeSpan.Zero).LastDayOfQuarter().BeginningOfDay());
    }

    [Test]
    public void FirstDayOfQuarter_Q4_SetsDayToFirstDay()
    {
        var expected = new DateTimeOffset(2002, 10, 1, 7, 8, 9, TimeSpan.Zero);
        Assert.AreEqual(expected.BeginningOfDay(), new DateTimeOffset(2002, 11, 22, 12, 12, 12, TimeSpan.Zero).FirstDayOfQuarter().BeginningOfDay());
    }

    [Test]
    public void LastDayOfQuarter_Q4_SetsTheDayToLastDayOfQuarter()
    {
        var expected = new DateTimeOffset(2002, 12, 31, 4, 5, 6, TimeSpan.Zero);
        Assert.AreEqual(expected.BeginningOfDay(), new DateTimeOffset(2002, 11, 22, 12, 12, 12, TimeSpan.Zero).LastDayOfQuarter().BeginningOfDay());
    }

    [Test]
    public void FirstDayOfMonth_SetsTheDayToOne()
    {
        Assert.AreEqual(new DateTimeOffset(2002, 12, 1, 17, 05, 01, TimeSpan.Zero), new DateTimeOffset(2002, 12, 17, 17, 05, 01, TimeSpan.Zero).FirstDayOfMonth());
    }

    [Test]
    public void LastDayOfMonth_SetsTheDayToLastDayInThatMonth()
    {
        Assert.AreEqual(new DateTimeOffset(2002, 1, 31, 17, 05, 01, TimeSpan.Zero), new DateTimeOffset(2002, 1, 1, 17, 05, 01, TimeSpan.Zero).LastDayOfMonth());
    }

    [Test]
    public void AddBusinessDays_AdsDaysProperlyWhenThereIsWeekendAhead()
    {
        Assert.AreEqual(new DateTimeOffset(2009, 7, 13, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2009, 7, 9, 0, 0, 0, TimeSpan.Zero).AddBusinessDays(2));
    }

    [Test]
    public void AddBusinessDays_Negative()
    {
        Assert.AreEqual(new DateTimeOffset(2009, 7, 9, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2009, 7, 13, 0, 0, 0, TimeSpan.Zero).AddBusinessDays(-2));
    }

    [Test]
    public void SubtractBusinessDays_SubtractsDaysProperlyWhenThereIsWeekend()
    {
        Assert.AreEqual(new DateTimeOffset(2009, 7, 9, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2009, 7, 13, 0, 0, 0, TimeSpan.Zero).SubtractBusinessDays(2));
    }

    [Test]
    public void SubtractBusinessDays_Negative()
    {
        Assert.AreEqual(new DateTimeOffset(2009, 7, 13, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2009, 7, 9, 0, 0, 0, TimeSpan.Zero).SubtractBusinessDays(-2));
    }

    [Test]
    public void IsInFuture()
    {
        var now = DateTimeOffset.UtcNow;
        Assert.IsFalse(now.Subtract(2.Seconds()).IsInFuture());
        Assert.IsFalse(now.IsInFuture());
        Assert.IsTrue(now.Add(2.Seconds()).IsInFuture());
    }

    [Test]
    public void IsInPast()
    {
        var now = DateTimeOffset.UtcNow;
        Assert.IsTrue(now.Subtract(2.Seconds()).IsInPast());
        Assert.IsFalse(now.Add(2.Seconds()).IsInPast());
    }

    [Test]
    [TestCase(24)]
    [TestCase(25)]
    [TestCase(26)]
    [TestCase(27)]
    [TestCase(28)]
    [TestCase(29)]
    [TestCase(30)]
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
        Assert.AreEqual(new DateTimeOffset(2011, 1, 24, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 1, value, 0, 0, 0, TimeSpan.Zero).FirstDayOfWeek());
        Thread.CurrentThread.CurrentCulture = ci;
    }

    [Test]
    [TestCase(23)]
    [TestCase(24)]
    [TestCase(25)]
    [TestCase(26)]
    [TestCase(27)]
    [TestCase(28)]
    [TestCase(29)]
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
        Assert.AreEqual(new DateTimeOffset(2011, 1, 23, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 1, value, 0, 0, 0, TimeSpan.Zero).FirstDayOfWeek());
        Thread.CurrentThread.CurrentCulture = ci;
    }

    [Test]
    [TestCase("2011-06-22T06:40:20.005 +00:00")]
    [TestCase("2011-12-31T06:40:20.005 +00:00")]
    [TestCase("2011-01-01T06:40:20.005 +00:00")]
    public void FirstDayOfYear_BasicTest(string value)
    {
        var expected = new DateTimeOffset(2011, 1, 1, 6, 40, 20, 5, TimeSpan.Zero);
        Assert.AreEqual(expected, DateTimeOffset.Parse(value).FirstDayOfYear());
    }

    [Test]
    [TestCase("2011-12-24T06:40:20.005 +00:00")]
    [TestCase("2011-12-19T06:40:20.005 +00:00")]
    [TestCase("2011-12-25T06:40:20.005 +00:00")]
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
        var expected = new DateTimeOffset(2011, 12, 25, 06, 40, 20, 5, TimeSpan.Zero);
        Assert.AreEqual(expected, DateTimeOffset.Parse(value).LastDayOfWeek());
        Thread.CurrentThread.CurrentCulture = ci;
    }

    [Test]
    [TestCase("2011-02-13T06:40:20.005 +00:00")]
    [TestCase("2011-01-01T06:40:20.005 +00:00")]
    [TestCase("2011-12-31T06:40:20.005 +00:00")]
    public void LastDayOfYear_BasicTest(string value)
    {
        var expected = new DateTimeOffset(2011, 12, 31, 06, 40, 20, 5, TimeSpan.Zero);
        Assert.AreEqual(expected, DateTimeOffset.Parse(value).LastDayOfYear());
    }

    [Test]
    public void PreviousMonth_BasicTest()
    {
        var expected = new DateTimeOffset(2009, 12, 20, 06, 40, 20, 5, TimeSpan.Zero);
        Assert.AreEqual(expected, new DateTimeOffset(2010, 1, 20, 06, 40, 20, 5, TimeSpan.Zero).PreviousMonth());
    }

    [Test]
    public void PreviousMonth_PreviousMonthDoesntHaveThatManyDays()
    {
        Assert.AreEqual(new DateTimeOffset(2009, 2, 28, 06, 40, 20, 5, TimeSpan.Zero), new DateTimeOffset(2009, 3, 31, 06, 40, 20, 5, TimeSpan.Zero).PreviousMonth());
    }


    [Test]
    public void NextMonth_BasicTest()
    {
        Assert.AreEqual(new DateTimeOffset(2013, 1, 5, 06, 40, 20, 5, TimeSpan.Zero), new DateTimeOffset(2012, 12, 5, 06, 40, 20, 5, TimeSpan.Zero).NextMonth());
    }

    [Test]
    public void PreviousMonth_NextMonthDoesntHaveThatManyDays()
    {
        Assert.AreEqual(new DateTimeOffset(2013, 2, 28, 06, 40, 20, 5, TimeSpan.Zero), new DateTimeOffset(2013, 1, 31, 06, 40, 20, 5, TimeSpan.Zero).NextMonth());
    }
}