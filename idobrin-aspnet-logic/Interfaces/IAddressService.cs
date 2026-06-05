using aspnet_domain.Entities;
using idobrin_aspnet_logic.DTOs.Address;
using idobrin_aspnet_logic.DTOs.Products;

namespace idobrin_aspnet_logic.Interfaces;

public interface IAddressService
{
    /// <summary>
    /// Returns an entity by its ID.
    /// </summary>
    /// <param name="id">Entity ID.</param>
    /// <returns>Entity.</returns>
    Task<AddressReturn?> ReturnByIdAsync(int id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns all entities.
    /// </summary>
    /// <returns>IEnumerable&lt;Entity&gt;.</returns>
    Task<IEnumerable<AddressReturn>> ReturnAll(CancellationToken cancellationToken = default);
    
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
    Task<AddressReturn> CreateAsync(AddressCreate address, CancellationToken cancellationToken = default);
    
    // <summary>
    /// Updates an entity.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="address"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="category"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(int id, AddressUpdate address, CancellationToken cancellationToken = default);
}