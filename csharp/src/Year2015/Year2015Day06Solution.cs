namespace AdventOfCode.Year2015;

using System.Linq;

using Year2015.Day06;

class Year2015Day06Solution : ISolution
{
    public int SolvePart1(string input) => GetLightingInputValue(input, new Part1LightStrategy());

    public int SolvePart2(string input) => GetLightingInputValue(input, new Part2LightStrategy());

    private int GetLightingInputValue(string input, ILightStrategy strategy)
    {        
        var lightGrid = new LightCoordinates[1000, 1000];

        return strategy.ProcessInstructions(lightGrid, input);
    }
}
