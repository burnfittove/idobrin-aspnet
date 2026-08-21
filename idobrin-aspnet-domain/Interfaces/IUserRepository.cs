using aspnet_domain.Entities;

namespace aspnet_domain.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> ReturnUserWithCartById(int id, CancellationToken cancellationToken);
    Task<User> ReturnUserWithWishlistById(int id, CancellationToken cancellationToken);
    Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken);
    Task<User> ReturnByUsernameAsync(string username, CancellationToken cancellationToken);
}