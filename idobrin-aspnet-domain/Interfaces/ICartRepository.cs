using aspnet_domain.Entities.Cart;

namespace aspnet_domain.Interfaces;

public interface ICartRepository : IBaseRepository<Cart>
{
    Task<Cart?> ReturnCartWithItems(int id, CancellationToken cancellationToken = default);
}