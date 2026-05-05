using aspnet_domain.Entities;

namespace aspnet_domain.Interfaces;

public interface IMunicipalityRepository : IBaseRepository<Municipality>
{
    Task<Municipality?> ReturnCountryAsync(int id, CancellationToken cancellationToken = default);
}