using System;
    
public static class TwoFer
{
    public static string Name(string input = null)
    {
        return "One for " + (input ?? "you") + ", one for me.";
    }
}