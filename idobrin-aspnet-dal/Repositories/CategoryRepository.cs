using aspnet_domain.Entities;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Repositories;

public class CategoryRepository(DatabaseContext context) : BaseRepository<Category>(context), ICategoryRepository
{
    public async Task<Category?> ReturnCategoryWithProductsAsync(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.CategoryProducts)
            .ThenInclude(e => e.Product)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Category>> ReturnCategoriesWithProductsAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.CategoryProducts)
            .ThenInclude(e => e.Product)
            .ToListAsync(cancellationToken);
    }
}