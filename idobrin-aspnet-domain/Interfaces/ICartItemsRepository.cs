using aspnet_domain.Entities;

namespace aspnet_domain.Interfaces;

public interface ICartItemsRepository
{
//     Task<CartItem> ReturnCartItemsAsync(Product product, Cart cart, CancellationToken cancellationToken = default);
//     Task RemoveItemFromCart(Product product, Cart cart, CancellationToken cancellationToken = default);
//     Task AddItemToCartAsync(Product product, Cart cart, int quantity, CancellationToken cancellationToken);
    Task<CartItem?> FindByItemIdAsync(int itemId, CancellationToken cancellationToken);
    Task<CartItem?> FindByCartIdAsync(int cartId, CancellationToken cancellationToken);
    Task<CartItem?> ReturnByIdAsync(int cartId, int itemId, CancellationToken cancellationToken);
    Task<CartItem> AddItemToCartAsync(CartItem cartItem, CancellationToken cancellationToken);
    Task DeleteAsync(CartItem cartItem, CancellationToken cancellationToken);
}