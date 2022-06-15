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

        var inputFilePathTemplate = config.GetValue<string>("InputFilePathTemplate");

        var filePath = inputFilePathTemplate
            .Replace("{year}", year.ToString())
            .Replace("{day}", day.ToString("D2"));

        try
        {
            using (var streamReader = new StreamReader(filePath))
                return streamReader.ReadToEnd();
        }
        catch (Exception ex)
        {
            var foregroundColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine(ex);
            Console.ForegroundColor = foregroundColor;

            return string.Empty;
        }
    }

    public static string[] SplitInputByNewline(string input) => input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
}
