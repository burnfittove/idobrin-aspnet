using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Repositories;
using idobrin_aspnet_logic.DTOs.Municipality;
using idobrin_aspnet_logic.Extensions;
using idobrin_aspnet_logic.Interfaces;

namespace idobrin_aspnet_logic.Services;

public class MunicipalityService(IUnitOfWork unitOfWork) : IMunicipalityService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<MunicipalityReturn?> ReturnByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.MunicipalityRepository.ReturnByIdAsync(id, cancellationToken);
        return entity.ToDto();
    }

    public async Task<MunicipalityReturnIncludeCountry?> ReturnByIdWithCountryAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.MunicipalityRepository.ReturnByIdWithCountryAsync(id, cancellationToken);
        return entity.toMunicipalityWithCountryDto();
    }

    public async Task<IEnumerable<MunicipalityReturn>> ReturnAllAsync(CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.MunicipalityRepository.ReturnAllAsync(cancellationToken);
        return entity.ToDtoList();
    }

    public async Task<MunicipalityReturn> CreateAsync(MunicipalityCreate country, CancellationToken cancellationToken = default)
    {
        var entity = country.ToEntity();
        await _unitOfWork.MunicipalityRepository.CreateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.ToDto();
    }

    public async Task<bool> UpdateAsync(MunicipalityUpdate country, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.MunicipalityRepository.ReturnByIdAsync(country.Id, cancellationToken);
        if (entity == null) return false;
        
        entity.Name = country.Name;
        entity.CountryId = country.CountryId;
        
        await _unitOfWork.MunicipalityRepository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity =  await _unitOfWork.MunicipalityRepository.ReturnByIdAsync(id, cancellationToken);
        if (entity == null) return false;
        
        await _unitOfWork.MunicipalityRepository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _unitOfWork.MunicipalityRepository.ExistsAsync(id, cancellationToken);
    }
}