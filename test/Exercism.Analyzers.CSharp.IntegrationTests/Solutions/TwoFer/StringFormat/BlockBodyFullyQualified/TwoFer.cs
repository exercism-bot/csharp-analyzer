public static class TwoFer
{
    public static string Name(string input = null)
    {
        return System.String.Format("One for {0}, one for me.", input ?? "you");
    }
}