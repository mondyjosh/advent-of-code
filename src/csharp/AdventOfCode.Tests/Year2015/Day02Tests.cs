namespace AdventOfCode.Tests.Year2015;

using AdventOfCode.Year2015;

public class Day02SolutionTests
{
    public Day02SolutionTests()
    {
        _solution = new Day02Solution();
    }

    [Theory]
    [MemberData(nameof(GetDimensions))]
    public void SolvePart1_WithMemberData_OutputExpectedArea(string input, int expected)
    {        
        var actual = _solution.SolvePart1(input);
        
        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> GetDimensions()
    {
        yield return new object[] { "2x3x4", 52 };
        yield return new object[] { "1x1x10", 42 };
    }

    private readonly SolutionBase _solution;
}
