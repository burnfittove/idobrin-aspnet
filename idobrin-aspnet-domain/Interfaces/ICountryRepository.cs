using aspnet_domain.Entities;

namespace aspnet_domain.Interfaces;

public interface ICountryRepository : IBaseRepository<Country>
{
    Task<Country?> ReturnCountryWithMunicipalities(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Country>> ReturnAllCountriesWithMunicipalities(int id, CancellationToken cancellationToken = default);
}