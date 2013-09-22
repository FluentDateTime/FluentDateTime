using System;
using System.Globalization;
using FluentDate;
using FluentDateTime;
using NUnit.Framework;
using System.Threading;

namespace FluentDateTimeTests
{
    [TestFixture]
    public class DateTimeTests
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
            var originalPointInTime = new DateTime(1976, 12, 31, 17, 0, 0, 0, DateTimeKind.Local);

            DateAssert.AreEqual(agoValue.Years().Before(originalPointInTime), originalPointInTime.AddYears(-agoValue));
            DateAssert.AreEqual(agoValue.Months().Before(originalPointInTime), originalPointInTime.AddMonths(-agoValue));
            DateAssert.AreEqual(agoValue.Weeks().Before(originalPointInTime), originalPointInTime.AddDays(-agoValue * DAYS_PER_WEEK));
            DateAssert.AreEqual(agoValue.Days().Before(originalPointInTime), originalPointInTime.AddDays(-agoValue));

            DateAssert.AreEqual(agoValue.Hours().Before(originalPointInTime), originalPointInTime.AddHours(-agoValue));
            DateAssert.AreEqual(agoValue.Minutes().Before(originalPointInTime), originalPointInTime.AddMinutes(-agoValue));
            DateAssert.AreEqual(agoValue.Seconds().Before(originalPointInTime), originalPointInTime.AddSeconds(-agoValue));
            DateAssert.AreEqual(agoValue.Milliseconds().Before(originalPointInTime), originalPointInTime.AddMilliseconds(-agoValue));
            DateAssert.AreEqual(agoValue.Ticks().Before(originalPointInTime), originalPointInTime.AddTicks(-agoValue));
        }
        [Test]
        public void Ago_FromOneMonth()
        {
            var originalPointInTime = new DateTime(1976, 4, 30,0,0,0,DateTimeKind.Local);

            DateAssert.AreEqual(1.Months().Before(originalPointInTime), new DateTime(1976, 3, 30, 0, 0, 0, DateTimeKind.Local));
            DateAssert.AreEqual(1.Months().From(originalPointInTime), new DateTime(1976, 5, 30, 0, 0, 0, DateTimeKind.Local));
        }

        [Test]
        public void Ago_FromOneYearLeap()
        {
            var originalPointInTime = new DateTime(2004, 2, 29,0,0,0,DateTimeKind.Local);

            DateAssert.AreEqual(1.Years().Before(originalPointInTime), new DateTime(2003, 2, 28, 0, 0, 0, DateTimeKind.Local));
            DateAssert.AreEqual(1.Years().From(originalPointInTime), new DateTime(2005, 2, 28, 0, 0, 0, DateTimeKind.Local));
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
            var originalPointInTime = new DateTime(1976, 12, 31, 17, 0, 0, 0, DateTimeKind.Local);

            DateAssert.AreEqual(value.Years().From(originalPointInTime), originalPointInTime.AddYears(value));
            DateAssert.AreEqual(value.Months().From(originalPointInTime), originalPointInTime.AddMonths(value));
            DateAssert.AreEqual(value.Weeks().From(originalPointInTime), originalPointInTime.AddDays(value * DAYS_PER_WEEK));
            DateAssert.AreEqual(value.Days().From(originalPointInTime), originalPointInTime.AddDays(value));

            DateAssert.AreEqual(value.Hours().From(originalPointInTime), originalPointInTime.AddHours(value));
            DateAssert.AreEqual(value.Minutes().From(originalPointInTime), originalPointInTime.AddMinutes(value));
            DateAssert.AreEqual(value.Seconds().From(originalPointInTime), originalPointInTime.AddSeconds(value));
            DateAssert.AreEqual(value.Milliseconds().From(originalPointInTime), originalPointInTime.AddMilliseconds(value));
            DateAssert.AreEqual(value.Ticks().From(originalPointInTime), originalPointInTime.AddTicks(value));
        }



        [Test]
        [TestCase(24, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(-1, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(23)]
        public void ChangeTime_Hour_SimpleTests(int value)
        {
            var toChange = new DateTime(2008, 10, 25, 0, 0, 0, 0, DateTimeKind.Local);

            var result = toChange.SetTime(value);
            var expected = new DateTime(2008, 10, 25, value, 0, 0, 0, DateTimeKind.Local);

            DateAssert.AreEqual(expected, result);
        }


        [Test]
        [TestCase(0)]
        [TestCase(16)]
        [TestCase(59)]
        [TestCase(-1, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(60, ExpectedException = typeof(ArgumentOutOfRangeException))]
        public void ChangeTime_Minute_SimpleTests(int value)
        {
            var toChange = new DateTime(2008, 10, 25, 0, 0, 0, 0, DateTimeKind.Local);

            var expected = new DateTime(2008, 10, 25, 0, value, 0, 0, DateTimeKind.Local);
            DateAssert.AreEqual(expected, toChange.SetTime(0, value));
        }

        [Test]
        [TestCase(0)]
        [TestCase(16)]
        [TestCase(59)]
        [TestCase(-1, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(60, ExpectedException = typeof(ArgumentOutOfRangeException))]
        public void ChangeTime_Second_SimpleTests(int value)
        {
            var toChange = new DateTime(2008, 10, 25, 0, 0, 0, 0, DateTimeKind.Local);

            var changed = toChange.SetTime(0, 0, value);

            var expected = new DateTime(2008, 10, 25, 0, 0, value, 0, DateTimeKind.Local);

            DateAssert.AreEqual(expected, changed);
        }

        [Test]
        [TestCase(0)]
        [TestCase(100)]
        [TestCase(999)]
        [TestCase(-1, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(1000, ExpectedException = typeof(ArgumentOutOfRangeException))]
        public void ChangeTime_Millisecond_SimpleTests(int value)
        {
            var toChange = new DateTime(2008, 10, 25, 0, 0, 0, 0, DateTimeKind.Local);

            var expected = new DateTime(2008, 10, 25, 0, 0, 0, value, DateTimeKind.Local);
            DateAssert.AreEqual(expected, toChange.SetTime(0, 0, 0, value));
        }

        [Test]
        public void BasicTests()
        {
            var now = DateTime.Now;
            DateAssert.AreEqual(new DateTime(now.Year, now.Month, now.Day, 23, 59, 59, 999, DateTimeKind.Local), DateTime.Now.EndOfDay(), " End of the day wrong");
            DateAssert.AreEqual(new DateTime(now.Year, now.Month, now.Day, 0, 0, 0, 0, DateTimeKind.Local), DateTime.Now.BeginningOfDay(), "Start of the day wrong");

            var firstBirthDay = new DateTime(1977, 12, 31, 17, 0, 0, 0, DateTimeKind.Local);
            DateAssert.AreEqual(firstBirthDay + new TimeSpan(1, 0, 5, 0, 0), firstBirthDay + 1.Days() + 5.Minutes());

            DateAssert.AreEqual(now + TimeSpan.FromDays(1), now.NextDay());
            DateAssert.AreEqual(now - TimeSpan.FromDays(1), now.PreviousDay());

            DateAssert.AreEqual(now + TimeSpan.FromDays(7), now.WeekAfter());
            DateAssert.AreEqual(now - TimeSpan.FromDays(7), now.WeekEarlier());

            Assert.AreEqual(new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2008, 12, 31, 0, 0, 0, DateTimeKind.Local).Add(1.Days()));
            Assert.AreEqual(new DateTime(2009, 1, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Local).Add(1.Days()));

            var sampleDate = new DateTime(2009, 1, 1, 13, 0, 0, 0, DateTimeKind.Local);
            DateAssert.AreEqual(new DateTime(2009, 1, 1, 12, 0, 0, 0, DateTimeKind.Local), sampleDate.Noon());
            DateAssert.AreEqual(new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Local), sampleDate.Midnight());

            Assert.AreEqual(3.Days() + 3.Days(), 6.Days());
            Assert.AreEqual(102.Days() - 3.Days(), 99.Days());

            Assert.AreEqual(24.Hours(), 1.Days());

            sampleDate = new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
            DateAssert.AreEqual(3.Days().Since(sampleDate), sampleDate + 3.Days());

            var saturday = new DateTime(2008, 10, 25, 12, 0, 0, DateTimeKind.Local);
            DateAssert.AreEqual(new DateTime(2008, 11, 1, 12, 0, 0, DateTimeKind.Local), saturday.Next(DayOfWeek.Saturday));

            DateAssert.AreEqual(new DateTime(2008, 10, 18, 12, 0, 0, DateTimeKind.Local), saturday.Previous(DayOfWeek.Saturday));

            // ReSharper disable UnusedVariable
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

            // ReSharper restore UnusedVariable
        }

        [Test]
        public void NextYear_ReturnsTheSameDateButNextYear()
        {
            var birthday = new DateTime(1976, 12, 31, 17, 0, 0, 0, DateTimeKind.Local);
            var nextYear = birthday.NextYear();
            var expected = new DateTime(1977, 12, 31, 17, 0, 0, 0, DateTimeKind.Local);
            DateAssert.AreEqual(expected, nextYear);
        }

        [Test]
        public void PreviousYear_ReturnsTheSameDateButPreviousYear()
        {
            var birthday = new DateTime(1976, 12, 31, 17, 0, 0, 0, DateTimeKind.Local);
            var previousYear = birthday.PreviousYear();
            var expected = new DateTime(1975, 12, 31, 17, 0, 0, 0, DateTimeKind.Local);
            DateAssert.AreEqual(expected, previousYear);
        }


        [Test]
        public void NextYear_IfNextYearDoesNotHaveTheSameDayInTheSameMonthThenCalculateHowManyDaysIsMissingAndAddThatToTheLastDayInTheSameMonthNextYear()
        {
            var someBirthday = new DateTime(2008, 2, 29, 17, 0, 0, 0, DateTimeKind.Local);
            var nextYear = someBirthday.NextYear();
            var expected = new DateTime(2009, 3, 1, 17, 0, 0, 0, DateTimeKind.Local);
            DateAssert.AreEqual(expected, nextYear);
        }

        [Test]
        public void PreviousYear_IfPreviousYearDoesNotHaveTheSameDayInTheSameMonthThenCalculateHowManyDaysIsMissingAndAddThatToTheLastDayInTheSameMonthPreviousYear()
        {
            var someBirthday = new DateTime(2012, 2, 29, 17, 0, 0, 0, DateTimeKind.Local);
            var previousYear = someBirthday.PreviousYear();
            var expected = new DateTime(2011, 3, 1, 17, 0, 0, 0, DateTimeKind.Local);
            DateAssert.AreEqual(expected, previousYear);
        }

        [Test]
        public void Next_ReturnsNextFridayProperly()
        {
            var friday = new DateTime(2009, 7, 10, 1, 0, 0, 0, DateTimeKind.Local);
            var reallyNextFriday = new DateTime(2009, 7, 17, 1, 0, 0, 0, DateTimeKind.Local);
            var nextFriday = friday.Next(DayOfWeek.Friday);

            DateAssert.AreEqual(reallyNextFriday, nextFriday);
        }

        [Test]
        public void Next_ReturnsPreviousFridayProperly()
        {
            var friday = new DateTime(2009, 7, 17, 1, 0, 0, 0, DateTimeKind.Local);
            var reallyPrevFriday = new DateTime(2009, 7, 10, 1, 0, 0, 0, DateTimeKind.Local);
            var prevFriday = friday.Previous(DayOfWeek.Friday);

            DateAssert.AreEqual(reallyPrevFriday, prevFriday);
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
            var expected = new DateTime(2002, 12, 17, 18, 06, 01, DateTimeKind.Local);
            DateAssert.AreEqual(expected, new DateTime(2002, 12, 17, 17, 05, 01, DateTimeKind.Local).At(18, 06));
        }

        [Test]
        public void At_SetsHourAndMinutesAndSecondsProperly()
        {
            var expected = new DateTime(2002, 12, 17, 18, 06, 02, DateTimeKind.Local);
            DateAssert.AreEqual(expected, new DateTime(2002, 12, 17, 17, 05, 01, DateTimeKind.Local).At(18, 06, 02));
        }

        [Test]
        public void At_SetsHourAndMinutesAndMillisecondsProperly()
        {
            var expected = new DateTime(2002, 12, 17, 18, 06, 02, 03, DateTimeKind.Local);
            DateAssert.AreEqual(expected, new DateTime(2002, 12, 17, 17, 05, 01, DateTimeKind.Local).At(18, 06, 02, 03));
        }


        [Test]
        public void FirstDayOfMonth_SetsTheDayToOne()
        {
            var expected = new DateTime(2002, 12, 1, 17, 05, 01, DateTimeKind.Local);
            DateAssert.AreEqual(expected, new DateTime(2002, 12, 17, 17, 05, 01, DateTimeKind.Local).FirstDayOfMonth());
        }

        [Test]
        public void LastDayOfMonth_SetsTheDayToLastDayInThatMonth()
        {
            var expected = new DateTime(2002, 1, 31, 17, 05, 01, DateTimeKind.Local);
            DateAssert.AreEqual(expected, new DateTime(2002, 1, 1, 17, 05, 01, DateTimeKind.Local).LastDayOfMonth());
        }

        [Test]
        public void AddBusinessDays_AdsDaysProperlyWhenThereIsWeekendAhead()
        {
            var expected = new DateTime(2009, 7, 13, 0, 0, 0, DateTimeKind.Local);
            DateAssert.AreEqual(expected, new DateTime(2009, 7, 9, 0, 0, 0, DateTimeKind.Local).AddBusinessDays(2));
        }

        [Test]
        public void AddBusinessDays_Negative()
        {
            var expected = new DateTime(2009, 7, 9, 0, 0, 0, DateTimeKind.Local);
            DateAssert.AreEqual(expected, new DateTime(2009, 7, 13, 0, 0, 0, DateTimeKind.Local).AddBusinessDays(-2));
        }

        [Test]
        public void SubtractBusinessDays_SubtractsDaysProperlyWhenThereIsWeekend()
        {
            var expected = new DateTime(2009, 7, 9, 0, 0, 0, DateTimeKind.Local);
            DateAssert.AreEqual(expected, new DateTime(2009, 7, 13, 0, 0, 0, DateTimeKind.Local).SubtractBusinessDays(2));
        }

        [Test]
        public void SubtractBusinessDays_Negative()
        {
            var expected = new DateTime(2009, 7, 13, 0, 0, 0, DateTimeKind.Local);
            DateAssert.AreEqual(expected, new DateTime(2009, 7, 9, 0, 0, 0, DateTimeKind.Local).SubtractBusinessDays(-2));
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
            var currentCulture = new CultureInfo("en-AU")
                {
                    DateTimeFormat =
                        {
                            FirstDayOfWeek = DayOfWeek.Monday
                        }
                };
            Thread.CurrentThread.CurrentCulture = currentCulture;
            var expected = new DateTime(2011, 1, 24, 0, 0, 0, DateTimeKind.Local);
            DateAssert.AreEqual(expected, new DateTime(2011, 1, value, 0, 0, 0, DateTimeKind.Local).FirstDayOfWeek());
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
            var expected = new DateTime(2011, 1, 23, 0, 0, 0, DateTimeKind.Local);
            DateAssert.AreEqual(expected, new DateTime(2011, 1, value, 0, 0, 0, DateTimeKind.Local).FirstDayOfWeek());
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
            var currentCulture = new CultureInfo("en-AU")
                {
                    DateTimeFormat =
                        {
                            FirstDayOfWeek = DayOfWeek.Monday
                        }
                };
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
            var expected = new DateTime(2009, 12, 20, 06, 40, 20, 5, DateTimeKind.Local);
            DateAssert.AreEqual(expected, new DateTime(2010, 1, 20, 06, 40, 20, 5, DateTimeKind.Local).PreviousMonth());
        }

        [Test]
        public void PreviousMonth_PreviousMonthDoesntHaveThatManyDays()
        {
            var expected = new DateTime(2009, 2, 28, 06, 40, 20, 5, DateTimeKind.Local);
            DateAssert.AreEqual(expected, new DateTime(2009, 3, 31, 06, 40, 20, 5, DateTimeKind.Local).PreviousMonth());
        }


        [Test]
        public void NextMonth_BasicTest()
        {
            var expected = new DateTime(2013, 1, 5, 06, 40, 20, 5, DateTimeKind.Local);
            DateAssert.AreEqual(expected, new DateTime(2012, 12, 5, 06, 40, 20, 5, DateTimeKind.Local).NextMonth());
        }

        [Test]
        public void PreviousMonth_NextMonthDoesntHaveThatManyDays()
        {
            var expected = new DateTime(2013, 2, 28, 06, 40, 20, 5, DateTimeKind.Local);
            DateAssert.AreEqual(expected, new DateTime(2013, 1, 31, 06, 40, 20, 5, DateTimeKind.Local).NextMonth());
        }
    }




}
