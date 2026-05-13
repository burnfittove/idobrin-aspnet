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

    public override async Task<Country?> ReturnByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.Municipalities)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public override async Task<IEnumerable<Country>> ReturnAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.Municipalities)
            .ToListAsync(cancellationToken);
    }
}