using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Migrations;
using idobrin_aspnet_logic.DTOs.Category;
using idobrin_aspnet_logic.Extensions;
using idobrin_aspnet_logic.Interfaces;
using CategoryUpdate = idobrin_aspnet_dal.Migrations.CategoryUpdate;

namespace idobrin_aspnet_logic.Services;

public class CategoryService(IUnitOfWork unitOfWork) : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<CategoryReturn?> ReturnByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.CategoryRepository.ReturnByIdAsync(id, cancellationToken);
        return entity.ToDto();
    }

    public async Task<IEnumerable<CategoryReturn>> ReturnAllAsync(CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.CategoryRepository.ReturnAllAsync(cancellationToken);
        return entity.ToDtoList();
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entityToDelete = await _unitOfWork.CategoryRepository.ReturnByIdAsync(id, cancellationToken);
        if (entityToDelete == null) return false;

        await _unitOfWork.CategoryRepository.DeleteAsync(entityToDelete, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _unitOfWork.CategoryRepository.ExistsAsync(id, cancellationToken);
    }

    public async Task<CategoryReturn> CreateAsync(CategoryCreate category, CancellationToken cancellationToken = default)
    {
        var entityToCreate = category.ToEntity();
        await _unitOfWork.CategoryRepository.CreateAsync(entityToCreate, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entityToCreate.ToDto();
    }

    public async Task<bool> UpdateAsync(int id, DTOs.Category.CategoryUpdate category, CancellationToken cancellationToken = default)
    {
        if (!await ExistsAsync(id, cancellationToken)) return false;
        
        var entityToUpdate = await _unitOfWork.CategoryRepository.ReturnByIdAsync(id, cancellationToken);
        if (entityToUpdate == null) return false;

        entityToUpdate.Name = category.Name;
        await _unitOfWork.CategoryRepository.UpdateAsync(entityToUpdate, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<CategoryWithProductsReturn?> ReturnCategoryWithProductsAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.CategoryRepository.ReturnCategoryWithProductsAsync(id, cancellationToken);
        return entity.ToCategoryWithProductsDto();
    }

    public async Task<IEnumerable<CategoryWithProductsReturn>> ReturnAllCategoryWithProductsAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}