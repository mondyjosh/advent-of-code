namespace AdventOfCode.Tests.Year2015;

using AdventOfCode.Common;
using AdventOfCode.Year2015;

public class Day02SolutionTests
{
    public Day02SolutionTests()
    {
        _solution = new Year2015Day02();
    }

    [Theory]
    [MemberData(nameof(GetWrappingPaperDimensions))]
    public void SolvePart1_WithMemberData_OutputExpectedTotalArea(string input, int expected)
    {
        var actual = _solution.SolvePart1(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(GetRibbonLengths))]
    public void SolvePart2_WithMemberData_OutputExpectedTotalLength(string input, int expected)
    {
        var actual = _solution.SolvePart2(input);

        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> GetWrappingPaperDimensions()
    {
        yield return new object[] { "2x3x4", 58 };
        yield return new object[] { "1x1x10", 43 };
        yield return new object[] { "2x3x4\n2x3x4", 116 };
        yield return new object[] { "1x1x10\n1x1x10", 86 };
    }

    public static IEnumerable<object[]> GetRibbonLengths()
    {
        yield return new object[] { "2x3x4", 34 };
        yield return new object[] { "1x1x10", 14 };
        yield return new object[] { "2x3x4\n2x3x4", 68 };
        yield return new object[] { "1x1x10\n1x1x10", 28 };
    }

    private readonly ISolution _solution;
}
