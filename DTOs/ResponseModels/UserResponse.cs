namespace microservices_jwt_crud.DTOs.ResponseModels;
public record User(int id, string? name, string? email, string role, string? password, List<Card> Cards);
