using Microsoft.AspNetCore.Mvc;

namespace GakkoHorizontalSlice.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{
    /// <summary>
    /// Endpoints used to return list of animals.
    /// </summary>
    /// <returns>List of animals</returns>
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok();
    }

}