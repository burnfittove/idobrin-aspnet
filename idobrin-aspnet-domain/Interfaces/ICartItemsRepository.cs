using aspnet_domain.Entities;

namespace aspnet_domain.Interfaces;

public interface ICartItemsRepository
{
//     Task<CartItem> ReturnCartItemsAsync(Product product, Cart cart, CancellationToken cancellationToken = default);
//     Task RemoveItemFromCart(Product product, Cart cart, CancellationToken cancellationToken = default);
//     Task AddItemToCartAsync(Product product, Cart cart, int quantity, CancellationToken cancellationToken);
    Task<CartItem> AddItemToCartAsync(Cart cart, Item item, CancellationToken cancellationToken);
}