using aspnet_domain.Entities;

namespace aspnet_domain.Interfaces;

public interface IMunicipalityRepository : IBaseRepository<Municipality>
{
    public Task<Municipality?> ReturnByIdWithCountryAsync(int id, CancellationToken cancellationToken = default);
}