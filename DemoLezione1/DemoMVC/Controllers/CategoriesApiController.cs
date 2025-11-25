using DemoMVC.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Controllers;

public class CategoriesApiController : Controller
{
    private readonly ICategoriesApiData categoriesApiData;

    public CategoriesApiController(ICategoriesApiData categoriesApiData)
    {
        this.categoriesApiData = categoriesApiData;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await categoriesApiData.GetAll();
        return View(categories);
    }
}
