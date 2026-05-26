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

    public async Task<bool> AddItemToCart(int id, int productId, int quantity, CancellationToken cancellationToken)
    {
        if (!await ExistsAsync(id, cancellationToken)) return false;
        
        // Return a product and check if it exists
        var product = await _unitOfWork.ProductRepository.ReturnByIdAsync(productId, cancellationToken);
        if (product == null) return false;
        
        // Check if cart exists
        var cartDto = await ReturnCartByIdAsync(id, cancellationToken);
        var cart = await _unitOfWork.CartRepository.ReturnByIdAsync(cartDto.Id, cancellationToken);
        if (cart == null) return false;

        var itemEntity = new ItemCreate(product.Id, quantity, product.Price * quantity);
        
        // Check if item was successfully created
        var item = await _unitOfWork.ItemRepository.CreateAsync(itemEntity.ToEntity(), cancellationToken);
        if (item == null) return false;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        //
        // Console.WriteLine($"UserService | item product id: {item.ProductId}");
        // Console.WriteLine($"UserService | item quantity: {item.Quantity}");
        //
        // // Put the item in the cart
        // // await _unitOfWork.CartItemsRepository.AddItemToCartAsync(cart, item, cancellationToken);
        // await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}