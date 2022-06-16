namespace AdventOfCode.Tests.Year2015;

using AdventOfCode.Year2015;

public class Day03SolutionTests
{
    public Day03SolutionTests()
    {
        _solution = new Day03Solution();
    }

    [Theory]
    [MemberData(nameof(GetSantaDirections))]
    public void SolvePart1_WithMemberData_OutputExpectedHouseCount(string input, int expected)
    {
        var actual = _solution.SolvePart1(input);

        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> GetSantaDirections()
    {
        yield return new object[] { ">", 2 };
        yield return new object[] { "^>v<", 4 };
        yield return new object[] { "^v^v^v^v^v", 2 };
    }

    private readonly SolutionBase _solution;
}
