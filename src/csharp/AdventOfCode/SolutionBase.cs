using Microsoft.Extensions.Configuration;

public abstract class SolutionBase
{
    public static string LoadInput()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        // TODO: Assemble full path dynamically based on year/day (maybe part?)
        var inputPath = config.GetValue<string>("InputPath");
        var fullpath = $"{inputPath}/2015/day01_input.txt";

        using (var streamReader = new StreamReader(fullpath))
            return streamReader.ReadToEnd();
    }
}