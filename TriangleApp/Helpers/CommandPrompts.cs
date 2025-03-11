using TriangleApp.Enums;
using TriangleApp.Interfaces;

namespace TriangleApp.Helpers;

public static class CommandPrompts
{
    public static void InitialWelcome(IConsoleService console) => console.WriteLine("*** This program recognizes the type of triangle ***");
    public static void Instructions(IConsoleService console) => console.WriteLine("*** For instructions, type 'I' | To quit, type 'Q' ***");
    public static void ReadyToStart(IConsoleService console) => console.WriteLine("*** Ready to start? Press Enter to continue ***");
    public static void ProvideTriangleSides(IConsoleService console) => console.WriteLine("Enter the 3 sides (e.g., '3 4 5') separated by spaces:");
    public static void QuitApp(IConsoleService console) => console.WriteLine("Goodbye!");
    public static void AnotherTry(IConsoleService console) => console.WriteLine("Try again? (I, Q, or any to Continue):");
    public static void Result(IConsoleService console, TriangleTypesEnum triangleType) => console.WriteLine($"\n The triangle is: {triangleType}\n");
    public static void Error(IConsoleService console, string errorMessage) => console.WriteLine($"Error: {errorMessage} \n");
}
