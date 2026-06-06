namespace idobrin_aspnet_logic.DTOs.User;

public record UserUpdate(int Id, string FirstName, string Lastname, string? PhoneNumber, string Email);