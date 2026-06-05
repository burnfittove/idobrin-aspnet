using idobrin_aspnet_logic.DTOs.Item;

namespace idobrin_aspnet_logic.DTOs.Cart;

public record CartReturn(int Id, int? UserId, IEnumerable<ItemReturn?> Items);