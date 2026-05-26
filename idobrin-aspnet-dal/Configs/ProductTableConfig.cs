using aspnet_domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace idobrin_aspnet_dal.Configs;

public class ProductTableConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        
        builder.HasKey(e => e.Id);
        
        builder
            .HasMany(e => e.Items)
            .WithOne(e => e.Product)
            .OnDelete(DeleteBehavior.Cascade);
    }
}