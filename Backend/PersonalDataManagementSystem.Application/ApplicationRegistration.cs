using Microsoft.Extensions.DependencyInjection;
using PersonalDataManagementSystem.Application.Mapper;
using PersonalDataManagementSystem.Application.UseCases.Commands.Clients;
using PersonalDataManagementSystem.Application.UseCases.Commands.SubClients;
using PersonalDataManagementSystem.Application.UseCases.Queries.Clients;
using PersonalDataManagementSystem.Application.UseCases.Queries.SubClients;

namespace PersonalDataManagementSystem.Application;

public static class ApplicationRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        services.AddAutoMapper(c => {},typeof(MappingProfile));

        services.AddScoped<CreateClient>();
        services.AddScoped<DeleteClient>();
        services.AddScoped<UpdateClient>();
        services.AddScoped<GetClients>();
        services.AddScoped<GetClientById>();
        services.AddScoped<CreateSubClient>();
        services.AddScoped<DeleteSubClient>();
        services.AddScoped<UpdateSubClient>();
        services.AddScoped<GetSubClients>();
        services.AddScoped<GetSubClientById>();

        return services;
    }
}
