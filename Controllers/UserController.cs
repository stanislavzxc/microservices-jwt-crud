using Microsoft.AspNetCore.Mvc;
using aspcorestudy.DTOs.ResponseModels;
using aspcorestudy.Data.Models;
using aspcorestudy.Data.Interfaces;

namespace aspcorestudy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(iRepository<UserModel> DbActions) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var data = await DbActions.GetAllAsync();
        return Ok(data);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await DbActions.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound(new {message = $"user with id {id} not found"});
        }
        return Ok(data); 
    } 

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] User RequestData)
    {
        var userModel = new UserModel
        {
            name = RequestData.name,
            email = RequestData.email,
            role = RequestData.role,
            Cards = RequestData.Cards.Select(c => new CardModel
            {
                name = c.name,
                price = c.price,
            }).ToList()
        };
        
        await DbActions.UpdateAsync(userModel);
        var result = new
        {
            message = "user updated succesfully!",
            updated_at = DateTime.UtcNow,
            user = userModel
        };
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await DbActions.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound(new {message = $"user with id {id} not found"});
        }
        await DbActions.DeleteAsync(user);
        var response = new
        {
            message = $"user with id {id} was deleted",
            deleted_at = DateTime.UtcNow
        };
        return Ok(response);
    }

}