using aspnet_domain.Entities;
using idobrin_aspnet_logic.DTOs.Address;

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
    Task<IEnumerable<AddressReturn>> ReturnAllAsync(CancellationToken cancellationToken = default);
}