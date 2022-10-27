namespace AdventOfCode.Year2015.Day05;

using System.Text.RegularExpressions;

class Part1NiceStrategy : INiceStrategy
{
    public bool IsNice(string input) =>
        HasNiceVowelCount(input, 3) &&
        HasRepeatedLetter(input) &&
        DoesNotContainNaughtySubstrings(input);

    private static bool IsNiceRevised(string input) => throw new NotImplementedException();

    private static bool HasNiceVowelCount(string input, int niceStringCount) =>
        input.Count(i => "aeiou".Contains(i, StringComparison.OrdinalIgnoreCase)) >= niceStringCount;

    private static bool HasRepeatedLetter(string input) => 
        Regex.IsMatch(input, @"(.)\1", RegexOptions.Compiled & RegexOptions.IgnoreCase);

    private static bool DoesNotContainNaughtySubstrings(string input) =>
        !_naughtySubstrings.Any(substring => input.Contains(substring, StringComparison.OrdinalIgnoreCase));

    private static string[] _naughtySubstrings = new string[]
    {
        "ab",
        "cd",
        "pq",
        "xy"
    };
}
