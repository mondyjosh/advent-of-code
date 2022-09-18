namespace AdventOfCode.Year2015;

class Year20115Day01Solution : ISolution
{
    public int SolvePart1(string input) => GetFloor(input);

    public int SolvePart2(string input) => GetBasementEntryCharacterPosition(input);

    private static int GetFloor(string input)
    {        
        var upCount = input.Count(input => input == UpSymbol);
        var downCount = input.Count(input => input == DownSymbol);

        return upCount - downCount;
    }
    
    private static int GetBasementEntryCharacterPosition(string input)
    {
        var floor = GroundFloor;
        var index = 0;

        foreach (var instruction in input.ToCharArray())
        {
            index++;

            if (instruction.Equals(UpSymbol))
                floor++;
            else
                floor--;

            if (floor < GroundFloor) 
                break;
        }

        return index;
    }

    private const char UpSymbol = '(';
    private const char DownSymbol = ')';
    private const int GroundFloor = 0;
}
