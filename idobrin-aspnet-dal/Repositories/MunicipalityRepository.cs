using aspnet_domain.Entities;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Repositories;

public class MunicipalityRepository(DatabaseContext context)
    : BaseRepository<Municipality>(context), IMunicipalityRepository
{
    public async Task<Municipality?> ReturnCountryAsync(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.Country)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }
}