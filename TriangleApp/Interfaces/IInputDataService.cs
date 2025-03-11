using TriangleApp.Enums;

namespace TriangleApp.Interfaces;

public interface IInputDataService
{
    InputInstructionsEnums GetInputData(string? input);
    double[] GetSideData(string? input);
}