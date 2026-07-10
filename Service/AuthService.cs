using aspcorestudy.Data.Interfaces;
using aspcorestudy.Data.Models;
using aspcorestudy.Interfaces;
using aspcorestudy.Models.ResponseModels;
namespace aspcorestudy.Service;

public class AuthService(iRepository<UserModel> DbActions, IJwtService jwt)
{
    public async Task<RegistrationResponse> Registration(User user)
    {
        var userModel = new UserModel
        {
            name = user.name,
            email = user.email,
            role = user.role,
            Cards = user.Cards.Select(c => new CardModel
            {
                name = c.name,
                price = c.price
            }).ToList() 
        };

        await DbActions.CreateAsync(userModel);
        var token = jwt.GenerateToken(user.id, user.role);
        
        return new RegistrationResponse("user was registred succesfully",token);
    }
}