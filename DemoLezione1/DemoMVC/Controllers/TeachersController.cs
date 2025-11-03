//using DemoMVC.Core.Entities;
//using DemoMVC.Core.Interfaces;
//using Microsoft.AspNetCore.Mvc;

//namespace DemoMVC.Controllers;

//public class TeachersController : Controller
//{
//    private readonly IGenericData<Teacher> genericData;

//    public TeachersController(IGenericData<Teacher> genericData)
//    {
//        this.genericData = genericData;
//    }

//    [HttpGet]
//    public IActionResult Index()
//    {
//        return View(genericData.GetAll("Cognome"));
//        //return View(studentsData.GetAll(configuration["OrdinamentoStudenti"] ?? "Cognome"));
//    }

//    [HttpGet]
//    public IActionResult Create()
//    {
//        return View(new Teacher { Id = 1 });
//    }

//    [HttpPost]
//    public IActionResult Create(Teacher teacher)
//    {
//        genericData.Create(teacher);

//        return RedirectToAction("Index", "Teachers");
//    }
//}
