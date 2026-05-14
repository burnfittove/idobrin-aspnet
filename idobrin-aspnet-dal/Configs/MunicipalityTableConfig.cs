using aspnet_domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace idobrin_aspnet_dal.Configs;

public class MunicipalityTableConfig : IEntityTypeConfiguration<Municipality>
{
    public void Configure(EntityTypeBuilder<Municipality> builder)
    {
        builder.ToTable("Municipalities");
        
        // Primary key
        builder.HasKey(e => e.Id);
        
        // Parameters
        builder.Property(e => e.Name).IsRequired().IsUnicode().HasMaxLength(80);
        
        // 1-to-many relationship
        builder
            .HasOne(e => e.Country)
            .WithMany(e => e.Municipalities)
            .HasForeignKey(e => e.CountryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}