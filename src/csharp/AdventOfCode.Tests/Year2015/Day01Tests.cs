namespace AdventOfCode.Tests.Year2015;

using static AdventOfCode.Year2015.Day01.Solution;

public class Day01Tests
{
    [Theory]
    [MemberData(nameof(GetFloors))]
    public void Solve_WithMemberData_ArriveAtExpectedFloor(string input, int expected)
    {
        var actual = Solve(input);

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
}