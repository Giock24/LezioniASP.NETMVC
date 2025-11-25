using DemoMVC.Core.DTO;
using DemoMVC.Core.Interfaces;
using DemoMVC.Data.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Threading.Tasks;

namespace DemoMVC.Controllers;

public class ProductsController : Controller
{
    private readonly IProductsApiData productsApiData;

    public ProductsController(IProductsApiData productsApiData)
    {
        this.productsApiData = productsApiData;
    }

    public async Task<IActionResult> Index()
    {
        var products = await productsApiData.GetAll();

        if (products == null)
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return View(products);
        }
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProdottoCreaDTO prodottoCreaDTO) {
        await productsApiData.Create(prodottoCreaDTO);

        return RedirectToAction("Index");
    }


    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await productsApiData.GetById(id);

        if (product != null)
        {
            return View(product);
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(ProdottoDTO product)
    {
        await productsApiData.Delete(product.Id);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var product = await productsApiData.GetById(id);

        if (product != null)
        {
            var dto = new ProdottoModificaDTO()
            {
                 Id = product.Id,
                 CategoriaId = product.CategoriaId,
                 FornitoreId = product.FornitoreId,
                 Nome = product.Nome,
                 PrezzoUnitario = product.PrezzoUnitario
            };

            return View(dto);
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProdottoModificaDTO prodottoModificaDTO)
    {
        await productsApiData.Update(prodottoModificaDTO);

        return RedirectToAction("");
    }
}
