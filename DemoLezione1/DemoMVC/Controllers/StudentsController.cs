//using DemoMVC.Core.Entities;
//using DemoMVC.Core.Interfaces;
//using DemoMVC.Infrastructure.Services;
//using Microsoft.AspNetCore.Mvc;

using DemoMVC.Core.Entities;
using DemoMVC.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Controllers;

public class StudentsController : BaseCRUDController<Student, int>
{
    public StudentsController(IGenericData<Student, int> repository) : base(repository)
    {
    }

    public JsonResult GetJSon()
    {
        return new JsonResult(new
        {
            Saluto = "Ciaone"
        });
    }
}

//public class StudentsController : Controller
//{
//    private readonly IStudentsData studentsData;
//    private readonly IConfiguration configuration;
//    private readonly IGenericData<Student> genericData;

//    public StudentsController(IStudentsData studentsData, IConfiguration configuration, IGenericData<Student> genericData)
//    {
//        this.studentsData = studentsData;
//        this.configuration = configuration;
//        this.genericData = genericData;
//    }

//    [HttpGet]
//    public IActionResult Index()
//    {
//        return View(genericData.GetAll(configuration["OrdinamentoStudenti"] ?? "Cognome"));
//        //return View(studentsData.GetAll(configuration["OrdinamentoStudenti"] ?? "Cognome"));
//    }

//    [HttpGet]
//    public IActionResult Details(int id)
//    {
//        var student = studentsData.Get(id);

//        if (student != null)
//        {
//            return View(student);
//        }
//        else
//        {
//            return RedirectToAction("Index", "Home");
//        }
//    }

//    [HttpGet]
//    public IActionResult Create()
//    {
//        return View();
//    }

//    [HttpPost]
//    public IActionResult Create(Student student)
//    {
//        genericData.Create(student);

//        return RedirectToAction("Index", "Students");
//    }

//    [HttpGet]
//    public IActionResult Delete(int id)
//    {
//        var student = studentsData.Get(id);

//        if (student != null)
//        {
//            return View(student);
//        }

//        return RedirectToAction("Index", "Students");
//    }

//    [HttpPost]
//    public IActionResult Delete(Student student)
//    {
//        studentsData.Delete(student.Id);

//        return RedirectToAction("Index", "Students");
//    }

//    [HttpGet]
//    public IActionResult Edit(int id)
//    {
//        var student = studentsData.Get(id);

//        if (student != null)
//        {
//            return View(student);
//        }

//        return RedirectToAction("Index", "Students");
//    }

//    [HttpPost]
//    public IActionResult Edit(Student student)
//    {
//        studentsData.Edit(student);

//        return RedirectToAction("Index", "Students");
//    }
//}
