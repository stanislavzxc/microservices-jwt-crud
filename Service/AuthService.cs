using microservices_jwt_crud.Data.Interfaces;
using microservices_jwt_crud.Data.Models;
using microservices_jwt_crud.Interfaces;
using microservices_jwt_crud.DTOs.ResponseModels;
using Microsoft.AspNetCore.Identity;
using microservices_jwt_crud.Data;
using Microsoft.EntityFrameworkCore;
using microservices_jwt_crud.DTOs.ResponseModel;

namespace microservices_jwt_crud.Service;

public class AuthService(iRepository<UserModel> DbActions, IJwtService jwt, AppDbContext context) : IAuthService
{
    private PasswordHasher<UserModel> _hasher = new PasswordHasher<UserModel>();
    private AppDbContext _context = context;
    public async Task<RegistrationResponse> Registration(User user)
    {
        var userModel = new UserModel
        {
            name = user.name,
            email = user.email,
            role = user.role,
            password = string.Empty,
            Cards = user.Cards.Select(c => new CardModel
            {
                name = c.name,
                price = c.price
            }).ToList() 
        };
        
        userModel.password = _hasher.HashPassword(userModel, user.password!);

        await DbActions.CreateAsync(userModel);

        int userId = userModel.id ?? throw new InvalidOperationException("user id is null");
        string userRole = userModel.role ?? throw new InvalidOperationException("user role is null");

        var token = jwt.GenerateToken(userId, userRole);
        
        return new RegistrationResponse("user was registred succesfully",token);
    }
    public async Task<RegistrationResponse> LogIn(LogInResponse userData)
    {
       var user = await _context.Users.FirstOrDefaultAsync(u => u.email == userData.email);

       if (user == null)
        {
            return new RegistrationResponse(
                "user not found!",
                "no token"  
            );
        } 

       PasswordVerificationResult result =  _hasher.VerifyHashedPassword(user, user.password!, userData.password);
        switch (result)
        {
            case PasswordVerificationResult.Failed:
                return new RegistrationResponse("failed!", "no token");
            
            case PasswordVerificationResult.SuccessRehashNeeded:
                user.password = _hasher.HashPassword(user, userData.password);
                await _context.SaveChangesAsync();
                break;
        }
        
        int userId = user.id ?? throw new InvalidOperationException("user id is null");
        string userRole = user.role ?? throw new InvalidOperationException("user role is null");
        
        var token = jwt.GenerateToken(userId, userRole);

        return new RegistrationResponse("login succesfull", token);
    }
}