using Xunit;

public class DateAssert
{
    public static void Equal(DateTime expected, DateTime actual, string message)
    {
        Assert.True(actual == expected && actual.Kind == expected.Kind, message);
    }

    public static void Equal(DateTime expected, DateTime actual)
    {
        Assert.True(actual == expected && actual.Kind == expected.Kind);
    }
}