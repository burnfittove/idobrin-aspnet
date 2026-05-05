using aspnet_domain.Entities;

namespace aspnet_domain.Interfaces;

public interface IBaseRepository<T> where T : Base
{
    /// <summary>
    /// Returns entity by its ID.
    /// </summary>
    /// <param name="id">ID of entity T.</param>
    /// <returns>T</returns>
    Task<T?> ReturnByIdAsync(int id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns all entities of type T.
    /// </summary>
    /// <returns>IEnumerable&lt;T&gt;.</returns>
    Task<IEnumerable<T>> ReturnAllAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Creates an entity of type T.
    /// </summary>
    /// <param name="entity">Entity T.</param>
    /// <returns>T</returns>
    Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Updates an entity.
    /// </summary>
    /// <param name="entity">Entity to update.</param>
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Deletes entity
    /// </summary>
    /// <param name="entity">Entity to delete.</param>
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Check if an entity with given id exists.
    /// </summary>
    /// <param name="id">ID to check for.</param>
    /// <returns>bool</returns>
    Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default);
}