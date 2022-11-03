using System.Text.RegularExpressions;

namespace AdventOfCode.Year2015.Day06;

public struct LightCoordinates
{
    public LightCoordinates(int x = 0, int y = 0, bool isLit = false)
    {
        X = x;
        Y = y;
        IsLit = isLit;
    }

    public LightCoordinates(string coordinates, bool isLit = false)
    {
        var match = Regex.Match(
            coordinates, 
            @"^([\d]+),([\d]+)$", 
            RegexOptions.Compiled & RegexOptions.IgnoreCase);

        X = int.Parse(match.Groups[1].Value);
        Y = int.Parse(match.Groups[2].Value);
        IsLit = isLit;
    }

    public int X { get; set; }
    public int Y { get; set; }
    public bool IsLit { get; set; }
}
