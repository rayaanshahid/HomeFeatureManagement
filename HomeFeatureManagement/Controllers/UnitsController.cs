namespace HomeFeatureManagement.Controllers;

using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

[ApiController]
[Route("[controller]")]
public class UnitsController: ControllerBase
{
    private IUnitService _unitService;

    public UnitsController(IUnitService unitService)
    {
        _unitService = unitService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var units = _unitService.GetAll();
        return Ok(units);
    }

    [HttpPost]
    public IActionResult Create(Unit model)
    {
        Console.WriteLine(model);
        _unitService.Create(model);
        return Created("",new { message = "Unit created" });
    }

    [HttpPut]
    public IActionResult Update(Unit model)
    {
        _unitService.Update(model);
        return Ok(new { message = "Unit updated" });
    }

    [HttpDelete("{propertyId}")]
    public IActionResult Delete(string propertyId)
    {
        _unitService.Delete(propertyId);
        return Ok(new { message = "Unit deleted" });
    }
}