namespace AdventOfCode.Year2015;

using System.Text.RegularExpressions;

class Year2015Day05Solution : ISolution
{
    public int SolvePart1(string input) => GetNiceStringCount(input);

    public int SolvePart2(string input) => GetNiceStringCount(input);

    private static int GetNiceStringCount(string input)
    {
        var inputs = input.SplitByNewline();
        var niceStringCount = 0;

        foreach (var eval in inputs)
        {
            // TODO: IsNice Strategy?
            if (IsNice(eval))
                niceStringCount++;
        }

        return niceStringCount;
    }

    private static bool IsNice(string input) =>
        HasNiceVowelCount(input) &&
        HasRepeatedLetter(input) &&
        DoesNotContainNaughtySubstrings(input);

    private static bool IsNiceRevised(string input) => throw new NotImplementedException();

    private static bool HasNiceVowelCount(string input) =>
        input.Count(i => Vowels.Contains(i, StringComparison.OrdinalIgnoreCase)) >= niceStringCount;

    private static bool HasRepeatedLetter(string input) => _matchRepeatedLetter.IsMatch(input);

    private static bool DoesNotContainNaughtySubstrings(string input) =>
        !_naughtySubstrings.Any(substring => input.Contains(substring, StringComparison.OrdinalIgnoreCase));

    private const int niceStringCount = 3;
    private const string Vowels = "aeiou";

    private static string[] _naughtySubstrings = new string[]
    {
        "ab",
        "cd",
        "pq",
        "xy"
    };

    private static Regex _matchRepeatedLetter = new Regex(@"(.)\1", RegexOptions.Compiled);
}
