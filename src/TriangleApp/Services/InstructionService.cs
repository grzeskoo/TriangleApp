using System.Text;
using TriangleApp.Interfaces;

namespace TriangleApp.Services;

public class InstructionService : IInstructionService
{
    private readonly Dictionary<string, string> _manualSections;

    public InstructionService()
    {
        _manualSections = new Dictionary<string, string>
        {
            ["General Rules"] =
                "Positive Lengths: All three sides must be positive numbers (greater than 0). Example: Sides like -1, 0, or 2.5 are invalid.\n" +
                "Triangle Inequality Theorem: The sum of any two sides must be greater than the third side.\n" +
                "  For sides a, b, and c:\n" +
                "    a + b > c\n" +
                "    b + c > a\n" +
                "    a + c > b\n" +
                "  Example: 1, 1, 10 is invalid because 1 + 1 < 10.",
            ["Triangle Types"] =
                "If the sides satisfy the rules above, classify the triangle as:\n" +
                "  Equilateral: All three sides are equal (e.g., 3, 3, 3).\n" +
                "  Isosceles: Exactly two sides are equal (e.g., 3, 3, 4).\n" +
                "  Scalene: No sides are equal (e.g., 3, 4, 5)."
        };
    }

    public string GetInstruction()
    {
        var sb = new StringBuilder();
        sb.AppendLine("START OF THE INSTRUCTION *************************************");
        sb.AppendLine("Rules for Creating a Triangle:");
        sb.AppendLine();

        foreach (var section in _manualSections)
        {
            sb.AppendLine(section.Key);
            sb.AppendLine(section.Value);

        }
        sb.AppendLine("END OF THE INSTRUCTION *************************************");

        return sb.ToString();
    }
}