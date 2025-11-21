using DemoMVC.Core.Entities;
using DemoMVC.Core.Interfaces;
using DemoMVC.Data.Models;
using DemoMVC.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DemoMVC.ExtensionMethods;

public static class ServicesExtensions
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllersWithViews();
        services.AddScoped<IStudentsData, MockStudentsService>();
        services.AddScoped<IWelcome, WelcomeStaticClass>();
        services.AddScoped<IMenu, MenuService>();
        services.AddScoped<IGenericData<Student, int>, StudentService>();
        services.AddScoped<IGenericData<Teacher, int>, TeacherService>();
        services.AddScoped<IGenericData<Fattura, Guid>, FattureService>();
        services.AddScoped<ICustomerData, CustomerDatabaseService>();
        services.AddScoped<ISpecialData, MockSpecialData>();
        services.AddDbContext<NorthwindContext>(options => { options.UseSqlServer(configuration.GetConnectionString("NorthwindConnectionString")); });
        services.AddScoped<IDashboard, DashboardService>();
        services.AddScoped<IData<Category>, EntityFrameworkCoreRepository<Category>>();
        services.AddScoped<IData<Product>, EntityFrameworkCoreRepository<Product>>();
        services.AddScoped<IData<Order>, EntityFrameworkCoreRepository<Order>>();
        services.AddScoped<IOrderData, OrdersService>();
    }
}
