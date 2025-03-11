using System.Diagnostics.CodeAnalysis;
using TriangleApp.Enums;
using TriangleApp.Services;

namespace TriangleAppTests.Services;

[ExcludeFromCodeCoverage]
[TestFixture]
public class InputDataServiceTests
{
    private InputDataService _inputDataService;

    [SetUp]
    public void Setup()
    {
        _inputDataService = new InputDataService();
    }
 
    [TestCase(null, InputInstructionsEnums.Continue)]
    [TestCase("", InputInstructionsEnums.Continue)]
    [TestCase("   ", InputInstructionsEnums.Continue)]
    [TestCase("i", InputInstructionsEnums.Instructions)]
    [TestCase("I", InputInstructionsEnums.Instructions)]
    [TestCase("q", InputInstructionsEnums.Quit)]
    [TestCase("Q", InputInstructionsEnums.Quit)]
    [TestCase("c", InputInstructionsEnums.Continue)]
    [TestCase("x", InputInstructionsEnums.Continue)]
    [TestCase("  x  ", InputInstructionsEnums.Continue)]
    [Category("L0")]
    public void GetInputData_Input_ReturnsContinue(string? input, InputInstructionsEnums expected)
    {
        var result = _inputDataService.GetInputData(input);
        Assert.That(result, Is.EqualTo(expected));
    }
   
    [Test]
    [Category("L0")]
    public void GetSideData_ValidInput_ReturnsSidesArray()
    {
        var result = _inputDataService.GetSideData("3 4 5");
        Assert.That(result, Is.EqualTo(new double[] { 3, 4, 5 }));
    }

    [TestCase(null, "Input cannot be empty.")]
    [TestCase("", "Input cannot be empty.")]
    [TestCase("   ", "Input cannot be empty.")]
    [Category("L0")]
    public void GetSideData_EmptyOrNullInput_ThrowsArgumentException(string? input, string expectedMessage)
    {
        var exception = Assert.Throws<ArgumentException>(() => _inputDataService.GetSideData(input));
        Assert.That(exception.Message, Is.EqualTo(expectedMessage));
    }

    [TestCase("3 4", "Please provide exactly three side lengths.")]
    [TestCase("3 4 5 6", "Please provide exactly three side lengths.")]
    [Category("L0")]
    public void GetSideData_IncorrectSideCount_ThrowsArgumentException(string? input, string expectedMessage)
    {
        var exception = Assert.Throws<ArgumentException>(() => _inputDataService.GetSideData(input));
        Assert.That(exception.Message, Is.EqualTo(expectedMessage));
    }

    [TestCase("3 4 abc", "All sides must be positive numbers.")]
    [TestCase("3 -4 5", "All sides must be positive numbers.")]
    [TestCase("3 0 5", "All sides must be positive numbers.")]
    [Category("L0")]
    public void GetSideData_InvalidNumericInput_ThrowsArgumentException(string? input, string expectedMessage)
    {
        var exception = Assert.Throws<ArgumentException>(() => _inputDataService.GetSideData(input));
        Assert.That(exception.Message, Is.EqualTo(expectedMessage));
    }

    [Test]
    [Category("L0")]
    public void GetSideData_ExtraWhitespace_ReturnsSidesArray()
    {
        var result = _inputDataService.GetSideData("  3   4   5  ");
        Assert.That(result, Is.EqualTo(new double[] { 3, 4, 5 }));
    }
}