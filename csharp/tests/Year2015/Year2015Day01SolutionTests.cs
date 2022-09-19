namespace AdventOfCode.Tests.Year2015;

using AdventOfCode.Common;
using AdventOfCode.Year2015;

[Trait("Year", "2015")]
[Trait("Day", "01")]
public class Year2015Day01SolutionTests
{
    public Year2015Day01SolutionTests()
    {
        _solution = new Year2015Day01Solution();
    }

    [Theory]
    [MemberData(nameof(GetFloors))]
    public void SolvePart1_WithMemberData_OutputExpectedFloor(string input, int expected)
    {        
        var actual = _solution.SolvePart1(input);        

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(GetBasementEntryCharacterPosition))]
    public void SolvePart2_WithMemberData_OutputExpectedBasementEntryCharacterPosition(string input, int expected)
    {
        var actual = _solution.SolvePart2(input);

        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> GetFloors()
    {
        yield return new object[] { "(())", 0 };
        yield return new object[] { "()()", 0 };
        yield return new object[] { "(((", 3 };
        yield return new object[] { "(()(()(", 3 };
        yield return new object[] { "))(((((", 3 };
        yield return new object[] { "())", -1 };
        yield return new object[] { "))(", -1 };
        yield return new object[] { ")))", -3 };
        yield return new object[] { ")())())", -3 };
    }

    public static IEnumerable<object[]> GetBasementEntryCharacterPosition()
    {
        yield return new object[] { ")", 1 };
        yield return new object[] { "()())", 5 };
    }

    private readonly ISolution _solution;
}
