using aspnet_domain.Entities;

namespace aspnet_domain.Interfaces;

public interface IMunicipalityRepository : IBaseRepository<Municipality>
{
    Task<Country?> ReturnCountryAsync(CancellationToken cancellationToken = default);
}