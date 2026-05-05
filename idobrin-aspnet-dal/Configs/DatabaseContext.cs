using aspnet_domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal.Configs;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<Municipality> Municipalities { get; set; }
    public DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }
}