using DemoMVC.Core.DTO;
using DemoMVC.Core.Interfaces;
using DemoMVC.Data.Models;
using DemoMVC.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DemoMVC.Controllers;

public class CategoriesController : Controller
{
    private readonly IData<Category> repository;

    public CategoriesController(IData<Category> repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await repository.GetAll().ToListAsync();

        return View(categories.ConvertiInListaDTO());
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

        await repository.CreateAsync(category);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var category = await repository.GetByIdAsync(id);

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

        await repository.EditAsync(category);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await repository.GetByIdAsync(id);

        if (category != null)
        {
            return View(category);
        }

        return RedirectToAction("Index", "Categories");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(Category category)
    {
        await repository.DeleteAsync(category.CategoryId);

        return RedirectToAction("Index", "Categories");
    }
}
