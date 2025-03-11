using TriangleApp.Interfaces;

namespace TriangleApp.Services;

public class ConsoleService : IConsoleService
{
    public string? ReadLine() => Console.ReadLine();
    public void WriteLine(string value) => Console.WriteLine(value);
}