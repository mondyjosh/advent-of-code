namespace AdventOfCode.Tests.Year2015;

using AdventOfCode.Common;
using AdventOfCode.Year2015;

[Trait("Year", "2015")]
[Trait("Day", "03")]
public class Year2015Day03SolutionTests
{
    public Year2015Day03SolutionTests()
    {
        _solution = new Year2015Day03Solution();
    }

    [Theory]
    [MemberData(nameof(GetPart1DemoInputs))]
    public void SolvePart1_WithMemberData_OutputExpectedHouseCount(string input, int expected)
    {
        var actual = _solution.SolvePart1(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(GetPart2DemoInputs))]
    public void SolvePart2_WithMemberData_OutputExpectedHouseCount(string input, int expected)
    {
        var actual = _solution.SolvePart2(input);

        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> GetPart1DemoInputs()
    {
        yield return new object[] { ">", 2 };
        yield return new object[] { "^>v<", 4 };
        yield return new object[] { "^v^v^v^v^v", 2 };
    }

        public static IEnumerable<object[]> GetPart2DemoInputs()
    {
        yield return new object[] { "^v", 3 };
        yield return new object[] { "^>v<", 3 };
        yield return new object[] { "^v^v^v^v^v", 11 };
    }

    private readonly ISolution _solution;
}
