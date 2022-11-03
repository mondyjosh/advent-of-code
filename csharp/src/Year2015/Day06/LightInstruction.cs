namespace AdventOfCode.Year2015.Day06;

public class LightInstruction {
    public LightActions Action { get; set; }

    public LightCoordinates EndpointAlpha { get; set; }

    public LightCoordinates EndpointBeta { get; set; }
}