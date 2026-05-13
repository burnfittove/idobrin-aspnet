using aspnet_domain.Entities.Order;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Repositories;

public class OrderRepository(DatabaseContext context) : BaseRepository<Order>(context), IOrderRepository
{
    public async Task<Order?> ReturnOrderWithItems(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.OrderItems)
            .ThenInclude(e => e.Item)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Order>> ReturnAllOrdersWithItems(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.OrderItems)
            .ThenInclude(e => e.Item)
            .ToListAsync(cancellationToken);
    }

    public async Task<Order?> IsOrderDispatched(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<Order?> IsOrderArrived(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<Order?> IsOrderReturned(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }
}