using aspnet_domain.Entities.Products;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Repositories;

public class CategoryRepository(DatabaseContext context) : BaseRepository<Category>(context), ICategoryRepository
{
    public async Task<Category?> ReturnCategoryWithSubcategories(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.Subcategories)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<Category?> ReturnCategoryWithSupercategory(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.Supercategory)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Category>> ReturnAllCategoriesWithSubcategories(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.Subcategories)
            .ToListAsync(cancellationToken);
    }
}