using aspnet_domain.Entities;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Repositories;

public class CountryRepository(DatabaseContext context) : BaseRepository<Country>(context), ICountryRepository
{
    public async Task<Country?> ReturnCountryWithMunicipalities(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.Municipalities)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Country>> ReturnAllCountriesWithMunicipalities(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.Municipalities)
            .ToListAsync(cancellationToken);
    }
}