using aspnet_domain.Entities;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Repositories;

public class ItemRepository(DatabaseContext context) : BaseRepository<Item>(context), IItemRepository
{
    public override async Task<Item?> ReturnByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.Product)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public override async Task<IEnumerable<Item>> ReturnAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.Product)
            .ToListAsync(cancellationToken);
    }
}