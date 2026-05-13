using aspnet_domain.Entities.Products;

namespace aspnet_domain.Interfaces;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<Product?> ReturnProductWithCategory(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Product>> ReturnAllProductsWithCategory(int id, CancellationToken cancellationToken = default);
}