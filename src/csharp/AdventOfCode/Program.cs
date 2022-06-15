// TODO: Implement snazzy System.CommandLine package for argument handling.

using AdventOfCode.Year2015;


int.TryParse(args[0], out int year);
int.TryParse(args[1], out int day);

Console.WriteLine($"Helping Santa on {year}.12.{day}...\r\n");

var input = SolutionBase.LoadInput(year, day);

if (input.Length > 0)
{
    // TODO: Dependency injection based on year-day input combo (named instances)
    var solution = new Day01Solution();
    var part1Solution = solution.SolvePart1(input);
    var part2Solution = solution.SolvePart2(input);

    Console.WriteLine($"Part 1 solution: {part1Solution}");
    Console.WriteLine($"Part 2 solution: {part2Solution}");
}
else {
    Console.WriteLine("\r\nNo input detected. Hurry and save Christmas!");
}
