using aspnet_domain.Entities;

namespace aspnet_domain.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<Category?> ReturnCategoryWithProductsAsync(int id, CancellationToken cancellationToken = default);
    
    Task<IEnumerable<Category>> ReturnCategoriesWithProductsAsync(CancellationToken cancellationToken = default);
}