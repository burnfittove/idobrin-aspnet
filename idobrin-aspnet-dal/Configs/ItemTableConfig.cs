using aspnet_domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace idobrin_aspnet_dal.Configs;

public class ItemTableConfig : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("Items");
        
        builder.HasKey(e => e.Id);
        
        builder
            .HasOne(e => e.Product)
            .WithMany(e  => e.Items)
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}