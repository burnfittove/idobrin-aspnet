using aspnet_domain.Entities;

namespace aspnet_domain.Interfaces;

public interface IItemRepository : IBaseRepository<Item>
{
    Task<Item> CreateItemAsync(Product product, int quantity, CancellationToken cancellationToken);
}