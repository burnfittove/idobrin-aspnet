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
    
    Task<UserWithCartReturn>? ReturnCartByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<bool> AddItemToCart(int userId, int productId, int quantity, CancellationToken cancellationToken);
    
    Task<UserWithWishlistReturn?> ReturnWishlistById(int id, CancellationToken cancellationToken);
}