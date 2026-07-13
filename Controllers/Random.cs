using Microsoft.AspNetCore.Mvc;
using microservices_jwt_crud.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;

[ApiController]
[Route("api/[controller]")]

public class RandomController(RandomService rnd) : ControllerBase
{
    [HttpGet]
    public IActionResult GetRandom()
    {
        return Ok(rnd.RandomNumber());
    }
}