namespace AdventOfCode.Tests.Year2015;

using AdventOfCode.Common;
using AdventOfCode.Year2015;

[Trait("Year", "2015")]
[Trait("Day", "05")]
public class Year2015Day05SolutionTests
{
    public Year2015Day05SolutionTests()
    {
        _solution = new Year2015Day05Solution();
    }

    [Theory]
    [MemberData(nameof(GetPart1DemoInputs))]
    public void SolvePart1_WithMemberData_OutputExpectedNiceCount(string input, int expected)
    {
        var actual = _solution.SolvePart1(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(GetPart2DemoInputs))]
    public void SolvePart2_WithMemberData_OutputExpectedNiceCount(string input, int expected)
    {
        var actual = _solution.SolvePart2(input);

        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> GetPart1DemoInputs()
    {
        yield return new object[] { "ugknbfddgicrmopn", 1 };
        yield return new object[] { "aaa", 1 };
        yield return new object[] { "jchzalrnumimnmhp", 0 };
        yield return new object[] { "haegwjzuvuyypxyu", 0 };
        yield return new object[] { "dvszwmarrgswjxmb", 0 };
    }

    public static IEnumerable<object[]> GetPart2DemoInputs()
    {
        yield return new object[] { "qjhvhtzxzqqjkmpb", 1 };
        yield return new object[] { "xxyxx", 1 };
        yield return new object[] { "uurcxstgmygtbstg", 0 };
        yield return new object[] { "ieodomkazucvgmuy", 0 };
    }

    private readonly ISolution _solution;
}
