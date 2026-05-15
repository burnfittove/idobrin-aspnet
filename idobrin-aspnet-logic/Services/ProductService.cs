using aspnet_domain.Interfaces;
using idobrin_aspnet_logic.DTOs.Products;
using idobrin_aspnet_logic.Extensions;
using idobrin_aspnet_logic.Interfaces;

namespace idobrin_aspnet_logic.Services;

public class ProductService(IUnitOfWork unitOfWork) : IProductService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<ProductReturn?> ReturnByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.ProductRepository.ReturnByIdAsync(id, cancellationToken);
        return entity.ToDto();
    }

    public async Task<IEnumerable<ProductReturn>> ReturnAllAsync(CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.ProductRepository.ReturnAllAsync(cancellationToken);
        return entity.ToDtoList();
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductWithCategoriesReturn?> ReturnProductWithCategoriesAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.ProductRepository.ReturnProductWithCategoriesAsync(id, cancellationToken);
        return entity.ToProductWithCategoriesDto();
    }
}