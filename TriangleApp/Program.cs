using Microsoft.Extensions.DependencyInjection;

namespace TriangleApp;

internal class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = DependencyServices.RegisterServices();
        var program = serviceProvider.GetService<TriangleAppRunner>();

        program.Run();
    }
}