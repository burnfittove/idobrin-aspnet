using aspnet_domain.Entities;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Repositories;

public class UserRepository(DatabaseContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> ReturnWishlistProducts(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.Wishlist)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<User?> ReturnCartItems(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.Cart)
            .ThenInclude(e => e.CartItems)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<User?> ReturnUserWithOrders(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.UserOrders)
            .ThenInclude(e => e.Order)
            .ThenInclude(e => e.OrderItems)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }
}