using System.Diagnostics.CodeAnalysis;
using TriangleApp.Enums;
using TriangleApp.Services;

namespace TriangleAppTests.Services;

[ExcludeFromCodeCoverage]
[TestFixture]
public class TriangleTypeServiceTests
{
    private TriangleTypeService _triangleTypeService;

    [SetUp]
    public void Setup()
    {
        _triangleTypeService = new TriangleTypeService();
    }

    [Test]
    [Category("L0")]
    public void GetTriangleType_EquilateralTriangle_ReturnsEquilateral()
    {
        var result = _triangleTypeService.GetTriangleType(5, 5, 5);
        Assert.That(  result, Is.EqualTo(TriangleTypesEnum.Equilateral));
    }

    [Test]
    [Category("L0")]
    public void GetTriangleType_IsoscelesTriangle_ReturnsIsosceles()
    {
        var result = _triangleTypeService.GetTriangleType(5, 5, 3);
        Assert.That(result, Is.EqualTo(TriangleTypesEnum.Isosceles));
    }

    [Test]
    [Category("L0")]
    public void GetTriangleType_ScaleneTriangle_ReturnsScalene()
    {
        var result = _triangleTypeService.GetTriangleType(5, 6, 7);
        Assert.That(result, Is.EqualTo(TriangleTypesEnum.Scalene));
    }

    [Test]
    [Category("L0")]
    public void GetTriangleType_InvalidTriangle_ThrowsArgumentException()
    {
        var ex = Assert.Throws<ArgumentException>(() => _triangleTypeService.GetTriangleType(1, 2, 3));
        Assert.That(ex.Message, Is.EqualTo("The sides do not form a valid triangle."));
    }

    [Test]
    [Category("L0")]
    public void GetTriangleType_ZeroOrNegativeSide_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _triangleTypeService.GetTriangleType(-1, 4, 5));
        Assert.Throws<ArgumentException>(() => _triangleTypeService.GetTriangleType(0, 3, 4));
    }

    [Test]
    [Category("L0")]
    public void GetTriangleType_OneSideTooLarge_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _triangleTypeService.GetTriangleType(1, 1, 3));
    }
}