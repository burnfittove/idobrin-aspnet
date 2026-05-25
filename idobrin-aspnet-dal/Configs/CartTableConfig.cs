using aspnet_domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace idobrin_aspnet_dal.Configs;

public class CartTableConfig : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("Carts");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired();
        builder.Property(e => e.UserId).IsRequired();
        builder
            .HasOne(e => e.User)
            .WithOne(e => e.Cart)
            .HasForeignKey<Cart>(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}