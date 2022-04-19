namespace FluentDate;

public static class IntExtensions
{
    /// <summary>
    /// Returns the specified day in January of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 31).
    /// </param>
    public static FluentDate January(this int year, int day) => new(year, 1, day);

    /// <summary>
    /// Returns the specified day in January of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 31).
    /// </param>
    public static FluentDate Jan(this int year, int day) => year.January(day);

    /// <summary>
    /// Returns the specified day in February of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 28 in a common year, and 29 in leap years).
    /// </param>
    public static FluentDate February(this int year, int day) => new(year, 2, day);

    /// <summary>
    /// Returns the specified day in February of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 28 in a common year, and 29 in leap years).
    /// </param>
    public static FluentDate Feb(this int year, int day) => year.February(day);

    /// <summary>
    /// Returns the specified day in March of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 31).
    /// </param>
    public static FluentDate March(this int year, int day) => new(year, 3, day);

    /// <summary>
    /// Returns the specified day in March of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 31).
    /// </param>
    public static FluentDate Mar(this int year, int day) => year.March(day);

    /// <summary>
    /// Returns the specified day in April of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 30).
    /// </param>
    public static FluentDate April(this int year, int day) => new(year, 4, day);

    /// <summary>
    /// Returns the specified day in April of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 30).
    /// </param>
    public static FluentDate Apr(this int year, int day) => year.April(day);

    /// <summary>
    /// Returns the specified day in May of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 31).
    /// </param>
    public static FluentDate May(this int year, int day) => new(year, 5, day);

    /// <summary>
    /// Returns the specified day in June of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 30).
    /// </param>
    public static FluentDate June(this int year, int day) => new(year, 6, day);

    /// <summary>
    /// Returns the specified day in June of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 30).
    /// </param>
    public static FluentDate Jun(this int year, int day) => year.June(day);

    /// <summary>
    /// Returns the specified day in July of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 31).
    /// </param>
    public static FluentDate July(this int year, int day) => new(year, 7, day);

    /// <summary>
    /// Returns the specified day in July of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 31).
    /// </param>
    public static FluentDate Jul(this int year, int day) => year.July(day);

    /// <summary>
    /// Returns the specified day in August of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 31).
    /// </param>
    public static FluentDate August(this int year, int day) => new(year, 8, day);

    /// <summary>
    /// Returns the specified day in August of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 31).
    /// </param>
    public static FluentDate Aug(this int year, int day) => year.August(day);

    /// <summary>
    /// Returns the specified day in September of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 30).
    /// </param>
    public static FluentDate September(this int year, int day) => new(year, 9, day);

    /// <summary>
    /// Returns the specified day in September of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 30).
    /// </param>
    public static FluentDate Sep(this int year, int day) => year.September(day);

    /// <summary>
    /// Returns the specified day in October of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 31).
    /// </param>
    public static FluentDate October(this int year, int day) => new(year, 10, day);

    /// <summary>
    /// Returns the specified day in October of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 31).
    /// </param>
    public static FluentDate Oct(this int year, int day) => year.October(day);

    /// <summary>
    /// Returns the specified day in November of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 30).
    /// </param>
    public static FluentDate November(this int year, int day) => new(year, 11, day);

    /// <summary>
    /// Returns the specified day in November of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 30).
    /// </param>
    public static FluentDate Nov(this int year, int day) => year.November(day);

    /// <summary>
    /// Returns the specified day in December of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 31).
    /// </param>
    public static FluentDate December(this int year, int day) => new(year, 12, day);

    /// <summary>
    /// Returns the specified day in December of the year the method is called for.
    /// </summary>
    /// <param name="year">
    /// The year (1 through 9999).
    /// </param>
    /// <param name="day">
    /// The day (1 through 31).
    /// </param>
    public static FluentDate Dec(this int year, int day) => year.December(day);
}