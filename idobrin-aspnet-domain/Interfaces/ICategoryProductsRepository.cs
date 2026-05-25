using aspnet_domain.Entities;

namespace aspnet_domain.Interfaces;

public interface ICategoryProductsRepository
{
    Task<CategoryProducts> ReturnCategoryProductsAsync(Category category, Product product, CancellationToken cancellationToken = default);
    Task<CategoryProducts> AddProductToCategoryAsync(Category category, Product product, CancellationToken cancellationToken = default);
    Task RemoveProductFromCategory(Category category, Product product, CancellationToken cancellationToken = default);
}