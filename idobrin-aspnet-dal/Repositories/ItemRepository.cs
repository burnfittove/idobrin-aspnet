using aspnet_domain.Entities;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Repositories;

public class ItemRepository(DatabaseContext context) : BaseRepository<Item>(context), IItemRepository
{
    public override async Task<Item?> ReturnByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.Product)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public override async Task<IEnumerable<Item>> ReturnAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(e => e.Product)
            .ToListAsync(cancellationToken);
    }

    public async Task<Item> CreateItemAsync(Product product, int quantity, CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"ItemRepository | ProductID: {product.Id}");
        Console.WriteLine($"ItemRepository | Quantity: {quantity}");
        Console.WriteLine($"ItemRepository | TotalPrice: {product.Price * quantity}");
        
        var entity = new Item
        {
            ProductId = product.Id,
            Quantity = quantity,
            TotalPrice = product.Price * quantity
        };
        Console.WriteLine($"ItemRepository | item's product id: {entity.ProductId}");
        await DbSet.AddAsync(entity, cancellationToken);
        Console.WriteLine($"ItemRepository | item's product id: {entity.ProductId}");
        Console.WriteLine($"ItemRepository | item's quantity: {entity.Quantity}");
        Console.WriteLine($"ItemRepository | item's price: {entity.TotalPrice}");
        return entity;
    }
}