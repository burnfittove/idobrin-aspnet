using idobrin_aspnet_logic.DTOs;

namespace idobrin_aspnet_logic.Interfaces;

public interface ICartService
{
    /// <summary>
    /// Returns an entity by its ID.
    /// </summary>
    /// <param name="id">Entity ID.</param>
    /// <returns>Entity.</returns>
    // Task<CartReturn?> ReturnByIdAsync(int id, CancellationToken cancellationToken = default);
}