namespace AdventOfCode.Year2015;

class Day03Solution : ISolution
{
    public int SolvePart1(string input) => GetSantaHousesVisited(input);

    public int SolvePart2(string input) => GetSantaPlusRoboSantaHousesVisited(input);

    private static int GetSantaHousesVisited(string input)
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
            currentLocation = ProcessDirection(currentLocation, direction);

            locationsVisited.Add(currentLocation);
        }

        return locationsVisited.Distinct().Count();
    }



    private static int GetSantaPlusRoboSantaHousesVisited(string input)
    {
        var directions = input.ToCharArray();

        // initialize with starting coordinates and present delivered
        var santaCurrentLocation = new Coordinates(0, 0);
        var roboSantaCurrentLocation = new Coordinates(0, 0);

        var santaLocationsVisited = new List<Coordinates>
        {
            santaCurrentLocation
        };

        var roboSantaLocationsVisited = new List<Coordinates>
        {
            roboSantaCurrentLocation
        };

        var directionIndex = 0;

        foreach (var direction in directions)
        {
            if (directionIndex % 2 == 0)
            {
                santaCurrentLocation = ProcessDirection(santaCurrentLocation, direction);
                santaLocationsVisited.Add(santaCurrentLocation);
            }
            else
            {
                roboSantaCurrentLocation = ProcessDirection(roboSantaCurrentLocation, direction);
                roboSantaLocationsVisited.Add(roboSantaCurrentLocation);
            }

            directionIndex++;
        }

        return santaLocationsVisited.Union(roboSantaLocationsVisited).Distinct().Count();
    }

    private static Coordinates ProcessDirection(Coordinates currentLocation, char direction)
    {
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

        return currentLocation;
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
