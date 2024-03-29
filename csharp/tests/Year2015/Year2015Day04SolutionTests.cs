namespace AdventOfCode.Tests.Year2015;

using AdventOfCode.Common;
using AdventOfCode.Year2015;

[Trait("Year", "2015")]
[Trait("Day", "04")]
public class Year2015Day04SolutionTests
{
    public Year2015Day04SolutionTests()
    {
        _solution = new Year2015Day04Solution();
    }

    [Theory]
    [MemberData(nameof(GetPart1DemoInputs))]
    public void SolvePart1_WithMemberData_OutputExpectedZeroHashIndex(string input, int expected)
    {
        var actual = _solution.SolvePart1(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(GetPart2DemoInputs))]
    public void SolvePart2_WithMemberData_OutputExpectedZeroHashIndex(string input, int expected)
    {
        var actual = _solution.SolvePart2(input);

        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> GetPart1DemoInputs()
    {
        yield return new object[] { "abcdef", 609043 };
        yield return new object[] { "pqrstuv", 1048970 };
    }

    public static IEnumerable<object[]> GetPart2DemoInputs()
    {
        yield return new object[] { "abcdef", 6742839 };
        yield return new object[] { "pqrstuv",  5714438 };
    }

    private readonly ISolution _solution;
}
