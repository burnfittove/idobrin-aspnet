using idobrin_aspnet_logic.DTOs.Products;

namespace idobrin_aspnet_logic.DTOs.Wishlist;

public record WishlistReturn(int Id, int UserId, IEnumerable<ProductReturn> Products);