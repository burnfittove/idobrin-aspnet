using aspnet_domain.Entities;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Repositories;

public class CategoryProductsRepository(DatabaseContext context) : ICategoryProductsRepository
{
    private readonly DbSet<CategoryProducts> DbSet = context.Set<CategoryProducts>();

    public async Task<CategoryProducts> ReturnCategoryProductsAsync(Category category, Product product, CancellationToken cancellationToken = default)
    {
        return await DbSet.FindAsync([category.Id, product.Id], cancellationToken);
    }

    public async Task<CategoryProducts> AddProductToCategoryAsync(Category category, Product product, CancellationToken cancellationToken = default)
    {
        var entity = new CategoryProducts()
        {
            CategoryId = category.Id,
            ProductId = product.Id
        };
        await DbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public async Task RemoveProductFromCategory(Category category, Product product, CancellationToken cancellationToken = default)
    {
        var entity = await ReturnCategoryProductsAsync(category, product, cancellationToken);
        DbSet.Remove(entity);
        await Task.CompletedTask;
    }
}