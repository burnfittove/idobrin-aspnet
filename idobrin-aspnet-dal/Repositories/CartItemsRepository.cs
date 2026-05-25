using aspnet_domain.Entities;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Repositories;

public class CartItemsRepository(DatabaseContext context) : ICartItemsRepository
{
    private readonly DbSet<CartItem> DbSet = context.Set<CartItem>();

    // public async Task<CartItem> ReturnCartItemsAsync(Product product, Cart cart, CancellationToken cancellationToken = default)
    // {
    //     return await DbSet.FindAsync([cart.Id, product.Id], cancellationToken);
    // }
    //
    // // public async Task<CartItem> AddItemToCartAsync(Item item, Cart cart, CancellationToken cancellationToken = default)
    // // {
    // //     var entity = new CartItem
    // //     {
    // //         CartId = cart.Id,
    // //         ItemId = item.Id,
    // //     };
    // //     await DbSet.AddAsync(entity, cancellationToken);
    // //     return entity;
    // // }
    //
    // public async Task RemoveItemFromCart(Product product, Cart cart, CancellationToken cancellationToken = default)
    // {
    //     var entity = await ReturnCartItemsAsync(item, cart, cancellationToken);
    //     DbSet.Remove(entity);
    //     await Task.CompletedTask;
    // }
    //
    // public async Task AddItemToCartAsync(Product product, Cart cart, int quantity, CancellationToken cancellationToken)
    // {
    //     var entity = new CartItem
    //     {
    //         CartId = cart.Id,
    //         ItemId = pro.Id,
    //     };
    //     await DbSet.AddAsync(entity, cancellationToken);
    //     return entity;
    // }


    public async Task<CartItem> AddItemToCartAsync(Cart cart, Item item, CancellationToken cancellationToken)
    {
        var entity = new CartItem()
        {
            CartId = cart.Id,
            ItemId = item.Id,
        };
        await DbSet.AddAsync(entity, cancellationToken);
        return entity;
    }
}