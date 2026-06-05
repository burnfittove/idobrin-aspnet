using aspnet_domain.Entities;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Repositories;

public class WishlistProductsRepository(DatabaseContext context) : IWishlistProductsRepository
{
    private readonly DbSet<WishlistProducts> DbSet = context.Set<WishlistProducts>();
    
    public async Task<WishlistProducts> AddProductToWishlist(Wishlist wishlist, Product product, CancellationToken cancellationToken)
    {
        var entity = new WishlistProducts
        {
            ProductId = product.Id,
            Product = product,
            WishlistId = wishlist.Id,
            Wishlist = wishlist,
        };
        await DbSet.AddAsync(entity, cancellationToken);
        return entity;
    }
}