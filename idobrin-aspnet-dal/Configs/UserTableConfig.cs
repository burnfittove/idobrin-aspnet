using aspnet_domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace idobrin_aspnet_dal.Configs;

public class UserTableConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        
        builder.HasKey(e => e.Id);

        builder.Property(e => e.FirstName).IsUnicode().IsRequired();
        builder.Property(e => e.LastName).IsUnicode().IsRequired();
        builder.Property(e => e.Email).IsUnicode().IsRequired();
    }
}