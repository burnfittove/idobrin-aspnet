using aspnet_domain.Entities;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Repositories;

public class CartRepository(DatabaseContext context) : BaseRepository<Cart>(context), ICartRepository
{
    public override async Task<Cart?> ReturnByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet.Include(e => e.CartItems)
            .ThenInclude(e => e.Item)
            .ThenInclude(e => e.Product)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public override async Task<IEnumerable<Cart>> ReturnAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet.Include(e => e.CartItems)
            .ThenInclude(e => e.Item)
            .ThenInclude(e => e.Product)
            .ToListAsync(cancellationToken);
    }

    public async Task<Cart?> ReturnUserCartAsync(int userId, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(x => x.CartItems)
            .ThenInclude(e => e.Item)
            .ThenInclude(e => e.Product)
            .FirstOrDefaultAsync(e => e.UserId == userId, cancellationToken);
    }
}