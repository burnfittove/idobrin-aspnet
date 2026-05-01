using aspnet_domain.Entities;

namespace aspnet_domain.Interfaces;

public interface ICountryRepository : IBaseRepository<Country>
{
    Task<IEnumerable<Municipality>> ReturnMunicipalitiesAsync(CancellationToken cancellationToken = default);
}