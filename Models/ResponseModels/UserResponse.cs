namespace aspcorestudy.Models.ResponseModels;
public record User(int id, string? name, string? email, string role,List<Card> Cards);
