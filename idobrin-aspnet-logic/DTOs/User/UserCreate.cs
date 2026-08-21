namespace idobrin_aspnet_logic.DTOs.User;

public record UserCreate(string Username, string PwdSalt, string PwdHash, string FirstName, string LastName, string? PhoneNumber, string Email, int RoleId);