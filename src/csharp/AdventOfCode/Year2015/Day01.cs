namespace AdventOfCode.Year2015.Day01;

static class Solution
{
    public static int Solve(string input) => GetFloor(input);

    private static int GetFloor(string input)
    {
        var upCount = input.Count(f => f == s_UpSymbol);
        var downCount = input.Count(f => f == s_DownSymbol);

        return upCount - downCount;
    }

    private static char s_UpSymbol = '(';
    private static char s_DownSymbol = ')';
}
