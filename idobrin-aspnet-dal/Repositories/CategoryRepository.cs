using aspnet_domain.Entities;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Repositories;

public class CategoryRepository(DatabaseContext context) : BaseRepository<Category>(context), ICategoryRepository
{
    public override async Task<Category?> ReturnByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.Subcategories)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }
}