using aspnet_domain.Interfaces;
using idobrin_aspnet_logic.DTOs.Cart;
using idobrin_aspnet_logic.DTOs.CartItems;
using idobrin_aspnet_logic.DTOs.Item;
using idobrin_aspnet_logic.Extensions;
using idobrin_aspnet_logic.Interfaces;

namespace idobrin_aspnet_logic.Services;

public class CartService(IUnitOfWork unitOfWork) : ICartService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<CartReturn?> ReturnByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.CartRepository.ReturnByIdAsync(id, cancellationToken);
        return entity?.ToDto();
    }

    public async Task<IEnumerable<CartReturn?>> ReturnAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.CartRepository.ReturnAllAsync(cancellationToken);
        return entities.ToDtoList();
    }

    public async Task<CartReturn?> ReturnByUserIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.CartRepository.ReturnUserCartAsync(userId, cancellationToken);
        return entity?.ToDto();
    }

    public async Task<bool> AddItemToCartAsync(int cartId, int productId, int quantity, CancellationToken cancellationToken)
    {
        // Check if cart exists
        var cart = await ReturnByIdAsync(cartId, cancellationToken);
        if (cart == null) return false;
        
        // Check if product exists
        var product = await _unitOfWork.ProductRepository.ReturnByIdAsync(productId, cancellationToken);
        if (product == null) return false;
        
        // Create item
        var itemCreate = new ItemCreate(product.Id, quantity);
        var item = await _unitOfWork.ItemRepository.CreateAsync(itemCreate.ToEntity(), cancellationToken);
        if (item == null) return false;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        // Create cartItem
        var cartItemCreate = new CartItemCreate(cartId, item.Id);
        await _unitOfWork.CartItemsRepository.AddItemToCartAsync(cartItemCreate.ToEntity(), cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<CartReturn> CreateAsync(CartCreate cart, CancellationToken cancellationToken)
    {
        var entity = cart.ToEntity();
        await _unitOfWork.CartRepository.CreateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.ToDto();
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var entity =  await _unitOfWork.CartRepository.ReturnByIdAsync(id, cancellationToken);
        if (entity == null) return false;
        
        await _unitOfWork.CartRepository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteItemFromCartAsync(int cartId, int itemId, CancellationToken cancellationToken)
    {
        // Check if cart exists
        var cart = await ReturnByIdAsync(cartId, cancellationToken);
        if (cart == null) return false;
        
        // Check if item exists
        var item = await _unitOfWork.ItemRepository.ReturnByIdAsync(itemId, cancellationToken);
        if (item == null) return false;

        // Find CartItems record and delete it
        var cartItem = await _unitOfWork.CartItemsRepository.ReturnByIdAsync(cartId, itemId, cancellationToken);
        if (cartItem == null) return false;
        _unitOfWork.CartItemsRepository.DeleteAsync(cartItem, cancellationToken);
        
        // Delete item
        _unitOfWork.ItemRepository.DeleteAsync(item, cancellationToken);
        
        // Save changes
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}