using System;
using System.Linq;

public static class ResistorColor
{
    public static string[] ColorList = { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };
    
    public static int ColorCode(string color)
    {
        return Array.IndexOf(ColorList, color);
    }

    public static string[] Colors()
    {
        return ColorList;
    }
}