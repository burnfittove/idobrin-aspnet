using idobrin_aspnet_logic.DTOs.Item;

namespace idobrin_aspnet_logic.DTOs;

public record CartReturn(int Id, decimal TotalPrice, IEnumerable<ItemReturn> Items);