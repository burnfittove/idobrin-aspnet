using idobrin_aspnet_logic.DTOs.Category;

namespace idobrin_aspnet_logic.Interfaces;

public interface ICategoryService
{
    /// <summary>
    /// Returns an entity by its ID.
    /// </summary>
    /// <param name="id">Entity ID.</param>
    /// <returns>Entity.</returns>
    Task<CategoryReturn?> ReturnByIdAsync(int id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns all entities.
    /// </summary>
    /// <returns>IEnumerable&lt;Entity&gt;.</returns>
    Task<IEnumerable<CategoryReturn>> ReturnAllAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Deletes an entity.
    /// </summary>
    /// <param name="entity">Entity to delete.</param>
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Check if an entity with given id exists.
    /// </summary>
    /// <param name="id">ID to check for.</param>
    /// <returns>bool</returns>
    Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default);
}