using aspnet_domain.Entities;

namespace aspnet_domain.Interfaces;

public interface ICartProductsRepository
{
    Task<CartProducts> CreateCartProductsAsync(CartProducts entity, CancellationToken cancellationToken = default);
}