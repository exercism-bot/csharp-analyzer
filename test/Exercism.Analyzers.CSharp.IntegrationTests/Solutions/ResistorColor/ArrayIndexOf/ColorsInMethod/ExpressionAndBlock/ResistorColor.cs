using System;
using System.Linq;

public static class ResistorColor
{
    public static int ColorCode(string color)
    {
        return Array.IndexOf(Colors(), color);
    }

    public static string[] Colors()
        => new[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };
}