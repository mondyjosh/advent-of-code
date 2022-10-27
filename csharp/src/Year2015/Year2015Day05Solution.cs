namespace AdventOfCode.Year2015;

using AdventOfCode.Year2015.Day05;

class Year2015Day05Solution : ISolution
{
    public int SolvePart1(string input) => GetNiceStringCount(input, new Part1NiceStrategy());

    public int SolvePart2(string input) => GetNiceStringCount(input, new Part2NiceStrategy());

    private static int GetNiceStringCount(string input, INiceStrategy strategy) =>
        input.SplitByNewline().Count(input => strategy.IsNice(input));
}
