namespace HomeFeatureTest;

using HomeFeatureManagement.Controllers;
using HomeFeatureManagement.Services;
using HomeFeatureManagement.Models;
using Microsoft.AspNetCore.Mvc;

public class UnitsControllerTest
{
    UnitsController _controller;
    IUnitService _service;

    public UnitsControllerTest()
    {
        _service = new UnitService();
        _controller = new UnitsController(_service);
    }

    [Fact]
    public void CreatTest()
    {
        //Arrange
        Unit unit = new Unit()
        {
            PropertyId = "id1",
            Address = "",
            Floors = 3,
            Type = "HOUSE",
            Features = {"balcony","parking"}
        };

        //Act
        var result = _controller.Create(unit);
        //Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void GetAllTest()
    {
        //Arrange
        Unit unit = new Unit()
        {
            PropertyId = "id1",
            Address = "",
            Floors = 3,
            Type = "HOUSE",
            Features = { "balcony", "parking" }
        };

        //Act
        _controller.Create(unit);
        var allUnitsReuslt = _controller.GetAll();
        var list = allUnitsReuslt as OkObjectResult;
        var listUnits = list.Value as List<Unit>;

        //Assert
        Assert.Equal(1, listUnits.Count);
    }

    [Fact]
    public void DeleteTest()
    {
        //Arrange
        Unit unit = new Unit()
        {
            PropertyId = "id1",
            Address = "",
            Floors = 3,
            Type = "HOUSE",
            Features = { "balcony", "parking" }
        };

        //Act
        _controller.Create(unit);
        _controller.Delete("id1");
        var allUnitsReuslt = _controller.GetAll();
        var list = allUnitsReuslt as OkObjectResult;
        var listUnits = list.Value as List<Unit>;

        //Assert
        Assert.Empty(listUnits);
    }

}