using idobrin_aspnet_logic.DTOs.Cart;

namespace idobrin_aspnet_logic.Interfaces;

public interface ICartService
{
    /// <summary>
    /// Returns an entity by its ID.
    /// </summary>
    /// <param name="id">Entity ID.</param>
    /// <returns>Entity.</returns>
    Task<CartReturn?> ReturnByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<CartReturn?>> ReturnAllAsync(CancellationToken cancellationToken = default);

    Task<CartReturn?> ReturnByUserIdAsync(int userId, CancellationToken cancellationToken = default);
    Task<bool> AddItemToCartAsync(int cartId, int productId, int quantity, CancellationToken cancellationToken);
    Task<CartReturn> CreateAsync(CartCreate cart, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}
