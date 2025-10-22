using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Controllers;

[Route("cucina")]
public class CucinaController : Controller
{

    [Route("{name}")]
    public IActionResult Ricerca(string name)
    {
        //return Content($"Ciao dalla Cucina! {name}");
        //return Json(new { Nome = name, Versione = "v1" });

        if (name.Length > 8)
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return Json(new { Nome = name, Versione = "v1" });
        }
    }

    [Route("index/v1/{id}")]
    public IActionResult Index(string id)
    {
        return Content($"Ciao da Index {id}");
    }

    [Route("index/v2/{id}")]
    public IActionResult Index2(string id)
    {
        return Content($"Ciao da Index2 {id}");
    }
}
