using aspnet_domain.Entities;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Repositories;

public class MunicipalityRepository : BaseRepository<Municipality>, IMunicipalityRepository
{
    public MunicipalityRepository(DatabaseContext context) : base(context)
    {
    }

    public async Task<Municipality?> ReturnMunicipalityWithAddresses(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.Addresses)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Municipality>> ReturnAllMunicipalitiesWithAddresses(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.Addresses)
            .ToListAsync(cancellationToken);
    }
}