using aspnet_domain.Entities;

namespace aspnet_domain.Interfaces;

public interface IWishlistProductsRepository
{
    Task<WishlistProducts> AddProductToWishlist(Wishlist wishlist, Product product, CancellationToken cancellationToken);
}