namespace Demo.API.Extensions;

public static class CategoriesEndpoints
{

    private static async Task<IResult> GetById(NorthwindContext context, int id)
    {
        var category = await context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.CategoryId == id);
        if (category is null) return Results.NotFound();
        return Results.Ok(new CategoriaDTO
        {
            // commento di prova
            Id = id,
            Descrizione = category.Description,
            Nome = category.CategoryName,
            NumeroProdotti = category.Products.Count()
        });
    }

    private static async Task<IResult> GetAll(NorthwindContext context)
    {
        var categories = await context.Categories
            .Select(c => new CategoriaDTO
            {
                Descrizione = c.Description,
                Id = c.CategoryId,
                Nome = c.CategoryName,
                NumeroProdotti = c.Products.Count()
            }).ToListAsync();
        return Results.Ok(categories);
    }


    public static void RegisterCategoriesEndpoint(this WebApplication app)
    {
        var group = app.MapGroup("/categories");

        group.MapGet("/", GetAll);

        group.MapGet("/{id}", GetById);

        group.MapPost("/", async (NorthwindContext context, CategoriaCreaDTO nuovaCategoria) => {
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

        group.MapDelete("/{id}", async (NorthwindContext context, int id) => {
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
        });
        group.MapPut("/{id}", async (NorthwindContext context, CategoriaModificaDTO categoriaModificata, int id) =>
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

    }
}
