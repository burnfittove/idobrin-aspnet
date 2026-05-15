using aspnet_domain.Entities;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Repositories;

public class ProductRepository(DatabaseContext context) : BaseRepository<Product>(context), IProductRepository
{
    public async Task<Product?> ReturnProductWithCategoriesAsync(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.CategoryProducts)
            .ThenInclude(e => e.Category)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Product>> ReturnProductsWithCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.CategoryProducts)
            .ThenInclude(e => e.Category)
            .ToListAsync(cancellationToken);
    }
}