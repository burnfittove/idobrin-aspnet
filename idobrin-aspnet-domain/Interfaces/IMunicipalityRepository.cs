using aspnet_domain.Entities;

namespace aspnet_domain.Interfaces;

public interface IMunicipalityRepository : IBaseRepository<Municipality>
{
    Task<Municipality?> ReturnMunicipalityWithAddresses(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Municipality>> ReturnAllMunicipalitiesWithAddresses(int id, CancellationToken cancellationToken = default);
}