using Microsoft.AspNetCore.Mvc;
using aspcorestudy.Models.ResponseModels;

namespace aspcorestudy.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CardController : ControllerBase
{
    [HttpGet]
    public IActionResult GetCard()
    {
     var data = new Card(1,"first", 15.0, 1);
     return Ok(data);
    }
    [HttpPost]
    public IActionResult PostCard([FromBody] Card ReguestData)
    {   
        var result = new
        {
            message = "card created succesfully!",
            created_at = DateTime.UtcNow
        };

        return Created("api/Card", result);
    }
}