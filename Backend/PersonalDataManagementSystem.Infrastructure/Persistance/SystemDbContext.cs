using Microsoft.EntityFrameworkCore;
using PersonalDataManagementSystem.Domain.Entities.BusinessObjects;

namespace PersonalDataManagementSystem.Infrastructure.Persistance;

public class SystemDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<SubClient> SubClients { get; set; }

    public SystemDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SubClient>()
            .HasOne(sc => sc.Client)
            .WithMany(c => c.SubClients)
            .HasForeignKey(sc => sc.ClientId)
            .HasPrincipalKey(c => c.Id)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}
