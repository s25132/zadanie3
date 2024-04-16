using AnimalApp.Model;
using AnimalApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GakkoHorizontalSlice.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{

    private IAnimalService _service;

    public AnimalsController(IAnimalService animalService)
    {
        _service = animalService;
    }

    [HttpGet]
    public IActionResult GetAnimals([FromQuery] string orderBy = "Name")
    {
        return Ok(_service.GetAnimals(orderBy));
    }

    [HttpPost]
    public ActionResult AddAnimal([FromBody] Animal newAnimal)
    {
        return StatusCode(StatusCodes.Status201Created, _service.AddAnimal(newAnimal));
    }

    [HttpPut("{idAnimal}")]
    public ActionResult UpdateAnimal(int idAnimal, [FromBody] Animal updatedAnimal)
    {
        return Ok(_service.UpdateAnimal(idAnimal, updatedAnimal));
    }

    [HttpDelete("{idAnimal}")]
    public ActionResult DeleteAnimal(int idAnimal)
    {
        return Ok(_service.DeleteAnimal(idAnimal));
    }
}