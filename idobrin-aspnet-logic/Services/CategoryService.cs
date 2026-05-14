using aspnet_domain.Interfaces;
using idobrin_aspnet_logic.DTOs.Category;
using idobrin_aspnet_logic.Extensions;
using idobrin_aspnet_logic.Interfaces;

namespace idobrin_aspnet_logic.Services;

public class CategoryService(IUnitOfWork unitOfWork) : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<CategoryReturn?> ReturnByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.CategoryRepository.ReturnByIdAsync(id, cancellationToken);
        return entity.Entity2Dto();
    }

    public async Task<IEnumerable<CategoryReturn>> ReturnAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}