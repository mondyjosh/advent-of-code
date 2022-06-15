namespace AdventOfCode.Year2015;

using System.Linq;

class Day02Solution : SolutionBase
{
    public override int SolvePart1(string input) => CalculateRightRectangularPrism(input);

    public override int SolvePart2(string input) => 2;

    private int CalculateRightRectangularPrism(string input)
    {
        var totalSquareFeet = 0;
        var inputArray = input.SplitByNewline();

        var dimensionsArray = inputArray
            .Select(input => input.Split("x"))
            .Select(dimension => Array.ConvertAll(dimension, int.Parse));        

        foreach (var dimensionSet in dimensionsArray)
        {
            totalSquareFeet += CalculatePresentWrappingPaperTotal(dimensionSet);
        }

        return totalSquareFeet;
    }

    private int CalculatePresentWrappingPaperTotal(int[] dimensions)
    {        
        var smallestSide = dimensions.OrderBy(d => d).Take(2).ToArray();

        var area = CalculateRightRectangularPrismArea(dimensions[0], dimensions[1], dimensions[2]);
        var slack = CalculateArea(smallestSide[0], smallestSide[1]);

        return area + slack;
    }

    private int CalculateRightRectangularPrismArea(int length, int width, int height) =>
        (2 * length * width) + (2 * width * height) + (2 * height * length);

    private int CalculateArea(int length, int width) => length * width;
}
