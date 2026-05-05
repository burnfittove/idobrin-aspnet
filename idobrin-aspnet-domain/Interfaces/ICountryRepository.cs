using aspnet_domain.Entities;

namespace aspnet_domain.Interfaces;

public interface ICountryRepository : IBaseRepository<Country>
{
    /// <summary>
    /// Return a country's municipalities.
    /// </summary>
    /// <param name="id"> The country id.</param>
    /// <returns>Returns a country's municipalities.</returns>
    Task<Country?> ReturnMunicipalitiesAsync(int id, CancellationToken cancellationToken = default);
}