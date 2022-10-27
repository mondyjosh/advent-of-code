namespace AdventOfCode.Year2015.Day05;

using System.Text.RegularExpressions;

class Part2NiceStrategy : INiceStrategy
{
    public bool IsNice(string input) =>
        HasLetterPairThatAppearsTwice(input) &&
        HasLetterThatRepeatsWithCharInterruption(input);

    private bool HasLetterPairThatAppearsTwice(string input) =>
        Regex.IsMatch(input, @"([a-z][a-z]).*\1", RegexOptions.Compiled & RegexOptions.IgnoreCase);  

    private bool HasLetterThatRepeatsWithCharInterruption(string input) =>
        Regex.IsMatch(input, @"([a-z])[a-z]\1", RegexOptions.Compiled & RegexOptions.IgnoreCase);   
}