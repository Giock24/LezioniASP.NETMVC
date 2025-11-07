using DemoMVC.Core.DTO;
using DemoMVC.Data.Models;
using DemoMVC.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoMVC.Controllers;

public class CategoriesController : Controller
{
    private readonly NorthwindContext northwindContext;

    public CategoriesController(NorthwindContext northwindContext)
    {
        this.northwindContext = northwindContext;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await northwindContext.Categories.Select(c => new CategoriaDTO { Id = c.CategoryId, Nome=c.CategoryName, Descrizione=c.Description, NumeroProdotti=c.Products.Count}).ToListAsync();

        return View(categories);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoriaCreaDTO categoriaCreaDTO)
    {
        var category = categoriaCreaDTO.ConvertToCategory();

        category.Products = new List<Product>{
            new Product
            {
                ProductName = "Mortadella"
            }
        };

        northwindContext.Categories.Add(category);
        await northwindContext.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var category = northwindContext.Categories.SingleOrDefault(x => x.CategoryId == id);

        if (category == null)
        {
            return View();
        }
        else
        {
            return View(category.ConvertToCategoriaEditDTO());
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CategoriaModificaDTO categoriaModificaDTO)
    {
        var category = new Category
        {
            CategoryId = categoriaModificaDTO.Id,
            CategoryName = categoriaModificaDTO.Nome,
            Description = categoriaModificaDTO.Descrizione
        };

        northwindContext.Categories.Update(category);
        await northwindContext.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}
