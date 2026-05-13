using aspnet_domain.Entities.Products;

namespace aspnet_domain.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<Category?> ReturnCategoryWithSubcategories(int id, CancellationToken cancellationToken = default);
    Task<Category?> ReturnCategoryWithSupercategory(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Category>> ReturnAllCategoriesWithSubcategories(int id, CancellationToken cancellationToken = default);
}