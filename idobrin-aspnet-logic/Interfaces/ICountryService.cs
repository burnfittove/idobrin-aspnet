using idobrin_aspnet_logic.DTOs.Country;

namespace idobrin_aspnet_logic.Interfaces;

public interface ICountryService
{
    /// <summary>
    /// Returns an entity by its ID.
    /// </summary>
    /// <param name="id">Entity ID.</param>
    /// <returns>Entity.</returns>
    Task<CountryReturn?> ReturnByIdAsync(int id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns all entities.
    /// </summary>
    /// <returns>IEnumerable&lt;Entity&gt;.</returns>
    Task<IEnumerable<CountryReturn>> ReturnAllAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Creates an entity.
    /// </summary>
    /// <param name="entity">Entity.</param>
    /// <returns>T</returns>
    Task<CountryReturn> CreateAsync(CountryCreate country, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Updates an entity.
    /// </summary>
    /// <param name="entity">Entity to update.</param>
    Task<bool> UpdateAsync(CountryUpdate country, CancellationToken cancellationToken = default);
    
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
    /// Returns a country along with all of its municipalities.
    /// </summary>
    /// <param name="id">ID of country.</param>
    /// <returns>Country with all of its municipalities.</returns>
    Task<CountryReturn?> GetAllMunicipalitiesInCountry(int id, CancellationToken cancellationToken = default);
}