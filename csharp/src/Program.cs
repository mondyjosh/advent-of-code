using System.Reflection;

using Autofac;

// TODO: Implement snazzy System.CommandLine package for argument handling.
var builder = new ContainerBuilder();

// TODO: Don't rely on possibly null-reference returned t.FullName.
builder.RegisterAssemblyTypes(typeof(ISolution).GetTypeInfo().Assembly)
    .Named(t => t.Name, typeof(ISolution));

var container = builder.Build();

 ExecuteSolution(container, args);

static void ExecuteSolution(IContainer container, string[] args)
{
    int.TryParse(args[0], out int year);
    int.TryParse(args[1], out int day);
    var input = InputHandler.LoadInput(year, day);

    var solution = container.ResolveNamed<ISolution>($"Year{year}Day{day.ToString("D2")}Solution");

    if (!string.IsNullOrEmpty(input))
    {
        Console.WriteLine($"Helping 🎅 save Christmas on {year}-{day.ToString("D2")}... 🦌\r\n");
        Console.WriteLine($"🌟 Part 1 solution: {solution.SolvePart1(input)}");
        Console.WriteLine($"🌟 Part 2 solution: {solution.SolvePart2(input)}");
        Console.WriteLine("\r\n🎄 Christmas is one day closer to being saved! 🎄");
    }
    else
    {
        Console.WriteLine("\r\nNo input detected. Hurry and save Christmas!");
    }
}
