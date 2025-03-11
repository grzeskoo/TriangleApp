using TriangleApp.Enums;
using TriangleApp.Interfaces;

namespace TriangleApp.Services;

public class TriangleTypeService : ITriangleTypeService
{
    public TriangleTypesEnum GetTriangleType(double a, double b, double c)
    {
        if (!IsValidTriangle(a, b, c))
        {
            throw new ArgumentException("The sides do not form a valid triangle.");
        }

        if (a == b && b == c)
        {
            return TriangleTypesEnum.Equilateral;
        }
        else if (a == b || b == c || a == c)
        {
            return TriangleTypesEnum.Isosceles;
        }
        else
        {
            return TriangleTypesEnum.Scalene;
        }
    }

    private static bool IsValidTriangle(double a, double b, double c)
    {
        return (a + b > c) && (b + c > a) && (a + c > b);
    }
}