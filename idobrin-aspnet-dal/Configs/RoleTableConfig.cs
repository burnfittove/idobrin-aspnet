using aspnet_domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace idobrin_aspnet_dal.Configs;

public class RoleTableConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
        
        builder.HasKey(x => x.Id);
    }
}