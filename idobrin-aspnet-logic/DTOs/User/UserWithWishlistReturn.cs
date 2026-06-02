using idobrin_aspnet_logic.DTOs.Wishlist;

namespace idobrin_aspnet_logic.DTOs.User;

public record UserWithWishlistReturn(int Id, WishlistReturn? Wishlist);