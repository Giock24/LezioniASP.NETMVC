using DemoMVC.Core.Entities;
using DemoMVC.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Controllers;

public class TeachersController : Controller
{
    private readonly IGenericData<Teacher> _genericData;

    public TeachersController(IGenericData<Teacher> genericData)
    {
        _genericData = genericData;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(_genericData.GetAll("Cognome"));
        // return View(_studentsData.GetAll(_configuration["OrdinamentoStudenti"] ?? "Cognome" ));
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new Teacher { Id = 1 });
    }

    [HttpPost]
    public IActionResult Create(Teacher teacher)
    {
        _genericData.Create(teacher);
        return RedirectToAction("Index", "Teachers");
    }
}
