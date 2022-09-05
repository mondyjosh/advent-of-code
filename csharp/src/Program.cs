// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;

// using IHost host = Host.CreateDefaultBuilder(args)
//     .ConfigureServices((_, services) =>
//         services.AddTransient<ITransientOperation, DefaultOperation>()
//             .AddScoped<IScopedOperation, DefaultOperation>()
//             .AddSingleton<ISingletonOperation, DefaultOperation>()
//             .AddTransient<OperationLogger>())
//     .Build();

// ExemplifyScoping(host.Services, "Scope 1");
// ExemplifyScoping(host.Services, "Scope 2");

// await host.RunAsync();

// static void ExemplifyScoping(IServiceProvider services, string scope)
// {
//     using IServiceScope serviceScope = services.CreateScope();
//     IServiceProvider provider = serviceScope.ServiceProvider;

//     OperationLogger logger = provider.GetRequiredService<OperationLogger>();
//     logger.LogOperations($"{scope}-Call 1 .GetRequiredService<OperationLogger>()");

//     Console.WriteLine("...");

//     logger = provider.GetRequiredService<OperationLogger>();
//     logger.LogOperations($"{scope}-Call 2 .GetRequiredService<OperationLogger>()");

//     Console.WriteLine();
// }

// public interface IOperation
// {
//     string OperationId { get; }
// }

// public interface ITransientOperation : IOperation
// {}

// public interface IScopedOperation : IOperation
// {}

// public interface ISingletonOperation : IOperation
// {}

// public class DefaultOperation :
//     ITransientOperation,
//     IScopedOperation,
//     ISingletonOperation
// {
//     public string OperationId { get; } = "the operation, yo"; //NewGuid().ToString()[^4..];
// }

// public class OperationLogger
// {
//     private readonly ITransientOperation _transientOperation;
//     private readonly IScopedOperation _scopedOperation;
//     private readonly ISingletonOperation _singletonOperation;

//     public OperationLogger(
//         ITransientOperation transientOperation,
//         IScopedOperation scopedOperation,
//         ISingletonOperation singletonOperation) =>
//         (_transientOperation, _scopedOperation, _singletonOperation) =
//             (transientOperation, scopedOperation, singletonOperation);

//     public void LogOperations(string scope)
//     {
//         LogOperation(_transientOperation, scope, "Always different");
//         LogOperation(_scopedOperation, scope, "Changes only with scope");
//         LogOperation(_singletonOperation, scope, "Always the same");
//     }

//     private static void LogOperation<T>(T operation, string scope, string message)
//         where T : IOperation =>
//         Console.WriteLine(
//             $"{scope}: {typeof(T).Name,-19} [ {operation.OperationId}...{message,-23} ]");
// }

using Microsoft.Extensions.DependencyInjection;

// TODO: Implement snazzy System.CommandLine package for argument handling.

var services = new ServiceCollection();

ConfigureServices(services);

int.TryParse(args[0], out int year);
int.TryParse(args[1], out int day);

// This is just gross. Any other way to handle this chain?
services
    .AddSingleton<Executor, Executor>()
    ?.BuildServiceProvider()
    ?.GetService<Executor>()
    ?.Execute(year, day);

static void ConfigureServices(IServiceCollection services)
{    
    // TODO: Configure keyed instances dynamically based off of naming conventions.
    services
        .AddSingleton<ISolution, AdventOfCode.Year2015.Day03Solution>();
}

class Executor
{
    public Executor(ISolution solution)
    {
        _solution = solution;
    }

    public void Execute(int year, int day)
    {
        var input = InputHandler.LoadInput(year, day);

        if (!string.IsNullOrEmpty(input))
        {
            Console.WriteLine($"Part 1 solution: {_solution.SolvePart1(input)}");
            Console.WriteLine($"Part 2 solution: {_solution.SolvePart2(input)}");
        }
        else
        {
            Console.WriteLine("\r\nNo input detected. Hurry and save Christmas!");
        }
    }
    private readonly ISolution _solution;
}

