using aspnet_domain.Entities;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Repositories;

public class CountryRepository : BaseRepository<Country>, ICountryRepository
{
    public CountryRepository(DatabaseContext context) : base(context)
    {
    }

    public async Task<Country?> ReturnMunicipalitiesAsync(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.Municipalities)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }
}