using aspnet_domain.Entities;

namespace aspnet_domain.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> ReturnUserWithCartById(int id, CancellationToken cancellationToken);
}