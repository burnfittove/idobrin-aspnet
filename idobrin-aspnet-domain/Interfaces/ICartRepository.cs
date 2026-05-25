using aspnet_domain.Entities;

namespace aspnet_domain.Interfaces;

public interface ICartRepository : IBaseRepository<Cart>
{
    public Task<Cart?> ReturnCartItemsAsync(int id, CancellationToken cancellationToken = default);
}