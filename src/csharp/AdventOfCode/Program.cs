// TODO: Implement snazzy System.CommandLine package for argument handling.

using AdventOfCode.Year2015;

Console.WriteLine("Helping Santa...");

var input = SolutionBase.LoadInput(2015, 02);

if (input.Length > 0)
{
    var solution = new Day01Solution();
    var part1Solution = solution.SolvePart1(input);
    var part2Solution = solution.SolvePart2(input);

    Console.WriteLine($"Part 1 solution: {part1Solution}");
    Console.WriteLine($"Part 2 solution: {part2Solution}");
}
else {
    Console.WriteLine("Hurry and save Christmas!");
}
