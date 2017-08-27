using System;
using NUnit.Framework;


public class DateAssert
{
    public static void AreEqual(DateTime expected, DateTime actual, string message)
    {
        Assert.That(actual == expected && actual.Kind == expected.Kind, Is.True, message, null);
    }

    public static void AreEqual(DateTime expected, DateTime actual)
    {
        AreEqual(expected, actual, null);
    }
}