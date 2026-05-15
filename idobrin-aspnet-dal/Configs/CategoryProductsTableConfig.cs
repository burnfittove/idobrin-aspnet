using aspnet_domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace idobrin_aspnet_dal.Configs;

public class CategoryProductsTableConfig : IEntityTypeConfiguration<CategoryProducts>
{
    public void Configure(EntityTypeBuilder<CategoryProducts> builder)
    {
        builder.ToTable("CategoryProducts");
        
        builder.HasKey(e => new { e.CategoryId, e.ProductId });
        
        builder.HasOne(e => e.Category)
            .WithMany(e => e.CategoryProducts)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(e => e.Product)
            .WithMany(e => e.CategoryProducts)
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}