using aspcorestudy.DTOs.ResponseModel;
using aspcorestudy.DTOs.ResponseModels;
using Microsoft.AspNetCore.Identity.Data;

namespace aspcorestudy.Interfaces;
public interface IAuthService
{
 public Task<RegistrationResponse> Registration(User user);  
 public Task<RegistrationResponse> LogIn(LogInResponse userData);
}