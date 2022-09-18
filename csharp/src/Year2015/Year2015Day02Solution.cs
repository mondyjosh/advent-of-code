namespace AdventOfCode.Year2015;

using System.Linq;

class Year2015Day02 : ISolution
{
    public int SolvePart1(string input) => CalculateTotalWrappingPaperArea(input);

    public int SolvePart2(string input) => CalculateTotalRibbonLength(input);

    private int CalculateTotalWrappingPaperArea(string input)
    {
        var presentDimensionSets = ExtractDimensions(input);
        var totalArea = 0;

        foreach (var presentDimensions in presentDimensionSets)
            totalArea += CalculateWrappingPaperTotal(presentDimensions);

        return totalArea;
    }

    private int CalculateTotalRibbonLength(string input)
    {
        var presentDimensionSets = ExtractDimensions(input);
        var totalLength = 0;

        foreach (var presentDimensions in presentDimensionSets)
            totalLength += CalculateRibbonTotal(presentDimensions);

        return totalLength;
    }

    private int CalculateWrappingPaperTotal(int[] dimensions)
    {
        var smallestSides = GetSmallestDimensions(dimensions, 2);

        var paperWrapArea = CalculateRightRectangularPrismArea(dimensions[0], dimensions[1], dimensions[2]);
        var paperSlackArea = CalculateArea(smallestSides[0], smallestSides[1]);

        return paperWrapArea + paperSlackArea;
    }

    private int CalculateRibbonTotal(int[] dimensions)
    {
        var smallestSides = GetSmallestDimensions(dimensions, 2);

        var wrapLength = CalculateRectanglePerimeter(smallestSides[0], smallestSides[1]);
        var bowLength = CalculateCubicArea(dimensions[0], dimensions[1], dimensions[2]);

        return wrapLength + bowLength;
    }

    private static IEnumerable<int[]> ExtractDimensions(string input) =>
        input.SplitByNewline()
            .Select(input => input.Split("x"))
            .Select(dimension => Array.ConvertAll(dimension, int.Parse));

    private static int[] GetSmallestDimensions(int[] dimensions, int count) =>
        dimensions.OrderBy(d => d).Take(count).ToArray();

    private static int CalculateRightRectangularPrismArea(int length, int width, int height) =>
        (2 * length * width) + (2 * width * height) + (2 * height * length);

    private static int CalculateArea(int length, int width) => length * width;

    private static int CalculateCubicArea(int length, int width, int height) => length * width * height;

    private static int CalculateRectanglePerimeter(int length, int width) => 2 * length + 2 * width;
}
