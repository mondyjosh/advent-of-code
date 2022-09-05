namespace AdventOfCode.Common;

public static class StringExtensions
{
    public static string[] SplitByNewline(this string input) => input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
}