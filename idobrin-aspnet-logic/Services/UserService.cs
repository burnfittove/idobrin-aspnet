using aspnet_domain.Interfaces;
using idobrin_aspnet_logic.DTOs.Item;
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

    public async Task<UserWithCartReturn>? ReturnCartByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.UserRepository.ReturnUserWithCartById(id, cancellationToken);
        return entity.Cart == null ? null : entity.ToUserWithCartDto();
    }

    public async Task<bool> AddItemToCart(int userId, int productId, int quantity, CancellationToken cancellationToken)
    {
        // Check if user exists
        if (!await ExistsAsync(userId, cancellationToken)) return false;
        
        // Check if user's cart exists
        var cartDto = await ReturnCartByIdAsync(userId, cancellationToken);
        var cart = await _unitOfWork.CartRepository.ReturnByIdAsync(cartDto.Id, cancellationToken);
        if (cart == null) return false;
        
        // Return a product and check if it exists
        var product = await _unitOfWork.ProductRepository.ReturnByIdAsync(productId, cancellationToken);
        if (product == null) return false;
        
        // Create item and check if it was successfully created
        var itemEntity = await _unitOfWork.ItemRepository.CreateItemAsync(product, quantity, cancellationToken);
        if (itemEntity == null) return false;
        
        // Create the cart<->item pairing
        await _unitOfWork.CartItemsRepository.AddItemToCartAsync(cart, itemEntity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<UserWithWishlistReturn?> ReturnWishlistById(int id, CancellationToken cancellationToken)
    {
        // Check if user exists
        if (!await ExistsAsync(id, cancellationToken)) return null;
        
        var entity = await _unitOfWork.UserRepository.ReturnUserWithWishlistById(id, cancellationToken);
        return entity.ToUserWithWishlistDto();
    }
}