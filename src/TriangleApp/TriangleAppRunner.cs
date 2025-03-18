using TriangleApp.Enums;
using TriangleApp.Helpers;
using TriangleApp.Interfaces;

namespace TriangleApp;

internal class TriangleAppRunner
{
    private readonly IInputDataService _inputDataService;
    private readonly ITriangleTypeService _triangleTypeService;
    private readonly IInstructionService _instructionService;
    private readonly IConsoleService _consoleService;

    public TriangleAppRunner(IInputDataService inputDataService,
        ITriangleTypeService triangleTypeService,
        IInstructionService instructionService,
        IConsoleService consoleService)
    {
        _inputDataService = inputDataService ?? throw new ArgumentNullException(nameof(inputDataService));
        _triangleTypeService = triangleTypeService ?? throw new ArgumentNullException(nameof(triangleTypeService));
        _instructionService = instructionService ?? throw new ArgumentNullException(nameof(instructionService));
        _consoleService = consoleService ?? throw new ArgumentNullException(nameof(consoleService));
    }

    public void Run()
    {
        CommandPrompts.InitialWelcome(_consoleService);
        CommandPrompts.Instructions(_consoleService);
        CommandPrompts.ReadyToStart(_consoleService);

        while (true)
        {
            var input = _consoleService.ReadLine();
            var inputType = _inputDataService.GetInputData(input);

            switch (inputType)
            {
                case InputInstructionsEnums.Instructions:
                    _consoleService.WriteLine(_instructionService.GetInstruction());
                    CommandPrompts.ReadyToStart(_consoleService);
                    break;

                case InputInstructionsEnums.Quit:
                    CommandPrompts.QuitApp(_consoleService);
                    return;

                case InputInstructionsEnums.Continue:
                    try
                    {
                        CommandPrompts.ProvideTriangleSides(_consoleService);
                        var sideInput = _consoleService.ReadLine()?.Trim();

                        if (_inputDataService.GetInputData(sideInput) == InputInstructionsEnums.Quit)
                        {
                            CommandPrompts.QuitApp(_consoleService);
                            return;
                        }

                        var sides = _inputDataService.GetSideData(sideInput);
                        var triangleType = _triangleTypeService.GetTriangleType(sides[0], sides[1], sides[2]);

                        CommandPrompts.Result(_consoleService, triangleType);
                        CommandPrompts.AnotherTry(_consoleService);
                    }
                    catch (ArgumentException ex)
                    {
                        CommandPrompts.Error(_consoleService, ex.Message);
                        CommandPrompts.Instructions(_consoleService);
                        CommandPrompts.AnotherTry(_consoleService);
                    }
                    break;

                default:
                    throw new NotImplementedException("Unexpected input type returned from service.");
            }
        }
    }
}