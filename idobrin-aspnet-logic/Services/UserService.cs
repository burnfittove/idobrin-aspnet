using aspnet_domain.Interfaces;
using idobrin_aspnet_logic.DTOs;
using idobrin_aspnet_logic.DTOs.User;
using idobrin_aspnet_logic.Extensions;
using idobrin_aspnet_logic.Interfaces;

namespace idobrin_aspnet_logic.Services;

public class UserService(IUnitOfWork unitOfWork) : IUserService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<UserReturn?> ReturnByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.UserRepository.ReturnByIdAsync(id, cancellationToken);
        return entity.ToDto();
    }

    public async Task<CartReturn>? ReturnCartByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.CartRepository.ReturnUsersCartAsync(id, cancellationToken);
        return entity.ToDto();
    }
}