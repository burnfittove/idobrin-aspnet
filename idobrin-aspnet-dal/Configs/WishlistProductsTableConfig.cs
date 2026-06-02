using aspnet_domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace idobrin_aspnet_dal.Configs;

public class WishlistProductsTableConfig : IEntityTypeConfiguration<WishlistProducts>
{
    public void Configure(EntityTypeBuilder<WishlistProducts> builder)
    {
        builder.ToTable("WishlistProducts");

        builder.HasKey(e => new { e.WishlistId, e.ProductId });
        
        builder
            .HasOne(x => x.Wishlist)
            .WithMany(x => x.WishlistProducts)
            .HasForeignKey(x => x.WishlistId);
        
        builder
            .HasOne(x => x.Product)
            .WithMany(x => x.WishlistProducts)
            .HasForeignKey(x => x.ProductId);
    }
}