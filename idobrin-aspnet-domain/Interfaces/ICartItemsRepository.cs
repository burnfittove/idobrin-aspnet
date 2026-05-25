using aspnet_domain.Entities;

namespace aspnet_domain.Interfaces;

public interface ICartItemsRepository
{
    Task<CartItem> ReturnCartItemsAsync(Item item, Cart cart, CancellationToken cancellationToken = default);
    Task<CartItem> AddItemToCartAsync(Item item, Cart cart, CancellationToken cancellationToken = default);
    Task RemoveItemFromCart(Item item, Cart cart, CancellationToken cancellationToken = default);
}