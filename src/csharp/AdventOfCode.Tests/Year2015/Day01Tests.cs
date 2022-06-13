namespace AdventOfCode.Tests.Year2015;

using static AdventOfCode.Year2015.Day01.Solution;

public class Day01Tests
{
    [Theory]
    [MemberData(nameof(GetFloors))]
    public void SolvePart1_WithMemberData_OutputExpectedFloor(string input, int expected)
    {
        var actual = SolvePart1(input);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(GetBasementEntryCharacterPosition))]
    public void SolvePart2_WithMemberData_OutputExpectedBasementEntryCharacterPosition(string input, int expected)
    {
        var actual = SolvePart2(input);

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
}
