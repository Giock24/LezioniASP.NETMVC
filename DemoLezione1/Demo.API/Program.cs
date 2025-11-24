using DemoMVC.Core.DTO;
using DemoMVC.Data.Models;
using DemoMVC.Infrastructure.RandomUser.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Polly;
using System;

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
         Id = id, Descrizione = category.Description,
         Nome = category.CategoryName, NumeroProdotti =category.Products.Count()
    });
});

app.MapPost("/categories/", async (NorthwindContext context, CategoriaCreaDTO nuovaCategoria) => {
    var category = new Category { CategoryName = nuovaCategoria.Nome, Description = nuovaCategoria.Descrizione };
    context.Categories.Add(category);
    await context.SaveChangesAsync();
    return Results.Created($"/categories/{category.CategoryId}", new CategoriaDTO
    {
        Id = category.CategoryId,
        Descrizione = category.Description,
        Nome = category.CategoryName,
        NumeroProdotti = category.Products.Count()
    });
});

app.MapDelete("/categories/{id}", async(NorthwindContext context,int id) => {
    var categoryToDelete = await context.Categories.FindAsync(id);
    if (categoryToDelete is null)
    {
        return Results.NotFound();
    }
    else
    {
        context.Categories.Remove(categoryToDelete);
        await context.SaveChangesAsync();
        return Results.NoContent();
    }
} );
app.MapPut("/categories/{id}", async (NorthwindContext context, CategoriaModificaDTO categoriaModificata, int id) =>
{
    var categoryToEdit = await context.Categories.FindAsync(id);
    if (categoryToEdit is null)
    {
        return Results.NotFound();
    }
    else
    {
        if (!String.IsNullOrEmpty(categoriaModificata.Descrizione))
        {
            categoryToEdit.Description = categoriaModificata.Descrizione;
        }
        if (!String.IsNullOrEmpty(categoriaModificata.Nome))
        {
            categoryToEdit.CategoryName = categoriaModificata.Nome;
        }
        await context.SaveChangesAsync();
        return Results.NoContent();
    }
});




app.Run();

