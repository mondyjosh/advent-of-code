namespace AdventOfCode.Year2015;

using System.Linq;
using System.Text.RegularExpressions;

using Year2015.Day06;

class Year2015Day06Solution : ISolution
{
    public int SolvePart1(string input) => GetLitLightCount(input);

    public int SolvePart2(string input) => throw new NotImplementedException();

    private int GetLitLightCount(string input)
    {
        var instructions = input.SplitByNewline();
        var lightGrid = new LightCoordinates[1000, 1000];

        foreach (var instruction in instructions)
            ProcessInstruction(lightGrid, instruction);

        return lightGrid.Cast<LightCoordinates>().Count(light => light.IsLit);
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
                    case LightActions.ToggleLight:
                        ToggleLight(lightGrid, x, y);
                        break;
                    case LightActions.TurnOnLight:
                        TurnOnLight(lightGrid, x, y);
                        break;
                    case LightActions.TurnOffLight:
                        TurnOffLight(lightGrid, x, y);
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

    private void TurnOnLight(LightCoordinates[,] lightGrid, int x, int y) => lightGrid[x, y].IsLit = true;

    private void TurnOffLight(LightCoordinates[,] lightGrid, int x, int y) => lightGrid[x, y].IsLit = false;

    private void ToggleLight(LightCoordinates[,] lightGrid, int x, int y) => lightGrid[x, y].IsLit = !lightGrid[x, y].IsLit;

    private readonly Dictionary<string, LightActions> Actions = new Dictionary<string, LightActions>
    {
        { "turn on", LightActions.TurnOnLight },
        { "turn off", LightActions.TurnOffLight },
        { "toggle", LightActions.ToggleLight }
    };
}
