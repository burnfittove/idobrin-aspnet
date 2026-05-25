using aspnet_domain.Entities;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Repositories;

public class CartRepository(DatabaseContext context) : BaseRepository<Cart>(context), ICartRepository
{
    public async Task<Cart?> ReturnCartItemsAsync(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(x => x.CartItems)
            .ThenInclude(e => e.Item)
            .FirstOrDefaultAsync(e => e.User.Id == id, cancellationToken);
    }
}