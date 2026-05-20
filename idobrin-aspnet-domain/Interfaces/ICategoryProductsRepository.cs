namespace aspnet_domain.Interfaces;

public interface ICategoryProductsRepository
{
    Task AddProductToCategoryAsync(int categoryId, int productId, CancellationToken cancellationToken = default);
}