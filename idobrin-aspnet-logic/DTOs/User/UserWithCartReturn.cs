using idobrin_aspnet_logic.DTOs.Cart;

namespace idobrin_aspnet_logic.DTOs.User;

public record UserWithCartReturn(int Id, string FirstName, string LastName, string? Email, string? PhoneNumber, CartReturn? Cart);