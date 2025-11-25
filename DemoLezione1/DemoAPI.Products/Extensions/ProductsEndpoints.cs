namespace DemoAPI.Products.Extensions;

public static class ProductsEndpoints
{

    private static async Task<IResult> GetById(NorthwindContext context, int id)
    {
        var product = await context.Products.FirstOrDefaultAsync(c => c.ProductId == id);
        if (product is null) return Results.NotFound();
        return Results.Ok(new ProdottoDTO
        {
            Id = product.ProductId,
            Nome = product.ProductName,
            FornitoreId = product.SupplierId,
            CategoriaId = product.CategoryId,
            PrezzoUnitario = product.UnitPrice
        });
    }

    private static async Task<IResult> GetAll(NorthwindContext context)
    {
        var products = await context.Products
            .Select(c => new ProdottoDTO
            {
                Id = c.ProductId,
                Nome = c.ProductName,
                FornitoreId = c.SupplierId,
                CategoriaId = c.CategoryId,
                PrezzoUnitario = c.UnitPrice
            }).ToListAsync();
        return Results.Ok(products);
    }

    private static async Task<IResult> Create(NorthwindContext context, ProdottoCreaDTO nuovoProdotto)
    {
        var product = new Product
        {
            ProductName = nuovoProdotto.Nome,
            SupplierId = nuovoProdotto.FornitoreId,
            CategoryId = nuovoProdotto.CategoriaId
        };
        context.Products.Add(product);
        await context.SaveChangesAsync();
        return Results.Created($"/products/{product.ProductId}", new ProdottoDTO
        {
            Id = product.ProductId,
            Nome = product.ProductName,
            FornitoreId = product.SupplierId,
            CategoriaId = product.CategoryId,
            PrezzoUnitario = product.UnitPrice
        });
    }

    private static async Task<IResult> Delete(NorthwindContext context, int id)
    {
        var productToDelete = await context.Products.FindAsync(id);
        if (productToDelete is null)
        {
            return Results.NotFound();
        }
        else
        {
            context.Products.Remove(productToDelete);
            await context.SaveChangesAsync();
            return Results.NoContent();
        }
    }

    private static async Task<IResult> Put(NorthwindContext context, int id, ProdottoModificaDTO prodottoModificato)
    {
        var productToEdit = await context.Products.FindAsync(id);
        if (productToEdit is null)
        {
            return Results.NotFound();
        }
        else
        {
            if (!String.IsNullOrEmpty(prodottoModificato.Nome))
            {
                productToEdit.ProductName = prodottoModificato.Nome;
            }
            if (prodottoModificato.FornitoreId.HasValue)
            {
                productToEdit.SupplierId = prodottoModificato.FornitoreId.Value;
            }
            if (prodottoModificato.CategoriaId.HasValue)
            {
                productToEdit.CategoryId = prodottoModificato.CategoriaId.Value;
            }
            await context.SaveChangesAsync();
            return Results.NoContent();
        }
    }
    public static void RegisterProductsEndpoint(this WebApplication app)
    {
        var group = app.MapGroup("/products");

        group.MapGet("/", GetAll);

        group.MapGet("/{id}", GetById);

        group.MapPost("/", Create);

        group.MapDelete("/{id}", Delete);

        group.MapPut("/{id}", Put);
    }
}
