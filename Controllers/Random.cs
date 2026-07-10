using Microsoft.AspNetCore.Mvc;
using aspcorestudy.Controllers;
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