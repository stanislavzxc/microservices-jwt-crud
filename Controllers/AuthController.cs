using aspcorestudy.Service;
using Microsoft.AspNetCore.Mvc; 
using aspcorestudy.DTOs.ResponseModels;
using Microsoft.AspNetCore.Http.HttpResults;
using aspcorestudy.DTOs.ResponseModel;

namespace aspcorestudy.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AuthController(AuthService authService) : ControllerBase
{
    [HttpPost("/SignUp")]
    public async Task<IActionResult> Registration([FromBody] User user)
    {
        RegistrationResponse data = await authService.Registration(user);
        return Ok(data);
    }

    [HttpPost("/LogIn")]
    public async Task<IActionResult> LogIn([FromBody] LogInResponse userData)
    {
        RegistrationResponse response = await authService.LogIn(userData);
        return Ok(response);
    }

} 
