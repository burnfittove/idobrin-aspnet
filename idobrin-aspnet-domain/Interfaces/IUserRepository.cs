using aspnet_domain.Entities;

namespace aspnet_domain.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> ReturnWishlistProducts(int id, CancellationToken cancellationToken = default);
    Task<User?> ReturnCartItems(int id, CancellationToken cancellationToken = default);
    Task<User?> ReturnUserWithOrders(int id, CancellationToken cancellationToken = default);
}