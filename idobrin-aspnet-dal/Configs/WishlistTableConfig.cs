using aspnet_domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace idobrin_aspnet_dal.Configs;

public class WishlistTableConfig : IEntityTypeConfiguration<Wishlist>
{
    public void Configure(EntityTypeBuilder<Wishlist> builder)
    {
        builder.ToTable("Wishlists");
        
        builder.HasKey(x => x.Id);
        
        builder
            .HasOne(x => x.User)
            .WithOne(x => x.Wishlist)
            .HasForeignKey<Wishlist>(x => x.UserId);
    }
}