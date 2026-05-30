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

    public async Task<IEnumerable<AddressReturn>> ReturnAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.AddressRepository.ReturnAllAsync(cancellationToken);
        return entities.ToDtoList();
    }
}