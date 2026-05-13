using aspnet_domain.Entities.Products;

namespace aspnet_domain.Interfaces;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<Product?> ReturnProductWithSubcategory(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Product>> ReturnAllProductsWithSubcategory(int id, CancellationToken cancellationToken = default);
}