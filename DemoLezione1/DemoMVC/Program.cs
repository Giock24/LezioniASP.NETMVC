using DemoMVC.Core.Entities;
using DemoMVC.Core.Interfaces;
using DemoMVC.Data.Models;
using DemoMVC.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IStudentsData, MockStudentsService>();
builder.Services.AddScoped<IWelcome, WelcomeStaticClass>();
builder.Services.AddScoped<IMenu, MenuService>();
builder.Services.AddScoped<IGenericData<Student, int>, StudentService>();
builder.Services.AddScoped<IGenericData<Teacher, int>, TeacherService>();
builder.Services.AddScoped<IGenericData<Fattura, Guid>, FattureService>();
builder.Services.AddScoped<ICustomerData, CustomerDatabaseService>();
builder.Services.AddScoped<ISpecialData, MockSpecialData>();
builder.Services.AddDbContext<NorthwindContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindConnectionString")); });
builder.Services.AddScoped<IDashboard, DashboardService>();
//builder.Services.AddScoped<IGenericData<Student>, GenericMockData<Student>>();
//builder.Services.AddScoped<IGenericData<Teacher>, GenericMockData<Teacher>>();

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

//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
