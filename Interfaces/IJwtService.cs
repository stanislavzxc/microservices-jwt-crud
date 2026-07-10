using System.Security.Claims;

namespace aspcorestudy.Interfaces;

public interface IJwtService
{
    string GenerateToken(int id, string role);
    ClaimsPrincipal? ValidateToken(string token);
}