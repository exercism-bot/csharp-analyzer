using System;
using System.Linq;

public static class ResistorColor
{
    public static readonly string[] ColorList = { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };
    
    public static int ColorCode(string color) => Array.IndexOf(ColorList, color);

    public static string[] Colors() => ColorList;
}