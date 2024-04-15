using AnimalApp.model;
using AnimalApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GakkoHorizontalSlice.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{

    private IAnimalService _service;

    public AnimalController(IAnimalService animalService)
    {
        _service = animalService;
    }


    [HttpGet]
    public IActionResult GetAnimals([FromQuery] string orderBy = "name")
    {
        return Ok(_service.GetAnimals());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        Animal animal = _service.GetAnimal(id);

        if (animal == null)
        {
            return NotFound("animal not found");
        }

        return Ok(animal);
    }

    [HttpPost]
    public ActionResult AddAnimal([FromBody] Animal newAnimal)
    {
        return Ok(_service.AddAnimal(newAnimal));
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