namespace AdventOfCode.Year2015.Day06;

public interface ILightStrategy
{
    public int ProcessInstructions(LightCoordinates[,] lightGrid, string instruction);
}
