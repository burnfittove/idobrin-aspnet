using idobrin_aspnet_logic.DTOs.Cart;

namespace idobrin_aspnet_logic.DTOs.User;

public record UserWithCartReturn(int Id, CartReturn? Cart);