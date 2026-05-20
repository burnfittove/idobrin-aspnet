using aspnet_domain.Entities;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Repositories;

public class CategoryProductsRepository(DatabaseContext context) : ICategoryProductsRepository
{
    private readonly DbSet<CategoryProducts> DbSet = context.Set<CategoryProducts>();
    
    public Task AddProductToCategoryAsync(int categoryId, int productId, CancellationToken cancellationToken = default)
    {
        var entity = new CategoryProducts()
        {
            CategoryId = categoryId,
            ProductId = productId
        };
        DbSet.Add(entity);
        return Task.CompletedTask;
    }
}