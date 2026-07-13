using microservices_jwt_crud.Data.Models;
using microservices_jwt_crud.DTOs.ResponseModels;
using microservices_jwt_crud.Shared;
namespace microservices_jwt_crud.Interfaces;
public interface ICardService
{
    public Task<Result<CardModel>> GetCard(int id);
    public Task<List<CardModel>> GetAllCards();
    public Task<Result<CardModel>> UpdateCard(Card card);
    public Task<Result<CardModel>> CreateCard(Card card);
    public Task<Result> DeleteCard(int id);
}