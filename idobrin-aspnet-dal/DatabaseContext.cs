using aspnet_domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace idobrin_aspnet_dal;

public class DatabaseContext : DbContext
{
    private DatabaseContext(DbContextOptions<DatabaseContext> options) :  base(options) { }

    public DbSet<Country> Countries { get; set; }
    public DbSet<Municipality> Municipalities { get; set; }
    public DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }
}