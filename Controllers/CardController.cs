using Microsoft.AspNetCore.Mvc;
using microservices_jwt_crud.DTOs.ResponseModels;
using microservices_jwt_crud.Service;
using microservices_jwt_crud.Shared;
using microservices_jwt_crud.Data.Models;
using microservices_jwt_crud.Interfaces;

namespace microservices_jwt_crud.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CardController(ICardService cardService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCard(int id)
    {
        Result<CardModel> result = await cardService.GetCard(id);
        
        if (!result.IsSuccess)
        {
            return NotFound(new {message = result.Error});
        }
        return Ok(result.Value);

    }

    [HttpGet]
    public async Task<IActionResult> GetAllCards()
    {
        List<CardModel> result = await cardService.GetAllCards();
        return Ok(new {result});
    }

    [HttpPost]
    public async Task<IActionResult> CreateCard([FromBody] Card ReguestData)
    {
        Result<CardModel> result = await cardService.CreateCard(ReguestData);
        return Ok(result.Value);
    }


    [HttpPut]
    public async  Task<IActionResult> UpdateCard([FromBody] Card ReguestData)
    {   
        Result<CardModel> result = await cardService.UpdateCard(ReguestData);
        
        if (!result.IsSuccess)
        {
            return NotFound(new { message = result.Error });
        }

        return Ok(result.Value);
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCard(int id)
    {
        Result result = await cardService.DeleteCard(id);
        
        if(!result.IsSuccess)
        {
            return NotFound(new {message = result.Error});
        }

        return Ok(new {message = $"Card with id {id} was deleted"});        
    }
}