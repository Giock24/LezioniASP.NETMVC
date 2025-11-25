using DemoMVC.Data.Models;

namespace Demo.API.Extensions;

public static class RegisterServices
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services, 
        IConfiguration configuration)
    {
        // Add services to the container.
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<NorthwindContext>(options => { options.UseSqlServer(configuration.GetConnectionString("NorthwindConnectionString")); });
        services.AddMemoryCache();

        return services;
    }
}
