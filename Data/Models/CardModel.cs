namespace aspcorestudy.Data.Models;

public class CardModel
{
    public int? id {get;set;}
    public string? name {get;set;}
    public double? price {get;set;}
    
    public int? UserId {get;set;}  

    public UserModel User{get;set;} = null!;
}