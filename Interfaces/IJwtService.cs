using System.Security.Claims;

namespace microservices_jwt_crud.Interfaces;

public interface IJwtService
{
    string GenerateToken(int id, string role);
    ClaimsPrincipal? ValidateToken(string token);
}