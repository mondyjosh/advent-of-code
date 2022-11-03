namespace AdventOfCode.Year2015.Day03;

public struct Coordinates
{
    public Coordinates(int x = 0, int y = 0)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }
}
