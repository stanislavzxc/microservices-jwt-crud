using microservices_jwt_crud.DTOs.ResponseModels;

namespace microservices_jwt_crud.Data.Models;

public class UserModel
{
    public int? id {get;set;}
    public string? name {get;set;}
    public string? email {get;set;}

    public string? role {get;set;}

    public string? password {get;set;}
    public List<CardModel> Cards {get;set;} = new();

}