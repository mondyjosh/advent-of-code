namespace AdventOfCode.Common;

using Microsoft.Extensions.Configuration;

public static class InputHandler
{
    public static string LoadInput(int year = 2015, int day = 1)
    {
        // If more config is eventually, pass IConfiguration around via DI
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var inputFilePathTemplate = config.GetValue<string>("InputFilePathTemplate");

        var filePath = inputFilePathTemplate
            .Replace("{year}", year.ToString())
            .Replace("{day}", day.ToString("D2"));

        try
        {
            // if (!File.Exists(filePath))
            //     // Working directory is already at sln level
            //     // Move up one directory.
            //     filePath = filePath.Replace("../..", "..");

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
}
