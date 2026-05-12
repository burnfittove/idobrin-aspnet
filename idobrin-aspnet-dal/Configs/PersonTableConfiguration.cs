using aspnet_domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace idobrin_aspnet_dal.Configs;

public class PersonTableConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Person");
        
        builder.HasKey(e => e.Id);

        builder.Property(e => e.FirstName).IsRequired().IsUnicode();
        builder.Property(e => e.Email).IsRequired().IsUnicode();
    }
}