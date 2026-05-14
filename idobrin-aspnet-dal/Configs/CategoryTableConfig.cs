using aspnet_domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace idobrin_aspnet_dal.Configs;

public class CategoryTableConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsUnicode().IsRequired(); 
        
        // Relations (Category and Products)
        builder
            .HasMany(e => e.Subcategories)
            .WithOne(e => e.Supercategory)
            .HasForeignKey(e => e.SupercategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasMany(e => e.Products)
            .WithOne(e => e.Category)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        // builder.Navigation(e => e.Supercategory).AutoInclude();
    }
}