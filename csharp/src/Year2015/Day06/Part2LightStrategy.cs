namespace AdventOfCode.Year2015.Day06;

using System.Text.RegularExpressions;

class Part2LightStrategy : ILightStrategy
{
    public int ProcessInstructions(LightCoordinates[,] lightGrid, string input)
    {
        var instructions = input.SplitByNewline();

        foreach (var instruction in instructions)
            ProcessInstruction(lightGrid, instruction);

        return lightGrid.Cast<LightCoordinates>().Sum(light => light.Brightness);
    }

    private void ProcessInstruction(LightCoordinates[,] lightGrid, string instruction)
    {
        var lightInstruction = ParseInstruction(instruction);

        for (int x = lightInstruction.EndpointAlpha.X; x < lightGrid.GetLength(0) && x <= lightInstruction.EndpointBeta.X; x++)
        {
            for (int y = lightInstruction.EndpointAlpha.Y; y < lightGrid.GetLength(1) && y <= lightInstruction.EndpointBeta.Y; y++)
            {
                switch (lightInstruction.Action)
                {
                    case LightActions.DecreaseBrightnessByOne:
                        DecreaseBrightnessByOne(lightGrid, x, y);
                        break;
                    case LightActions.IncreaseBrightnessByOne:
                        IncreaseBrightnessByOne(lightGrid, x, y);
                        break;
                    case LightActions.IncreaseBrightnessByTwo:
                        IncreaseBrightnessByTwo(lightGrid, x, y);
                        break;
                }
            }
        }
    }

    private LightInstruction ParseInstruction(string instruction)
    {
        var match = Regex.Match(
            instruction,
            @"^(turn on|turn off|toggle) ([\d]+,[\d]+) through ([\d]+,[\d]+)$",
            RegexOptions.Compiled & RegexOptions.IgnoreCase);

        return new LightInstruction
        {
            Action = Actions[match.Groups[1].Value],
            EndpointAlpha = new LightCoordinates(match.Groups[2].Value),
            EndpointBeta = new LightCoordinates(match.Groups[3].Value)
        };
    }

    private void DecreaseBrightnessByOne(LightCoordinates[,] lightGrid, int x, int y) =>
        lightGrid[x, y].Brightness = lightGrid[x, y].Brightness - 1 > 0 ? lightGrid[x, y].Brightness - 1 : 0;

    private void IncreaseBrightnessByOne(LightCoordinates[,] lightGrid, int x, int y) => lightGrid[x, y].Brightness++;

    private void IncreaseBrightnessByTwo(LightCoordinates[,] lightGrid, int x, int y) => lightGrid[x, y].Brightness = lightGrid[x, y].Brightness + 2;

    private readonly Dictionary<string, LightActions> Actions = new Dictionary<string, LightActions>
    {
        { "toggle", LightActions.IncreaseBrightnessByTwo },
        { "turn off", LightActions.DecreaseBrightnessByOne },
        { "turn on", LightActions.IncreaseBrightnessByOne }
    };
}