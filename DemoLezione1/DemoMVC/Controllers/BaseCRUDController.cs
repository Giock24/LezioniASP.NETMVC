using DemoMVC.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Controllers;

public abstract class BaseCRUDController<TEntity, TKey> : Controller where TEntity : class, IGenericEntity<TKey>, new()
{
    protected readonly IGenericData<TEntity, TKey> repository;
    protected virtual string ViewPrefix => $"Views/{typeof(TEntity).Name}s";
    protected virtual string IndexView => $"Index";
    protected virtual string DetailsView => $"{ViewPrefix}/Details";
    protected virtual string CreateView => $"{ViewPrefix}/Create";
    protected virtual string DeleteView => $"{ViewPrefix}/Delete";
    protected virtual string EditView => $"{ViewPrefix}/Edit";

    protected BaseCRUDController(IGenericData<TEntity, TKey> repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    public virtual async Task<IActionResult> Index()
    {
        var items = await repository.GetAllAsync();
        return View(IndexView, items);
    }

    [HttpGet]
    public virtual async Task<IActionResult> Details(TKey id)
    {
        var item = await repository.GetByIdAsync(id);

        if (item != null)
        {
            return View(DetailsView, item);
        }
        else
        {
            return RedirectToAction("Index", "Home");
        }
    }

    [HttpGet]
    public virtual IActionResult Create()
    {
        return View(CreateView, new TEntity());
    }

    [HttpPost]
    public virtual async Task<IActionResult> Create(TEntity newItem)
    {
        await repository.CreateAsync(newItem);

        return RedirectToAction(IndexView);
    }

    [HttpGet]
    public virtual async Task<IActionResult> Delete(TKey id)
    {
        var item = await repository.GetByIdAsync(id);

        if (item != null)
        {
            return View(DeleteView, item);
        }

        return RedirectToAction(IndexView);
    }

    [HttpPost]
    public virtual async Task<IActionResult> Delete(TEntity item)
    {
        await repository.DeleteAsync(item.Id);

        return RedirectToAction(IndexView);
    }

    [HttpGet]
    public virtual async Task<IActionResult> Edit(TKey id)
    {
        var item = await repository.GetByIdAsync(id);

        if (item != null)
        {
            return View(EditView, item);
        }

        return RedirectToAction(IndexView);
    }

    [HttpPost]
    public virtual async Task<IActionResult> Edit(TEntity item)
    {
        await repository.EditAsync(item);

        return RedirectToAction(IndexView);
    }
}
