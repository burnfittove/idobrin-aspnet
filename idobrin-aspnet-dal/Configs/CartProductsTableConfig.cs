using aspnet_domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace idobrin_aspnet_dal.Configs;

public class CartProductsTableConfig : IEntityTypeConfiguration<CartProducts>
{
    public void Configure(EntityTypeBuilder<CartProducts> builder)
    {
        builder.ToTable("CartProducts");
        
        builder.HasKey(e => new { e.CartId, e.ProductId });
        
        builder
            .HasOne(e => e.Cart)
            .WithMany(e => e.CartProducts)
            .HasForeignKey(e => e.CartId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasOne(e => e.Product)
            .WithMany(e => e.CartProducts)
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}