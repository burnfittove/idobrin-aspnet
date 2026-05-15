using aspnet_domain.Entities;

namespace aspnet_domain.Interfaces;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<Product?> ReturnProductWithCategoriesAsync(int id, CancellationToken cancellationToken = default);
    
    Task<IEnumerable<Product>> ReturnProductsWithCategoriesAsync(CancellationToken cancellationToken = default);
}