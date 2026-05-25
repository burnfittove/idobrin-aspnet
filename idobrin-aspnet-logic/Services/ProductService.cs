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
        var entityToDelete = await _unitOfWork.ProductRepository.ReturnByIdAsync(id, cancellationToken);
        if (entityToDelete == null) return false;
        
        await _unitOfWork.ProductRepository.DeleteAsync(entityToDelete, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _unitOfWork.ProductRepository.ExistsAsync(id, cancellationToken);
    }

    public async Task<ProductReturn> CreateAsync(ProductCreate product, CancellationToken cancellationToken = default)
    {
        var entity = product.ToEntity();
        await _unitOfWork.ProductRepository.CreateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.ToDto();
    }

    public async Task<bool> UpdateAsync(int id, ProductUpdate product, CancellationToken cancellationToken = default)
    {
        if (!await ExistsAsync(id, cancellationToken)) return false;
        var entity = await _unitOfWork.ProductRepository.ReturnByIdAsync(id, cancellationToken);
        if (entity == null) return false;
        
        // Change basic attributes
        entity.Name = product.Name;
        entity.Price = product.Price;
        await _unitOfWork.ProductRepository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<ProductWithCategoriesReturn?> ReturnProductWithCategoriesAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.ProductRepository.ReturnProductWithCategoriesAsync(id, cancellationToken);
        return entity.ToProductWithCategoriesDto();
    }

    public async Task<bool> AddCategory(int id, int categoryId, CancellationToken cancellationToken)
    {
        if (!await ExistsAsync(id, cancellationToken)) return false;
        
        var category = await _unitOfWork.CategoryRepository.ReturnByIdAsync(categoryId, cancellationToken);
        if (category == null) return false;
        
        var product = await _unitOfWork.ProductRepository.ReturnByIdAsync(id, cancellationToken);
        if (product == null) return false;
        
        await _unitOfWork.CategoryProductsRepository.AddProductToCategoryAsync(category, product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> RemoveCategory(int id, int categoryId, CancellationToken cancellationToken)
    {
        if (!await ExistsAsync(id, cancellationToken)) return false;
        
        var category = await _unitOfWork.CategoryRepository.ReturnByIdAsync(categoryId, cancellationToken);
        if (category == null) return false;
        
        var product = await _unitOfWork.ProductRepository.ReturnByIdAsync(id, cancellationToken);
        if (product == null) return false;
        
        await _unitOfWork.CategoryProductsRepository.RemoveProductFromCategory(category, product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}