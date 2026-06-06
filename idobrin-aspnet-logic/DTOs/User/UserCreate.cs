namespace idobrin_aspnet_logic.DTOs.User;

public record UserCreate(string FirstName, string LastName, string? PhoneNumber, string Email);