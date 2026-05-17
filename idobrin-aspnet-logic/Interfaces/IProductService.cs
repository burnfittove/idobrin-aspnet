using idobrin_aspnet_logic.DTOs.Products;

namespace idobrin_aspnet_logic.Interfaces;

public interface IProductService
{
    /// <summary>
    /// Returns an entity by its ID.
    /// </summary>
    /// <param name="id">Entity ID.</param>
    /// <returns>Entity.</returns>
    Task<ProductReturn?> ReturnByIdAsync(int id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns all entities.
    /// </summary>
    /// <returns>IEnumerable&lt;Entity&gt;.</returns>
    Task<IEnumerable<ProductReturn>> ReturnAllAsync(CancellationToken cancellationToken = default);
    
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
    Task<ProductReturn> CreateAsync(ProductCreate product, CancellationToken cancellationToken = default);
    
    // <summary>
    /// Updates an entity.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="category"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(int id, ProductUpdate product, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns a category with all of its products.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ProductWithCategoriesReturn?> ReturnProductWithCategoriesAsync(int id, CancellationToken cancellationToken = default);
}