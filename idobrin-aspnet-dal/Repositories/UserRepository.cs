using aspnet_domain.Entities;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Repositories;

public class UserRepository(DatabaseContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<User> ReturnUserWithCartById(int id, CancellationToken cancellationToken)
    {
        return await DbSet
            .Include(e => e.Cart)
            .ThenInclude(e => e.CartItems)
            .ThenInclude(e => e.Item)
            .ThenInclude(e => e.Product)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<User> ReturnUserWithWishlistById(int id, CancellationToken cancellationToken)
    {
        return await DbSet
            .Include(e => e.Wishlist)
            .ThenInclude(e => e.WishlistProducts)
            .ThenInclude(e => e.Product)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken)
    {
        return await DbSet.AnyAsync(e => e.Username.Equals(username), cancellationToken);
    }
}