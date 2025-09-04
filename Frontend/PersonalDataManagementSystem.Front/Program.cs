using Microsoft.Kiota.Abstractions.Authentication;
using PersonalDataManagementSystem.BackendClient;
using PersonalDataManagementSystem.Front.Helpers;

namespace PersonalDataManagementSystem.Front;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging.AddConsole().AddDebug();

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddSingleton<IAccessTokenProvider, SessionAccessTokenProvider>();


        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddKiotaHandlers();

        var apiUrl = builder.Configuration.GetValue<string>("BaseUrl") ?? throw new InvalidOperationException("BaseUrl element can not be found in the system configuration");

        builder.Services.AddHttpClient<ApiClientFactory>((sp, http) =>
        {
            http.BaseAddress = new Uri(apiUrl);
            http.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        })
        .AttachKiotaHandlers();

        builder.Services.AddTransient( sp =>
        {
            var factory = sp.GetRequiredService<ApiClientFactory>();
            return factory.GetClient();
        });

        builder.Services.AddSession();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseSession();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
