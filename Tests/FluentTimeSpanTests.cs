using System;
using FluentDate;
using FluentDateTime;
using NUnit.Framework;

[TestFixture]
public class FluentTimeSpanTests
{

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
        Assert.AreEqual(value.Years(), new FluentTimeSpan
        {
            Years = value
        });
        Assert.AreEqual(value.Months(), new FluentTimeSpan
        {
            Months = value
        });
        Assert.AreEqual(value.Weeks(), new FluentTimeSpan
        {
            TimeSpan = TimeSpan.FromDays(value*7)
        });
        Assert.AreEqual(value.Days(), new FluentTimeSpan
        {
            TimeSpan = TimeSpan.FromDays(value)
        });

        Assert.AreEqual(value.Hours(), new FluentTimeSpan
        {
            TimeSpan = TimeSpan.FromHours(value)
        });
        Assert.AreEqual(value.Minutes(), new FluentTimeSpan
        {
            TimeSpan = TimeSpan.FromMinutes(value)
        });
        Assert.AreEqual(value.Seconds(), new FluentTimeSpan
        {
            TimeSpan = TimeSpan.FromSeconds(value)
        });
        Assert.AreEqual(value.Milliseconds(), new FluentTimeSpan
        {
            TimeSpan = TimeSpan.FromMilliseconds(value)
        });
        Assert.AreEqual(value.Ticks(), new FluentTimeSpan
        {
            TimeSpan = TimeSpan.FromTicks(value)
        });
    }

    [Test]
    public void Subtract()
    {
        Assert.AreEqual(3, 3.5.Days().Subtract(.5.Days()).Days);
    }

    [Test]
    public void GetHashCodeTest()
    {
        Assert.AreEqual(343024320, 3.5.Days().GetHashCode());
    }

    [Test]
    public void CompareToFluentTimeSpan()
    {
        Assert.AreEqual(0, 3.Days().CompareTo(3.Days()));
        Assert.AreEqual(-1, 3.Days().CompareTo(4.Days()));
        Assert.AreEqual(1, 4.Days().CompareTo(3.Days()));
    }

    [Test]
    public void CompareToTimeSpan()
    {
        Assert.AreEqual(0, 3.Days().CompareTo(TimeSpan.FromDays(3)));
        Assert.AreEqual(-1, 3.Days().CompareTo(TimeSpan.FromDays(4)));
        Assert.AreEqual(1, 4.Days().CompareTo(TimeSpan.FromDays(3)));
    }

    [Test]
    public void CompareToObject()
    {
        Assert.AreEqual(0, 3.Days().CompareTo((object) TimeSpan.FromDays(3)));
        Assert.AreEqual(-1, 3.Days().CompareTo((object) TimeSpan.FromDays(4)));
        Assert.AreEqual(1, 4.Days().CompareTo((object) TimeSpan.FromDays(3)));
    }

    [Test]
    public void EqualsFluentTimeSpan()
    {
        Assert.IsTrue(3.Days().Equals(3.Days()));
        Assert.IsFalse(4.Days().Equals(3.Days()));
    }

    [Test]
    public void EqualsTimeSpan()
    {
        Assert.IsTrue(3.Days().Equals(TimeSpan.FromDays(3)));
        Assert.IsFalse(4.Days().Equals(TimeSpan.FromDays(3)));
    }

    [Test]
    public void Equals()
    {
        Assert.IsFalse(3.Days().Equals(null));
    }

    [Test]
    public void EqualsTimeSpanAsObject()
    {
        Assert.IsTrue(3.Days().Equals((object) TimeSpan.FromDays(3)));
    }

    [Test]
    public void EqualsObject()
    {
        Assert.IsFalse(3.Days().Equals(1));
    }

    [Test]
    public void Add()
    {
        Assert.AreEqual(4, 3.5.Days().Add(.5.Days()).Days);
    }

    [Test]
    public void ToStringTest()
    {
        Assert.AreEqual("3.12:00:00", 3.5.Days().ToString());
    }

    [Test]
    public void Clone()
    {
        var timeSpan = 3.Milliseconds();
        var clone = timeSpan.Clone();
        Assert.AreNotSame(timeSpan, clone);
        Assert.AreEqual(timeSpan, clone);
    }

    [Test]
    public void Ticks()
    {
        Assert.AreEqual(30000, 3.Milliseconds().Ticks);
    }

    [Test]
    public void Milliseconds()
    {
        Assert.AreEqual(100, 1100.Milliseconds().Milliseconds);
    }

    [Test]
    public void TotalMilliseconds()
    {
        Assert.AreEqual(1100, 1100.Milliseconds().TotalMilliseconds);
    }

    [Test]
    public void Seconds()
    {
        Assert.AreEqual(1, 61.Seconds().Seconds);
    }

    [Test]
    public void TotalSeconds()
    {
        Assert.AreEqual(61, 61.Seconds().TotalSeconds);
    }

    [Test]
    public void Minutes()
    {
        Assert.AreEqual(1, 61.Minutes().Minutes);
    }

    [Test]
    public void TotalMinutes()
    {
        Assert.AreEqual(61, 61.Minutes().TotalMinutes);
    }

    [Test]
    public void Hours()
    {
        Assert.AreEqual(1, 25.Hours().Hours);
    }

    [Test]
    public void TotalHours()
    {
        Assert.AreEqual(25, 25.Hours().TotalHours);
    }

    [Test]
    public void Days()
    {
        Assert.AreEqual(366, 366.Days().Days);
    }

    [Test]
    public void TotalDays()
    {
        Assert.AreEqual(366, 366.Days().TotalDays);
    }

    [Test]
    public void Years()
    {
        var fluentTimeSpan = 3.Years();
        Assert.AreEqual(3, fluentTimeSpan.Years);
    }

    [Test]
    public void EnsureWhenConvertedIsCorrect()
    {
        TimeSpan timeSpan = 10.Years();
        Assert.AreEqual(3650d, timeSpan.TotalDays);
    }

    [TestFixture]
    public class OperatorOverloads
    {
        [Test]
        public void LessThan()
        {
            Assert.IsTrue(1.Seconds() < 2.Seconds());
            Assert.IsTrue(1.Seconds() < TimeSpan.FromSeconds(2));
            Assert.IsTrue(TimeSpan.FromSeconds(1) < 2.Seconds());
        }

        [Test]
        public void LessThanOrEqualTo()
        {
            Assert.IsTrue(1.Seconds() <= 2.Seconds());
            Assert.IsTrue(1.Seconds() <= TimeSpan.FromSeconds(2));
            Assert.IsTrue(TimeSpan.FromSeconds(1) <= 2.Seconds());
        }

        [Test]
        public void GreaterThan()
        {
            Assert.IsTrue(2.Seconds() > 1.Seconds());
            Assert.IsTrue(2.Seconds() > TimeSpan.FromSeconds(1));
            Assert.IsTrue(TimeSpan.FromSeconds(2) > 1.Seconds());
        }

        [Test]
        public void GreaterThanOrEqualTo()
        {
            Assert.IsTrue(2.Seconds() >= 1.Seconds());
            Assert.IsTrue(2.Seconds() >= TimeSpan.FromSeconds(1));
            Assert.IsTrue(TimeSpan.FromSeconds(2) >= 1.Seconds());
        }

        [Test]
        public void Equals()
        {
            Assert.IsTrue(2.Seconds() == 2.Seconds());
            Assert.IsTrue(2.Seconds() == TimeSpan.FromSeconds(2));
            Assert.IsTrue(TimeSpan.FromSeconds(2) == 2.Seconds());
        }

        [Test]
        public void NotEquals()
        {
            Assert.IsTrue(2.Seconds() != 1.Seconds());
            Assert.IsTrue(2.Seconds() != TimeSpan.FromSeconds(1));
            Assert.IsTrue(TimeSpan.FromSeconds(2) != 1.Seconds());
        }

        [Test]
        public void Add()
        {
            Assert.AreEqual(1.Seconds() + 2.Seconds(), 3.Seconds());
            Assert.AreEqual(1.Seconds() + TimeSpan.FromSeconds(2), 3.Seconds());
            Assert.AreEqual(TimeSpan.FromSeconds(1) + 2.Seconds(), 3.Seconds());
        }

        [Test]
        public void Subtract()
        {
            Assert.AreEqual(1.Seconds() - 2.Seconds(), -1.Seconds());
            Assert.AreEqual(1.Seconds() - TimeSpan.FromSeconds(2), -1.Seconds());
            Assert.AreEqual(TimeSpan.FromSeconds(1) - 2.Seconds(), -1.Seconds());
        }
    }

    [TestFixture]
    public class ToDisplayStringTests
    {

        [Test]
        public void DaysHours()
        {
            var timeSpan = 2.Days() + 3.Hours();
            var displayString = timeSpan.ToDisplayString();
            Assert.AreEqual("2 days and 3 hours", displayString);
        }

        [Test]
        public void DaysHoursRoundUp()
        {
            var timeSpan = 2.Days() + 3.Hours() + 30.Minutes();
            var displayString = timeSpan.ToDisplayString();
            Assert.AreEqual("2 days and 4 hours", displayString);
        }

        [Test]
        public void DaysHoursRoundDown()
        {
            var timeSpan = 2.Days() + 3.Hours() + 9.Minutes();
            var displayString = timeSpan.ToDisplayString();
            Assert.AreEqual("2 days and 3 hours", displayString);
        }

        [Test]
        public void HoursMinutes()
        {
            var timeSpan = 2.Hours() + 9.Minutes();
            var displayString = timeSpan.ToDisplayString();
            Assert.AreEqual("2 hours and 9 minutes", displayString);
        }

        [Test]
        public void HoursMinutesRoundUp()
        {
            var timeSpan = 2.Hours() + 9.Minutes() + 30.Seconds();
            var displayString = timeSpan.ToDisplayString();
            Assert.AreEqual("2 hours and 10 minutes", displayString);
        }

        [Test]
        public void HoursMinutesRoundDown()
        {
            var timeSpan = 2.Hours() + 9.Minutes() + 10.Seconds();
            var displayString = timeSpan.ToDisplayString();
            Assert.AreEqual("2 hours and 9 minutes", displayString);
        }

        [Test]
        public void MinutesSeconds()
        {
            var timeSpan = 9.Minutes();
            var displayString = timeSpan.ToDisplayString();
            Assert.AreEqual("9 minutes and 0 seconds", displayString);
        }

        [Test]
        public void MinutesSecondsRoundUp()
        {
            var timeSpan = 9.Minutes() + 30.5.Seconds();
            var displayString = timeSpan.ToDisplayString();
            Assert.AreEqual("9 minutes and 31 seconds", displayString);
        }

        [Test]
        public void MinutesSecondsRoundDown()
        {
            var timeSpan = 9.Minutes() + 30.4.Seconds();
            var displayString = timeSpan.ToDisplayString();
            Assert.AreEqual("9 minutes and 30 seconds", displayString);
        }

        [Test]
        public void SecondsMilliseconds()
        {
            var timeSpan = 9.Seconds();
            var displayString = timeSpan.ToDisplayString();
            Assert.AreEqual("9 seconds", displayString);
        }

        [Test]
        public void SecondsMillisecondsRoundUp()
        {
            var timeSpan = 9.Seconds() + 500.Milliseconds();
            var displayString = timeSpan.ToDisplayString();
            Assert.AreEqual(9.5 + " seconds", displayString);
        }

        [Test]
        public void SecondsMillisecondsRoundDown()
        {
            var timeSpan = 9.Seconds() + 300.Milliseconds();
            var displayString = timeSpan.ToDisplayString();
            Assert.AreEqual(9.3 + " seconds", displayString);
        }

        [Test]
        public void Milliseconds()
        {
            var timeSpan = 9.Milliseconds();
            var displayString = timeSpan.ToDisplayString();
            Assert.AreEqual("9 milliseconds", displayString);
        }

        [Test]
        public void ABitOverADay()
        {
            var timeSpan = 46.2.Hours();
            var displayString = timeSpan.ToDisplayString();
            Assert.AreEqual("1 days and 22 hours", displayString);
        }

        [Test]
        public void ABitOverADay2()
        {
            var timeSpan = 46.9.Hours();
            var displayString = timeSpan.ToDisplayString();
            Assert.AreEqual("1 days and 23 hours", displayString);
        }



    }
}