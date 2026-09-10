using aspnet_domain.Interfaces;
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
    public async Task<IEnumerable<UserReturn?>> ReturnAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.UserRepository.ReturnAllAsync(cancellationToken);
        return entities.ToDtoList();
    }

    public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
    {
        return await  _unitOfWork.UserRepository.ExistsAsync(id, cancellationToken);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.UserRepository.ReturnByIdAsync(id, cancellationToken);
        if (entity == null) return false;
        
        await _unitOfWork.UserRepository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<UserReturn?> CreateAsync(UserCreate user, CancellationToken cancellationToken = default)
    {
        // Check for empty parameters
        if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName) || string.IsNullOrWhiteSpace(user.Username)) return null;
        // Check for existing username
        if (await UsernameExistsAsync(user.Username, cancellationToken)) return null;
        
        var entity = user.ToEntity();
        await _unitOfWork.UserRepository.CreateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.ToDto();
    }

    public async Task<bool> UpdateAsync(int id, UserUpdate user, CancellationToken cancellationToken)
    {
        // Check if the user exists
        if (!await ExistsAsync(id, cancellationToken)) return false;
        var entity = await _unitOfWork.UserRepository.ReturnByIdAsync(id, cancellationToken);
        
        // Check if the new username is already taken if it's a different username
        if (entity?.Username != user.Username)
            if (await UsernameExistsAsync(user.Username, cancellationToken)) return false;
        
        // Change entries
        entity.Username = user.Username;
        entity.FirstName = user.FirstName;
        entity.LastName = user.Lastname;
        entity.Email = user.Email;
        entity.PhoneNumber = user.PhoneNumber;

        // Finish update
        await _unitOfWork.UserRepository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken)
    {
        return await _unitOfWork.UserRepository.UsernameExistsAsync(username, cancellationToken);
    }

    public async Task<UserReturn?> ReturnByUsername(string username, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.UserRepository.ReturnByUsernameAsync(username, cancellationToken);
        return entity.ToDto();
    }

    public async Task<bool> UpdateRoleAsync(int id, UserUpdateRole user, CancellationToken cancellationToken)
    {
        if (!await ExistsAsync(id, cancellationToken)) return false;
        var entity = await _unitOfWork.UserRepository.ReturnByIdAsync(id, cancellationToken);

        entity.RoleId = user.roleId;

        await _unitOfWork.UserRepository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}