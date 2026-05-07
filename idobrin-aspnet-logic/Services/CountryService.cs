using idobrin_aspnet_dal.Repositories;
using idobrin_aspnet_logic.DTOs.Country;
using idobrin_aspnet_logic.Extensions;
using idobrin_aspnet_logic.Interfaces;

namespace idobrin_aspnet_logic.Services;

public class CountryService(UnitOfWork unitOfWork) : ICountryService
{
    private readonly UnitOfWork _unitOfWork = unitOfWork;
    
    /// <summary>
    /// Uses UnitOfWork to access the necessary repository and return an entity by its id.
    /// </summary>
    /// <param name="id">Entity ID to search for.</param>
    /// <returns>CountryReturn DTO.</returns>
    public async Task<CountryReturn?> ReturnByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.CountryRepository.ReturnByIdAsync(id, cancellationToken);
        return entity.Entity2Dto();
    }

    /// <summary>
    /// Uses UnitOfWork to access the necessary repository and return all instances of entity.
    /// </summary>
    /// <returns>An IEnumerable containing one or more CountryReturn DTOs.</returns>
    public async Task<IEnumerable<CountryReturn>> ReturnAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.CountryRepository.ReturnAllAsync(cancellationToken);
        return entities.EntityList2DtoList();
    }

    /// <summary>
    /// Uses UnitOfWork to access the necessary repository and create a new row with entity.
    /// </summary>
    /// <param name="country">Entity which to add to the database.</param>
    /// <returns>The added entity.</returns>
    public async Task<CountryReturn> CreateAsync(CountryCreate country, CancellationToken cancellationToken = default)
    {
        var entity = country.Dto2Entity();
        var returnEntity = await _unitOfWork.CountryRepository.CreateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return returnEntity.Entity2Dto();
    }

    public async Task<bool> UpdateAsync(CountryUpdate country, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.CountryRepository.ReturnByIdAsync(country.Id, cancellationToken);
        if (entity == null) return false;
        
        entity.Name = country.Name;
        await _unitOfWork.CountryRepository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.CountryRepository.ReturnByIdAsync(id, cancellationToken);
        if (entity == null) return false;
        
        await _unitOfWork.CountryRepository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _unitOfWork.CountryRepository.ExistsAsync(id, cancellationToken);
    }

    public async Task<CountryReturn?> GetAllMunicipalitiesInCountry(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.CountryRepository.ReturnMunicipalitiesAsync(id, cancellationToken);
        return entity.Entity2Dto();
    }
}