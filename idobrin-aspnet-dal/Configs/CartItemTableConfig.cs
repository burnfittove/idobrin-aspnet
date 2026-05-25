using aspnet_domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace idobrin_aspnet_dal.Configs;

public class CartItemTableConfig : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("CartItems");
        builder.HasKey(e => new { e.CartId, e.ItemId});
        
        builder
            .HasOne(e => e.Cart)
            .WithMany(e => e.CartItems)
            .HasForeignKey(e => e.CartId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasOne(e => e.Item)
            .WithMany(e => e.CartItems)
            .HasForeignKey(e => e.ItemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}