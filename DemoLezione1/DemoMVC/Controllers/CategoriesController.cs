using DemoMVC.Core.DTO;
using DemoMVC.Data.Models;
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
        var categories = await northwindContext.Categories.Select(c => new CategoriaDTO { Id = c.CategoryId,Nome=c.CategoryName,Descrizione=c.Description }).ToListAsync(); //.Include(c=> c.Products).ToList();

        return View(categories);
    }
}
