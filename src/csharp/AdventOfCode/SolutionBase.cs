using Microsoft.Extensions.Configuration;

public abstract class SolutionBase
{
    public abstract int SolvePart1(string input);

    public abstract int SolvePart2(string input);

    public static string LoadInput(int year = 2015, int day = 1)
    {
        // If we need more config, move IConfiguration around via DI
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var inputPath = config.GetValue<string>("InputPath");
        var filePath = $"{inputPath}/{year}/day{day.ToString("D2")}_input.txt";

        try
        {
            using (var streamReader = new StreamReader(filePath))
                return streamReader.ReadToEnd();
        }
        catch (Exception ex)
        {
            var foregroundColor = Console.ForegroundColor;
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine($"\r\nCan't help Santa!\r\nAn exception occurred loading input: {ex.Message}\r\n");
            Console.ForegroundColor = foregroundColor;

            return string.Empty;
        }
    }
}
