using System.Security.Cryptography.X509Certificates;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace PersonalDataManagementSystem.Front.Helpers;

public static class KiotaServiceCollectionExtensions
{
    public static IServiceCollection AddKiotaHandlers(this IServiceCollection services)
    {
        var kiotaHandlers = KiotaClientFactory.GetDefaultHandlerActivatableTypes();
        foreach (var h in kiotaHandlers)
        {
            services.AddTransient(h);
        }
        return services;
    }
    public static IHttpClientBuilder AttachKiotaHandlers(this IHttpClientBuilder builder)
    {
        var kiotaHandlers = KiotaClientFactory.GetDefaultHandlerActivatableTypes();

        foreach (var h in kiotaHandlers)
        {
            builder.AddHttpMessageHandler(sp => (DelegatingHandler)sp.GetRequiredService(h));
        }

        return builder;
    }
}

