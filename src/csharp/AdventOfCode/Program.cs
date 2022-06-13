// TODO: Implement snazzy System.CommandLine package for argument handling.
using static AdventOfCode.Year2015.Day01.Solution;

Console.WriteLine("Helping Santa...");

var input = SolutionBase.LoadInput();
var part1Solution = SolvePart1(input);
var part2Solution = SolvePart2(input);

Console.WriteLine($"Part 1 solution: {part1Solution}");
Console.WriteLine($"Part 2 solution: {part2Solution}");
