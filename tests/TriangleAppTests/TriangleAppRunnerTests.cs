using Moq;
using System.Diagnostics.CodeAnalysis;
using TriangleApp;
using TriangleApp.Enums;
using TriangleApp.Interfaces;

namespace TriangleAppTests;

[ExcludeFromCodeCoverage]
[TestFixture]
public class TriangleAppRunnerTests
{
    private Mock<IInputDataService> _mockInputDataService;
    private Mock<ITriangleTypeService> _mockTriangleTypeService;
    private Mock<IInstructionService> _mockInstructionService;
    private Mock<IConsoleService> _mockConsoleService;
    private TriangleAppRunner _triangleAppRunner;

    [SetUp]
    public void Setup()
    {
        _mockInputDataService = new Mock<IInputDataService>();
        _mockTriangleTypeService = new Mock<ITriangleTypeService>();
        _mockInstructionService = new Mock<IInstructionService>();
        _mockConsoleService = new Mock<IConsoleService>();

        _triangleAppRunner = new TriangleAppRunner(
            _mockInputDataService.Object,
            _mockTriangleTypeService.Object,
            _mockInstructionService.Object,
            _mockConsoleService.Object);
    }

    [Test]
    [Category("L0")]
    public void Run_QuitInput_ExitsApplication()
    {
        _mockConsoleService.SetupSequence(m => m.ReadLine()).Returns("q");
        _mockInputDataService.Setup(m => m.GetInputData("q")).Returns(InputInstructionsEnums.Quit);

        _triangleAppRunner.Run();

        _mockConsoleService.Verify(m => m.WriteLine(It.Is<string>(s => s.Contains("Goodbye!"))), Times.Once());
    }

    [Test]
    public void Run_ContinueWithValidSides_DisplaysEquilateralTriangleType()
    {
        _mockConsoleService.SetupSequence(m => m.ReadLine())
            .Returns("c")
            .Returns("3 3 3")
            .Returns("q");
        _mockInputDataService.Setup(m => m.GetInputData("c")).Returns(InputInstructionsEnums.Continue);
        _mockInputDataService.Setup(m => m.GetInputData("3 3 3")).Returns(InputInstructionsEnums.Continue);
        _mockInputDataService.Setup(m => m.GetInputData("q")).Returns(InputInstructionsEnums.Quit);
        _mockInputDataService.Setup(m => m.GetSideData("3 3 3")).Returns([3, 3, 3]);
        _mockTriangleTypeService.Setup(m => m.GetTriangleType(3, 4, 5)).Returns(TriangleTypesEnum.Equilateral);

        _triangleAppRunner.Run();

        _mockConsoleService.Verify(m => m.WriteLine(It.Is<string>(s => s.Contains("Enter the 3 sides"))), Times.Once());
        _mockConsoleService.Verify(m => m.WriteLine(It.Is<string>(s => s.Contains("Equilateral"))), Times.Once());
        _mockConsoleService.Verify(m => m.WriteLine(It.Is<string>(s => s.Contains("Try again"))), Times.Once());
    }
}