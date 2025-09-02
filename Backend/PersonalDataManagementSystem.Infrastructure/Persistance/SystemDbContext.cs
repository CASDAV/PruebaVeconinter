using Microsoft.EntityFrameworkCore;

namespace PersonalDataManagementSystem.Infrastructure.Persistance;

public class SystemDbContext : DbContext
{
    public SystemDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
    }
}
