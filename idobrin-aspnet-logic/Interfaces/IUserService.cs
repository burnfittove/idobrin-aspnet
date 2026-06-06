using idobrin_aspnet_logic.DTOs;
using idobrin_aspnet_logic.DTOs.User;

namespace idobrin_aspnet_logic.Interfaces;

public interface IUserService
{
    /// <summary>
    /// Returns an entity by its ID.
    /// </summary>
    /// <param name="id">Entity ID.</param>
    /// <returns>Entity.</returns>
    Task<UserReturn?> ReturnByIdAsync(int id, CancellationToken cancellationToken = default);
    
    Task<IEnumerable<UserReturn?>> ReturnAllAsync(CancellationToken cancellationToken = default);
    
    Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<UserReturn?> CreateAsync(UserCreate user, CancellationToken cancellationToken);
    Task<bool?> UpdateAsync(int id, UserUpdate user, CancellationToken cancellationToken);
    Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken);
    
    Task<UserReturn?> ReturnByUsername(string username, CancellationToken cancellationToken = default);
}