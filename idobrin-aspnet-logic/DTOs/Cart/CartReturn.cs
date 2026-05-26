using idobrin_aspnet_logic.DTOs.Item;
using idobrin_aspnet_logic.DTOs.Products;

namespace idobrin_aspnet_logic.DTOs.Cart;

public record CartReturn(int Id, decimal TotalPrice, int? UserId, IEnumerable<ProductReturn?>? Items);