using aspnet_domain.Entities;

namespace aspnet_domain.Interfaces;

public interface ICartRepository : IBaseRepository<Cart>
{
    public IEnumerable<Cart?> ReturnUserCartAsync(int userId, CancellationToken cancellationToken = default);
}