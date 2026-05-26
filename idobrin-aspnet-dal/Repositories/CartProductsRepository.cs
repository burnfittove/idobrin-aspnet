using aspnet_domain.Entities;
using aspnet_domain.Interfaces;
using idobrin_aspnet_dal.Configs;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Repositories;

public class CartProductsRepository(DatabaseContext context) : ICartProductsRepository
{
    private readonly DbSet<CartProducts> DbSet = context.Set<CartProducts>();
    
    public async Task<CartProducts> CreateCartProductsAsync(CartProducts entity, CancellationToken cancellationToken = default)
    {
        await DbSet.AddAsync(entity, cancellationToken);
        return entity;
    }
}