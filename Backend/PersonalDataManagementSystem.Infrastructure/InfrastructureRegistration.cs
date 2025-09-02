using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalDataManagementSystem.Infrastructure.Persistance;

namespace PersonalDataManagementSystem.Infrastructure;

public static class InfrastructureRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection")?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        services.AddDbContext<SystemDbContext>(options =>
            options.UseNpgsql(connectionString)
        );

        return services;
    }
}
