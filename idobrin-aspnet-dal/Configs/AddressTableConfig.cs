using aspnet_domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace idobrin_aspnet_dal.Configs;

public class AddressTableConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.PostalCode).IsRequired();
        
        builder
            .HasOne(x => x.Municipality)
            .WithMany(x => x.Addresses)
            .HasForeignKey(x => x.MunicipalityId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasOne(x => x.User)
            .WithOne(x => x.Address)
            .OnDelete(DeleteBehavior.Cascade);
    }
}