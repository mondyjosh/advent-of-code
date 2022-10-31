namespace AdventOfCode.Year2015.Common;

public struct LightCoordinates
{
    public LightCoordinates(int x = 0, int y = 0, bool isLit = false)
    {
        X = x;
        Y = y;
        IsLit = false;
    }

    public int X { get; set; }
    public int Y { get; set; }
    bool IsLit { get; set; }
}