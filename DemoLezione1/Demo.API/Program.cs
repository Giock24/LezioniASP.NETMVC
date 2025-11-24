using DemoMVC.Core.DTO;
using DemoMVC.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NorthwindContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindConnectionString")); });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/hello", () => "Hello World");
app.MapGet("/categories", async (NorthwindContext context) =>
{
    var categories = await context.Categories
    .Select(c => new CategoriaDTO { Descrizione = c.Description, Id = c.CategoryId, 
     Nome = c.CategoryName, NumeroProdotti = c.Products.Count()}).ToListAsync();
    return Results.Ok(categories);
});

app.MapGet("/categories/{id}", async (NorthwindContext context, int id) => {
    var category = await context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.CategoryId == id);
    if (category is null) return Results.NotFound();
    return Results.Ok(new CategoriaDTO
    {
        // commento di prova
         Id = id, Descrizione = category.Description,
         Nome = category.CategoryName, NumeroProdotti =category.Products.Count()
    });
});




app.Run();

