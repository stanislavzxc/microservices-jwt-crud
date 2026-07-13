using microservices_jwt_crud.DTOs.ResponseModel;
using microservices_jwt_crud.DTOs.ResponseModels;
using Microsoft.AspNetCore.Identity.Data;

namespace microservices_jwt_crud.Interfaces;
public interface IAuthService
{
 public Task<RegistrationResponse> Registration(User user);  
 public Task<RegistrationResponse> LogIn(LogInResponse userData);
}