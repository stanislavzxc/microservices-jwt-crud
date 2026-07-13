using microservices_jwt_crud.Interfaces;
using microservices_jwt_crud.Data.Models;
using microservices_jwt_crud.Data.Repositories;
using microservices_jwt_crud.DTOs.ResponseModels;
using microservices_jwt_crud.Shared;

namespace microservices_jwt_crud.Service;

public class CardService(EfRepository<CardModel> DbActions) : ICardService
{
    public async Task<Result<CardModel>> GetCard(int id)
    {
        var card = await DbActions.GetByIdAsync(id);
        if (card == null)
        {
            return Result<CardModel>.Failure($"Card with id {id} not found");
        }
        return Result<CardModel>.Success(card);
    }

    public async Task<List<CardModel>> GetAllCards()
    {
        return await DbActions.GetAllAsync();
    } 
    public async Task<Result<CardModel>> UpdateCard(Card card)
    {
        var existingCard = await DbActions.GetByIdAsync((int)card.id!);
        if (existingCard == null)
        {
            return Result<CardModel>.Failure($"Card with id {card.id} not found for update");
        }

        existingCard.name = card.name;
        existingCard.price = card.price;
        existingCard.UserId = card.UserId;

        await DbActions.UpdateAsync(existingCard);
        return Result<CardModel>.Success(existingCard);
    }

    public async Task<Result<CardModel>> CreateCard(Card card)
    {
        var cardModel = new CardModel
        {
            name = card.name,
            price = card.price,
            UserId = card.UserId
        };
    
        await DbActions.CreateAsync(cardModel);
        return Result<CardModel>.Success(cardModel);
    }
    public async Task<Result> DeleteCard(int id)
    {
        var card = await DbActions.GetByIdAsync(id);
        
        if (card == null)
        {
            return Result.Failure($"Card with id {id} not found");
        }
        await DbActions.DeleteAsync(card);
        return Result.Success();
    }
}