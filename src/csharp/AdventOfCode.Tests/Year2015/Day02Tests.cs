namespace AdventOfCode.Tests.Year2015;

using AdventOfCode.Year2015;

public class Day02SolutionTests
{
    public Day02SolutionTests()
    {
        _solution = new Day02Solution();
    }

    [Theory]
    [MemberData(nameof(GetWrappingPaperDimensions))]
    public void SolvePart1_WithMemberData_OutputExpectedTotalArea(string input, int expected)
    {        
        var actual = _solution.SolvePart1(input);

        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> GetWrappingPaperDimensions()
    {
        yield return new object[] { "2x3x4", 58 };
        yield return new object[] { "1x1x10", 43 };
        yield return new object[] { "2x3x4\n2x3x4", 116 };
        yield return new object[] { "1x1x10\n1x1x10", 86 };
    }

    private readonly SolutionBase _solution;
}
