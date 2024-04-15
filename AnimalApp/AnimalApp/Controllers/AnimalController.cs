using AnimalApp.model;
using Microsoft.AspNetCore.Mvc;

namespace GakkoHorizontalSlice.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAnimals([FromQuery] string orderBy = "name")
    {
        return Ok();
    }

    [HttpPost]
    public ActionResult AddAnimal([FromBody] Animal newAnimal)
    {
        return Ok();
    }

    [HttpPut("{idAnimal}")]
    public ActionResult UpdateAnimal(int idAnimal, [FromBody] Animal updatedAnimal)
    {
        return Ok();
    }

    [HttpDelete("{idAnimal}")]
    public ActionResult DeleteAnimal(int idAnimal)
    {
        return Ok();
    }


}