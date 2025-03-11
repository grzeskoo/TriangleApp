using TriangleApp.Enums;
using TriangleApp.Interfaces;

namespace TriangleApp.Services;

public class InputDataService : IInputDataService
{
    public InputInstructionsEnums GetInputData(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return InputInstructionsEnums.Continue;
        }

        var trimmedInput = input.Trim().ToLowerInvariant();

        return trimmedInput switch
        {
            "i" => InputInstructionsEnums.Instructions,
            "q" => InputInstructionsEnums.Quit,
            "c" => InputInstructionsEnums.Continue,
            _ => InputInstructionsEnums.Continue
        };
    }

    public double[] GetSideData(string? input)
    {
        if (string.IsNullOrWhiteSpace(input) )
        {
            throw new ArgumentException("Input cannot be empty.");
        }

        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 3)
        {
            throw new ArgumentException("Please provide exactly three side lengths.");
        }

        var sides = new double[3];
        for (var i = 0; i < 3; i++)
        {
            if (!double.TryParse(parts[i], out sides[i]) || sides[i] <= 0)
            {
                throw new ArgumentException("All sides must be positive numbers.");
            }
        }

        return sides;
    }
}