using idobrin_aspnet_logic.DTOs.Item;

namespace idobrin_aspnet_logic.DTOs.Cart;

public record CartReturn(int Id, decimal TotalPrice, int? UserId, IEnumerable<ItemReturn?> Items);