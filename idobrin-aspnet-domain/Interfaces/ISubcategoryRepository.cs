using aspnet_domain.Entities.Products;

namespace aspnet_domain.Interfaces;

public interface ISubcategoryRepository : IBaseRepository<Subcategory>
{
    Task<Subcategory?> ReturnSubcategoryWithProducts(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Subcategory>> ReturnAllSubcategoriesWithProducts(int id, CancellationToken cancellationToken = default);
}