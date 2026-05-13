using aspnet_domain.Entities.Order;

namespace aspnet_domain.Interfaces;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<Order?> ReturnOrderWithItems(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Order>> ReturnAllOrdersWithItems(int id, CancellationToken cancellationToken = default);
    Task<bool> IsOrderDispatched(int id, CancellationToken cancellationToken = default);
    Task<bool> IsOrderArrived(int id, CancellationToken cancellationToken = default);
    Task<bool> IsOrderReturned(int id, CancellationToken cancellationToken = default);
}