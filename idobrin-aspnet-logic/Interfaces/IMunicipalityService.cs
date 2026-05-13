using idobrin_aspnet_logic.DTOs.Municipality;

namespace idobrin_aspnet_logic.Interfaces;

public interface IMunicipalityService
{
    // <summary>
    /// Returns an entity by its ID.
    /// </summary>
    /// <param name="id">Entity ID.</param>
    /// <returns>Entity.</returns>
    Task<MunicipalityReturn?> ReturnByIdAsync(int id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns an entity by its ID along with the country it belongs to.
    /// </summary>
    /// <param name="id">Entity ID.</param>
    /// <returns>A municipality along with the country it belongs to.</returns>
    Task<MunicipalityReturnIncludeCountry?> ReturnByIdWithCountryAsync(int id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns all entities.
    /// </summary>
    /// <returns>IEnumerable&lt;Entity&gt;.</returns>
    Task<IEnumerable<MunicipalityReturn>> ReturnAllAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Creates an entity.
    /// </summary>
    /// <param name="entity">Entity.</param>
    /// <returns>T</returns>
    Task<MunicipalityReturn> CreateAsync(MunicipalityCreate country, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Updates an entity.
    /// </summary>
    /// <param name="entity">Entity to update.</param>
    Task<bool> UpdateAsync(MunicipalityUpdate country, CancellationToken cancellationToken = default);
    
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