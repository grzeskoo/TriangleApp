using Microsoft.Extensions.DependencyInjection;
using TriangleApp.Interfaces;
using TriangleApp.Services;

namespace TriangleApp;

public static class DependencyServices
{
    internal static IServiceProvider RegisterServices()
    {
        var services = new ServiceCollection();

        services.AddScoped<IInputDataService, InputDataService>();
        services.AddScoped<ITriangleTypeService, TriangleTypeService>();
        services.AddScoped<IInstructionService, InstructionService>();
        services.AddScoped<IConsoleService, ConsoleService>();
        services.AddScoped<Program>();

        return services.BuildServiceProvider();
    }
}