using FluentDate;
using Xunit;

public class FluentDateTests
{
    static Dictionary<int, Func<int, int, FluentDate.FluentDate>> fluentDatesFull = new()
    {
        [1] = (year, day) => year.January(day),
        [2] = (year, day) => year.February(day),
        [3] = (year, day) => year.March(day),
        [4] = (year, day) => year.April(day),
        [5] = (year, day) => year.May(day),
        [6] = (year, day) => year.June(day),
        [7] = (year, day) => year.July(day),
        [8] = (year, day) => year.August(day),
        [9] = (year, day) => year.September(day),
        [10] = (year, day) => year.October(day),
        [11] = (year, day) => year.November(day),
        [12] = (year, day) => year.December(day)
    };

    static Dictionary<int, Func<int, int, FluentDate.FluentDate>> fluentDatesShort = new()
    {
        [1] = (year, day) => year.Jan(day),
        [2] = (year, day) => year.Feb(day),
        [3] = (year, day) => year.Mar(day),
        [4] = (year, day) => year.Apr(day),
        [5] = (year, day) => year.May(day),
        [6] = (year, day) => year.Jun(day),
        [7] = (year, day) => year.Jul(day),
        [8] = (year, day) => year.Aug(day),
        [9] = (year, day) => year.Sep(day),
        [10] = (year, day) => year.Oct(day),
        [11] = (year, day) => year.Nov(day),
        [12] = (year, day) => year.Dec(day)
    };

    public static IEnumerable<object[]> FluentDates => fluentDatesFull.Concat(fluentDatesShort).Select(x => new object[]
    {
        x.Key,
        x.Value
    });

    [Theory]
    [MemberData(nameof(FluentDates))]
    public void Dates(int month, Func<int, int, FluentDate.FluentDate> getFluentDate)
    {
        var date = GetRandomDateTimeOfMonth(month).DateTime;
        var fluentDate = getFluentDate(date.Year, date.Day);

        DateAssert.Equal(date.Date, fluentDate, "Implicit unequal");
        DateAssert.Equal(date.Date, fluentDate.DateTime, "Explicit unequal");

        DateAssert.Equal(DateTime.SpecifyKind(date.Date, DateTimeKind.Local), fluentDate.Local, "Local unequal");
        DateAssert.Equal(DateTime.SpecifyKind(date.Date, DateTimeKind.Utc), fluentDate.Utc, "UTC unequal");

#if NET6_0_OR_GREATER
        Assert.Equal(DateOnly.FromDateTime(date), fluentDate.Date);
#endif
    }

    [Theory]
    [MemberData(nameof(FluentDates))]
    public void DateAt(int month, Func<int, int, FluentDate.FluentDate> getFluentDate)
    {
        var date = GetRandomDateTimeOfMonth(month).DateTime;
        var fluentDate = getFluentDate(date.Year, date.Day);

        DateAssert.Equal(
            date,
            fluentDate.At(date.Hour, date.Minute, date.Second, date.Millisecond),
            "Unspecified unequal");

        DateAssert.Equal(
            DateTime.SpecifyKind(date, DateTimeKind.Local),
            fluentDate.AtLocal(date.Hour, date.Minute, date.Second, date.Millisecond),
            "Local unequal");

        DateAssert.Equal(
            DateTime.SpecifyKind(date, DateTimeKind.Utc),
            fluentDate.AtUtc(date.Hour, date.Minute, date.Second, date.Millisecond),
            "UTC unequal");
    }

    [Theory]
    [MemberData(nameof(FluentDates))]
    public void DateAtWithKind(int month, Func<int, int, FluentDate.FluentDate> getFluentDate)
    {
        var date = GetRandomDateTimeOfMonth(month).DateTime;
        var fluentDate = getFluentDate(date.Year, date.Day);

        DateAssert.Equal(
            date,
            fluentDate.At(DateTimeKind.Unspecified, date.Hour, date.Minute, date.Second, date.Millisecond),
            "Unspecified unequal");

        DateAssert.Equal(
            DateTime.SpecifyKind(date, DateTimeKind.Local),
            fluentDate.At(DateTimeKind.Local, date.Hour, date.Minute, date.Second, date.Millisecond),
            "Local unequal");

        DateAssert.Equal(
            DateTime.SpecifyKind(date, DateTimeKind.Utc),
            fluentDate.At(DateTimeKind.Utc, date.Hour, date.Minute, date.Second, date.Millisecond),
            "UTC unequal");
    }

    [Theory]
    [MemberData(nameof(FluentDates))]
    public void DateAtTimeZone(int month, Func<int, int, FluentDate.FluentDate> getFluentDate)
    {
        var date = GetRandomDateTimeOfMonth(month);
        var fluentDate = getFluentDate(date.Year, date.Day);

        Assert.Equal(date, fluentDate.At(date.Offset, date.Hour, date.Minute, date.Second, date.Millisecond));
    }

    DateTimeOffset GetRandomDateTimeOfMonth(int month)
    {
        Random random = new();

        var year = random.Next(1, 10000);
        return new(
            year,
            month,
            random.Next(1, DateTime.DaysInMonth(year, month) + 1),
            random.Next(0, 24),
            random.Next(0, 60),
            random.Next(0, 60),
            random.Next(0, 1000),
            TimeSpan.FromMinutes(random.Next((int) -12.Hours().TotalMinutes, (int) 14.Hours().TotalMinutes + 1))
        );
    }
}