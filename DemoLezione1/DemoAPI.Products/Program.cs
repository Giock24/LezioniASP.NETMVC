using Demo.API.Extensions;
using DemoAPI.Products.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCustomServices(builder.Configuration);

var app = builder.Build();

app.SetUpAppMiddleware();

app.Run();
