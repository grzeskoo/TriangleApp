using TriangleApp.Enums;

namespace TriangleApp.Interfaces;

public interface ITriangleTypeService
{
    TriangleTypesEnum GetTriangleType(double a, double b, double c);
}