using System;

public static class TwoFer
{
    public static string Speak(string input = null)
    {

        input = input == null ? "you" : input;
        return $"One for {input}, one for me.";
    }
}