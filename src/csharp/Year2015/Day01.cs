namespace AdventOfCode.Year2015.Day01;

using Microsoft.Extensions.Configuration;

// TODO: Implement SolutionBase
static class Solution
{
    public static void Solve()
    {
        // TODO: Solve.
        // TODO: Build unit tests based off of demo inputs.
        Console.WriteLine($"Puzzle input: {LoadInput()}");
    }

    // TODO: Move to SolutionBase
    static string LoadInput()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        // TODO: Assemble full path dynamically based on year/day (maybe part?)
        var inputPath = config.GetValue<string>("InputPath");
        var fullpath = $"{inputPath}/2015/day01.txt";

        using (var streamReader = new StreamReader(fullpath))
            return streamReader.ReadToEnd();
    }
}
