using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode.Year2015;

class Day03Solution : SolutionBase
{
    public override int SolvePart1(string input) => GetTotalHousesVisited(input);

    public override int SolvePart2(string input) => 2;

    private static int GetTotalHousesVisited(string input)
    {
        var directions = input.ToCharArray();

        // initialize with starting coordinates and present delivered
        var currentLocation = new Coordinates(0, 0);

        var locationsVisited = new List<Coordinates>
        {
            currentLocation
        };

        foreach (var direction in directions)
        {
            // eval direction - nsew?
            switch (direction)
            {
                case North:
                    currentLocation.Y++;
                    break;

                case South:
                    currentLocation.Y--;
                    break;

                case East:
                    currentLocation.X++;
                    break;

                case West:
                    currentLocation.X--;
                    break;
            }

            locationsVisited.Add(currentLocation);
        }

        return locationsVisited.Distinct().Count();
    }

    const char North = '^';
    const char South = 'v';
    const char East = '>';
    const char West = '<';
}

struct Coordinates
{
    public Coordinates(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }
}
