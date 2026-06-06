namespace idobrin_aspnet_logic.DTOs.User;

public record UserReturn(int Id, string Username, string PwdSalt, string PwdHash, string FirstName, string LastName, string? Email, string? PhoneNumber);