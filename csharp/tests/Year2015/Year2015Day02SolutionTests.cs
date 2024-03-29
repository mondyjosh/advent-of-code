namespace AdventOfCode.Tests.Year2015;

using AdventOfCode.Common;
using AdventOfCode.Year2015;

[Trait("Year", "2015")]
[Trait("Day", "02")]
public class Year2015Day02SolutionTests
{
    public Year2015Day02SolutionTests()
    {
        _solution = new Year2015Day02Solution();
    }

    [Theory]
    [MemberData(nameof(GetPart1DemoInputs))]
    public void SolvePart1_WithMemberData_OutputExpectedTotalArea(string input, int expected)
    {
        var actual = _solution.SolvePart1(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(GetPart2DemoInputs))]
    public void SolvePart2_WithMemberData_OutputExpectedTotalLength(string input, int expected)
    {
        var actual = _solution.SolvePart2(input);

        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> GetPart1DemoInputs()
    {
        yield return new object[] { "2x3x4", 58 };
        yield return new object[] { "1x1x10", 43 };
        yield return new object[] { "2x3x4\n2x3x4", 116 };
        yield return new object[] { "1x1x10\n1x1x10", 86 };
    }

    public static IEnumerable<object[]> GetPart2DemoInputs()
    {
        yield return new object[] { "2x3x4", 34 };
        yield return new object[] { "1x1x10", 14 };
        yield return new object[] { "2x3x4\n2x3x4", 68 };
        yield return new object[] { "1x1x10\n1x1x10", 28 };
    }

    private readonly ISolution _solution;
}
