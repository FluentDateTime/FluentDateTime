using System;
using System.Globalization;
using FluentDateTime;
using NUnit.Framework;
using System.Threading;

namespace FluentDateTimeTests
{
    [TestFixture]
    public class DateTimeBasicTests
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
            var originalPointInTime = new DateTime(1976, 12, 31, 17, 0, 0, 0);

            Assert.AreEqual(agoValue.Years().Before(originalPointInTime), originalPointInTime.AddYears(-agoValue));
            Assert.AreEqual(agoValue.Months().Before(originalPointInTime), originalPointInTime.AddMonths(-agoValue));
            Assert.AreEqual(agoValue.Weeks().Before(originalPointInTime), originalPointInTime.AddDays(-agoValue * DAYS_PER_WEEK));
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
            var originalPointInTime = new DateTime(1976, 4, 30);

            Assert.AreEqual(1.Months().Before(originalPointInTime), new DateTime(1976, 3, 30));
            Assert.AreEqual(1.Months().From(originalPointInTime), new DateTime(1976, 5, 30));
        }

        [Test]
        public void Ago_FromOneYearLeap()
        {
            var originalPointInTime = new DateTime(2004, 2, 29);

            Assert.AreEqual(1.Years().Before(originalPointInTime), new DateTime(2003, 2, 28));
            Assert.AreEqual(1.Years().From(originalPointInTime), new DateTime(2005, 2, 28));
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
            var originalPointInTime = new DateTime(1976, 12, 31, 17, 0, 0, 0);

            Assert.AreEqual(value.Years().From(originalPointInTime), originalPointInTime.AddYears(value));
            Assert.AreEqual(value.Months().From(originalPointInTime), originalPointInTime.AddMonths(value));
            Assert.AreEqual(value.Weeks().From(originalPointInTime), originalPointInTime.AddDays(value * DAYS_PER_WEEK));
            Assert.AreEqual(value.Days().From(originalPointInTime), originalPointInTime.AddDays(value));

            Assert.AreEqual(value.Hours().From(originalPointInTime), originalPointInTime.AddHours(value));
            Assert.AreEqual(value.Minutes().From(originalPointInTime), originalPointInTime.AddMinutes(value));
            Assert.AreEqual(value.Seconds().From(originalPointInTime), originalPointInTime.AddSeconds(value));
            Assert.AreEqual(value.Milliseconds().From(originalPointInTime), originalPointInTime.AddMilliseconds(value));
            Assert.AreEqual(value.Ticks().From(originalPointInTime), originalPointInTime.AddTicks(value));
        }


        [Test]
        [TestCase(1)]
        [TestCase(32)]
        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(-1)]
        [TestCase(-100)]
        [TestCase(0)]
        public void Years_Months_Weeks_Days_Hours_Minutes_Seconds_Milliseconds_SimpleTests(int value)
        {
            Assert.AreEqual(value.Years(), new FluentTimeSpan { Years = value });
            Assert.AreEqual(value.Months(), new FluentTimeSpan { Months = value });
            Assert.AreEqual(value.Weeks(), new FluentTimeSpan { TimeSpan = TimeSpan.FromDays(value * DAYS_PER_WEEK) });
            Assert.AreEqual(value.Days(), new FluentTimeSpan { TimeSpan = TimeSpan.FromDays(value) });

            Assert.AreEqual(value.Hours(), new FluentTimeSpan { TimeSpan = TimeSpan.FromHours(value) });
            Assert.AreEqual(value.Minutes(), new FluentTimeSpan { TimeSpan = TimeSpan.FromMinutes(value) });
            Assert.AreEqual(value.Seconds(), new FluentTimeSpan { TimeSpan = TimeSpan.FromSeconds(value) });
            Assert.AreEqual(value.Milliseconds(), new FluentTimeSpan { TimeSpan = TimeSpan.FromMilliseconds(value) });
            Assert.AreEqual(value.Ticks(), new FluentTimeSpan { TimeSpan = TimeSpan.FromTicks(value) });
        }

        [Test]
        [TestCase(24, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(-1, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(23)]
        public void ChangeTime_Hour_SimpleTests(int value)
        {
            var toChange = new DateTime(2008, 10, 25, 0, 0, 0, 0);

            var result = toChange.SetTime(value);
            var expected = new DateTime(2008, 10, 25, value, 0, 0, 0);

            Assert.AreEqual(expected, result);
        }


        [Test]
        [TestCase(0)]
        [TestCase(16)]
        [TestCase(59)]
        [TestCase(-1, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(60, ExpectedException = typeof(ArgumentOutOfRangeException))]
        public void ChangeTime_Minute_SimpleTests(int value)
        {
            var toChange = new DateTime(2008, 10, 25, 0, 0, 0, 0);

            Assert.AreEqual(new DateTime(2008, 10, 25, 0, value, 0, 0), toChange.SetTime(0, value));
        }

        [Test]
        [TestCase(0)]
        [TestCase(16)]
        [TestCase(59)]
        [TestCase(-1, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(60, ExpectedException = typeof(ArgumentOutOfRangeException))]
        public void ChangeTime_Second_SimpleTests(int value)
        {
            var toChange = new DateTime(2008, 10, 25, 0, 0, 0, 0);

            var changed = toChange.SetTime(0, 0, value);


            var expected = new DateTime(2008, 10, 25, 0, 0, value, 0);

            Assert.AreEqual(expected, changed);
        }

        [Test]
        [TestCase(0)]
        [TestCase(100)]
        [TestCase(999)]
        [TestCase(-1, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(1000, ExpectedException = typeof(ArgumentOutOfRangeException))]
        public void ChangeTime_Millisecond_SimpleTests(int value)
        {
            var toChange = new DateTime(2008, 10, 25, 0, 0, 0, 0);

            Assert.AreEqual(new DateTime(2008, 10, 25, 0, 0, 0, value), toChange.SetTime(0, 0, 0, value));
        }

        [Test]
        public void BasicTests()
        {
            var now = DateTime.Now;
            Assert.AreEqual(new DateTime(now.Year, now.Month, now.Day, 23, 59, 59, 999), DateTime.Now.EndOfDay(), " End of the day wrong");
            Assert.AreEqual(new DateTime(now.Year, now.Month, now.Day, 0, 0, 0, 0), DateTime.Now.BeginningOfDay(), "Start of the day wrong");

            var firstBirthDay = new DateTime(1977, 12, 31, 17, 0, 0, 0);
            Assert.AreEqual(firstBirthDay + new TimeSpan(1, 0, 5, 0, 0), firstBirthDay + 1.Days() + 5.Minutes());

            Assert.AreEqual(now + TimeSpan.FromDays(1), now.NextDay());
            Assert.AreEqual(now - TimeSpan.FromDays(1), now.PreviousDay());

            Assert.AreEqual(now + TimeSpan.FromDays(7), now.WeekAfter());
            Assert.AreEqual(now - TimeSpan.FromDays(7), now.WeekEarlier());

            Assert.AreEqual(new DateTime(2009, 1, 1, 0, 0, 0, 0), new DateTime(2008, 12, 31, 0, 0, 0).Add(1.Days()));
            Assert.AreEqual(new DateTime(2009, 1, 2, 0, 0, 0, 0), new DateTime(2009, 1, 1, 0, 0, 0, 0).Add(1.Days()));

            var sampleDate = new DateTime(2009, 1, 1, 13, 0, 0, 0);
            Assert.AreEqual(new DateTime(2009, 1, 1, 12, 0, 0, 0), sampleDate.Noon());
            Assert.AreEqual(new DateTime(2009, 1, 1, 0, 0, 0, 0), sampleDate.Midnight());

            Assert.AreEqual(3.Days() + 3.Days(), 6.Days());
            Assert.AreEqual(102.Days() - 3.Days(), 99.Days());

            Assert.AreEqual(24.Hours(), 1.Days());

            sampleDate = new DateTime(2008, 1, 1, 0, 0, 0, 0);
            Assert.AreEqual(3.Days().Since(sampleDate), sampleDate + 3.Days());

            var saturday = new DateTime(2008, 10, 25, 12, 0, 0);
            Assert.AreEqual(new DateTime(2008, 11, 1, 12, 0, 0), saturday.Next(DayOfWeek.Saturday));

            Assert.AreEqual(new DateTime(2008, 10, 18, 12, 0, 0), saturday.Previous(DayOfWeek.Saturday));

            var nextWeek = DateTime.Now + 1.Weeks();

            var tomorrow = DateTime.Now + 1.Days();
            var yesterday = DateTime.Now - 1.Days();
            var changedHourTo14h = DateTime.Now.SetHour(14);
            var todayNoon = DateTime.Now.Noon();
            var tomorrowNoon = DateTime.Now.NextDay().Noon();
            var fiveDaysAgo = 5.Days().Ago();
            var twoDaysFromNow = 2.Days().FromNow();
            var nextYearSameDateAsTodayNoon = 1.Years().FromNow().Noon();

            var twoWeeksFromNow = 2.Weeks().FromNow();

        }

        [Test]
        public void NextYear_ReturnsTheSameDateButNextYear()
        {
            var birthday = new DateTime(1976, 12, 31, 17, 0, 0, 0);
            var nextYear = birthday.NextYear();
            Assert.AreEqual(new DateTime(1977, 12, 31, 17, 0, 0, 0), nextYear);
        }

        [Test]
        public void PreviousYear_ReturnsTheSameDateButPreviousYear()
        {
            var birthday = new DateTime(1976, 12, 31, 17, 0, 0, 0);
            var previousYear = birthday.PreviousYear();
            Assert.AreEqual(new DateTime(1975, 12, 31, 17, 0, 0, 0), previousYear);
        }


        [Test]
        public void NextYear_IfNextYearDoesNotHaveTheSameDayInTheSameMonthThenCalculateHowManyDaysIsMissingAndAddThatToTheLastDayInTheSameMonthNextYear()
        {
            var someBirthday = new DateTime(2008, 2, 29, 17, 0, 0, 0);
            var nextYear = someBirthday.NextYear();
            Assert.AreEqual(new DateTime(2009, 3, 1, 17, 0, 0, 0), nextYear);
        }

        [Test]
        public void PreviousYear_IfPreviousYearDoesNotHaveTheSameDayInTheSameMonthThenCalculateHowManyDaysIsMissingAndAddThatToTheLastDayInTheSameMonthPreviousYear()
        {
            var someBirthday = new DateTime(2012, 2, 29, 17, 0, 0, 0);
            var previousYear = someBirthday.PreviousYear();
            Assert.AreEqual(new DateTime(2011, 3, 1, 17, 0, 0, 0), previousYear);
        }

        [Test]
        public void Next_ReturnsNextFridayProperly()
        {
            var friday = new DateTime(2009, 7, 10, 1, 0, 0, 0);
            var reallyNextFriday = new DateTime(2009, 7, 17, 1, 0, 0, 0);
            var nextFriday = friday.Next(DayOfWeek.Friday);

            Assert.AreEqual(reallyNextFriday, nextFriday);
        }

        [Test]
        public void Next_ReturnsPreviousFridayProperly()
        {
            var friday = new DateTime(2009, 7, 17, 1, 0, 0, 0);
            var reallyPrevFriday = new DateTime(2009, 7, 10, 1, 0, 0, 0);
            var prevFriday = friday.Previous(DayOfWeek.Friday);

            Assert.AreEqual(reallyPrevFriday, prevFriday);
        }

        [Test]
        public void IsBefore_ReturnsTrueForGivenDateThatIsInTheFuture()
        {
            // arrange
            var toCompareWith = DateTime.Today + 1.Days();

            // assert
            Assert.IsTrue(DateTime.Today.IsBefore(toCompareWith));
        }

        [Test]
        public void IsBefore_ReturnsFalseForGivenDateThatIsSame()
        {
            // arrange
            var toCompareWith = DateTime.Today;

            // assert
            Assert.IsFalse(toCompareWith.IsBefore(toCompareWith));
        }

        [Test]
        public void IsAfter_ReturnsTrueForGivenDateThatIsInThePast()
        {
            // arrange
            var toCompareWith = DateTime.Today - 1.Days();

            // assert
            Assert.IsTrue(DateTime.Today.IsAfter(toCompareWith));
        }

        [Test]
        public void IsAfter_ReturnsFalseForGivenDateThatIsSame()
        {
            // arrange
            var toCompareWith = DateTime.Today;

            // assert
            Assert.IsFalse(toCompareWith.IsAfter(toCompareWith));
        }

        [Test]
        public void At_SetsHourAndMinutesProperly()
        {
            Assert.AreEqual(new DateTime(2002, 12, 17, 18, 06, 01), new DateTime(2002, 12, 17, 17, 05, 01).At(18, 06));
        }

        [Test]
        public void At_SetsHourAndMinutesAndSecondsProperly()
        {
            Assert.AreEqual(new DateTime(2002, 12, 17, 18, 06, 02), new DateTime(2002, 12, 17, 17, 05, 01).At(18, 06, 02));
        }

        [Test]
        public void At_SetsHourAndMinutesAndMillisecondsProperly()
        {
            Assert.AreEqual(new DateTime(2002, 12, 17, 18, 06, 02,03), new DateTime(2002, 12, 17, 17, 05, 01).At(18, 06, 02,03));
        }


        [Test]
        public void FirstDayOfMonth_SetsTheDayToOne()
        {
            Assert.AreEqual(new DateTime(2002, 12, 1, 17, 05, 01), new DateTime(2002, 12, 17, 17, 05, 01).FirstDayOfMonth());
        }

        [Test]
        public void LastDayOfMonth_SetsTheDayToLastDayInThatMonth()
        {
            Assert.AreEqual(new DateTime(2002, 1, 31, 17, 05, 01), new DateTime(2002, 1, 1, 17, 05, 01).LastDayOfMonth());
        }

        [Test]
        public void AddBusinessDays_AdsDaysProperlyWhenThereIsWeekendAhead()
        {
            Assert.AreEqual(new DateTime(2009, 7, 13), new DateTime(2009, 7, 9).AddBusinessDays(2));
        }
        [Test]
        public void AddBusinessDays_Negative()
        {
            Assert.AreEqual(new DateTime(2009, 7, 9), new DateTime(2009, 7, 13).AddBusinessDays(-2));
        }

        [Test]
        public void SubtractBusinessDays_SubtractsDaysProperlyWhenThereIsWeekend()
        {
            Assert.AreEqual(new DateTime(2009, 7, 9), new DateTime(2009, 7, 13).SubtractBusinessDays(2));
        }
        [Test]
        public void SubtractBusinessDays_Negative()
        {
            Assert.AreEqual(new DateTime(2009, 7, 13), new DateTime(2009, 7, 9).SubtractBusinessDays(-2));
        }

        [Test]
        public void IsInFuture()
        {
            var now = DateTime.Now;
            Assert.IsFalse(now.Subtract(2.Seconds()).IsInFuture());
            Assert.IsFalse(now.IsInFuture());
            Assert.IsTrue(now.Add(2.Seconds()).IsInFuture());
        }

        [Test]
        public void IsInPast()
        {
            var now = DateTime.Now;
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
            var currentCulture = new CultureInfo("en-AU");
            currentCulture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;
            Thread.CurrentThread.CurrentCulture = currentCulture;
            Assert.AreEqual(new DateTime(2011, 1, 24), new DateTime(2011, 1, value).FirstDayOfWeek());
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
            var currentCulture = new CultureInfo("en-AU");
            currentCulture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Sunday;
            Thread.CurrentThread.CurrentCulture = currentCulture;
            Assert.AreEqual(new DateTime(2011, 1, 23), new DateTime(2011, 1, value).FirstDayOfWeek());
            Thread.CurrentThread.CurrentCulture = ci;
        }

        [Test]
        [TestCase("2011-06-22T06:40:20.005")]
        [TestCase("2011-12-31T06:40:20.005")]
        [TestCase("2011-01-01T06:40:20.005")]
        public void FirstDayOfYear_BasicTest(string value)
        {
            Assert.AreEqual(new DateTime(2011,1,1,6,40,20,5),DateTime.Parse(value).FirstDayOfYear());
        }

        [Test]
        [TestCase("2011-12-24T06:40:20.005")]
        [TestCase("2011-12-19T06:40:20.005")]
        [TestCase("2011-12-25T06:40:20.005")]
        public void LastDayOfWeek_BasicTest(string value)
        {
            var ci = Thread.CurrentThread.CurrentCulture;
            var currentCulture = new CultureInfo("en-AU");
            currentCulture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;
            Thread.CurrentThread.CurrentCulture = currentCulture;
            Assert.AreEqual(new DateTime(2011, 12, 25, 06, 40, 20, 5), DateTime.Parse(value).LastDayOfWeek());
            Thread.CurrentThread.CurrentCulture = ci;
        }

        [Test]
        [TestCase("2011-02-13T06:40:20.005")]
        [TestCase("2011-01-01T06:40:20.005")]
        [TestCase("2011-12-31T06:40:20.005")]
        public void LastDayOfYear_BasicTest(string value)
        {
            Assert.AreEqual(new DateTime(2011, 12, 31, 06, 40, 20, 5), DateTime.Parse(value).LastDayOfYear());
        }

        [Test]
        public void PreviousMonth_BasicTest()
        {
            Assert.AreEqual(new DateTime(2009, 12, 20, 06, 40, 20, 5), new DateTime(2010, 1, 20, 06, 40, 20, 5).PreviousMonth());

        }

        [Test]
        public void PreviousMonth_PreviousMonthDoesntHaveThatManyDays()
        {
            Assert.AreEqual(new DateTime(2009, 2, 28, 06, 40, 20, 5), new DateTime(2009, 3, 31, 06, 40, 20, 5).PreviousMonth());
        }


        [Test]
        public void NextMonth_BasicTest()
        {
            Assert.AreEqual(new DateTime(2013, 1, 5, 06, 40, 20, 5), new DateTime(2012, 12, 5, 06, 40, 20, 5).NextMonth());
        }       
        
        [Test]
        public void PreviousMonth_NextMonthDoesntHaveThatManyDays()
        {
            Assert.AreEqual(new DateTime(2013, 2, 28, 06, 40, 20, 5), new DateTime(2013, 1, 31, 06, 40, 20, 5).NextMonth());
        }
    }




}
