namespace AdventOfCode.Tests.Year2015;

using AdventOfCode.Common;
using AdventOfCode.Year2015;

[Trait("Year", "2015")]
[Trait("Day", "06")]
public class Year2015Day06SolutionTests
{
    public Year2015Day06SolutionTests()
    {
        _solution = new Year2015Day06Solution();
    }

    [Theory]
    [MemberData(nameof(GetPart1DemoInputs))]
    public void SolvePart1_WithMemberData_OutputExpectedNiceCount(string input, int expected)
    {
        var actual = _solution.SolvePart1(input);

        Assert.Equal(expected, actual);
    }

    // [Theory]
    // [MemberData(nameof(GetPart2DemoInputs))]
    // public void SolvePart2_WithMemberData_OutputExpectedNiceCount(string input, int expected)
    // {
    //     var actual = _solution.SolvePart2(input);

    //     Assert.Equal(expected, actual);
    // }

    public static IEnumerable<object[]> GetPart1DemoInputs()
    {
        yield return new object[] { "turn on 0,0 through 999,999", 1000000 };
        yield return new object[] { "toggle 0,0 through 999,0", 1000 };
        yield return new object[] { "turn off 499,499 through 500,500", 100 };
    }

    // public static IEnumerable<object[]> GetPart2DemoInputs()
    // {
        // yield return new object[] { "turn on 0,0 through 999,999", "???" };
        // yield return new object[] { "toggle 0,0 through 999,0", "???" };
        // yield return new object[] { "turn off 499,499 through 500,500", "???" };
    // }

    private readonly ISolution _solution;
}
