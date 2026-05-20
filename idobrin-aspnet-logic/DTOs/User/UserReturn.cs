namespace idobrin_aspnet_logic.DTOs.User;

public record UserReturn(int Id, string FirstName, string LastName, string? Email, string? PhoneNumber);