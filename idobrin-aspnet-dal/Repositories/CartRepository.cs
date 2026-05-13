using aspnet_domain.Entities.Cart;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Repositories;

public class CartRepository(DatabaseContext context) : BaseRepository<Cart>(context), ICartRepository
{
    public async Task<Cart?> ReturnCartWithItems(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.CartItems)
            .ThenInclude(e => e.Item)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<Cart?> ReturnTotalPrice(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }
}