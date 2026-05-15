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
    
    /// <summary>
    /// Create an entity.
    /// </summary>
    /// <param name="category"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<CategoryReturn> CreateAsync(CategoryCreate category, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Updates an entity.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="category"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(int id, CategoryUpdate category, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns a category with all of its products.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<CategoryWithProductsReturn?> ReturnCategoryWithProductsAsync(int id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns all categories and their products.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<CategoryWithProductsReturn>> ReturnAllCategoryWithProductsAsync(CancellationToken cancellationToken = default);
}