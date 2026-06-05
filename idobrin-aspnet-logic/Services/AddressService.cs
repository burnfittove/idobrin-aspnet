using aspnet_domain.Interfaces;
using idobrin_aspnet_logic.DTOs.Address;
using idobrin_aspnet_logic.Extensions;
using idobrin_aspnet_logic.Interfaces;

namespace idobrin_aspnet_logic.Services;

public class AddressService(IUnitOfWork unitOfWork) : IAddressService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<AddressReturn?> ReturnByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.AddressRepository.ReturnByIdAsync(id, cancellationToken);
        return entity?.ToDto();
    }

    public async Task<IEnumerable<AddressReturn>> ReturnAll(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.AddressRepository.ReturnAllAsync(cancellationToken);
        return entities.ToDtoList();
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.AddressRepository.ReturnByIdAsync(id, cancellationToken);
        if (entity == null) return false;
        
        await _unitOfWork.AddressRepository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _unitOfWork.AddressRepository.ExistsAsync(id, cancellationToken);
    }

    public async Task<AddressReturn> CreateAsync(AddressCreate address, CancellationToken cancellationToken = default)
    {
        var entity = address.ToEntity();
        await _unitOfWork.AddressRepository.CreateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.ToDto();
    }

    public async Task<bool> UpdateAsync(int id, AddressUpdate address, CancellationToken cancellationToken = default)
    {
        if (!await ExistsAsync(id, cancellationToken)) return false;
        var entity = await _unitOfWork.AddressRepository.ReturnByIdAsync(id, cancellationToken);

        entity.AddressLine = address.AddressLine;
        entity.PostalCode = address.PostalCode;
        entity.MunicipalityId = address.MunicipalityId;

        await _unitOfWork.AddressRepository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}