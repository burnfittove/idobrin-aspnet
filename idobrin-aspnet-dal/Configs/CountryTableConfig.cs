using aspnet_domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace idobrin_aspnet_dal.Configs;

public class CountryTableConfig : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries");
        
        // Define primary key
        builder.HasKey(x => x.Id);
        
        // Define parameters
        builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(64);
        
        // 1-to-many relationship (country has many municipalities, one municipality has one country)
        builder
            .HasMany(e => e.Municipalities)
            .WithOne(e => e.Country)
            .HasForeignKey(e => e.CountryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}