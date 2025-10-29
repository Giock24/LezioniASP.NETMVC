using Microsoft.AspNetCore.Mvc;
using DemoMVC.Core.Entities;
using DemoMVC.Core.Interfaces;

namespace DemoMVC.Controllers;

public class StudentsController : Controller
{
    private readonly IStudentsData _studentsData;
    private readonly IConfiguration _configuration;
    private readonly IGenericData<Student> _genericData;

    public StudentsController(IStudentsData studentsData, IConfiguration configuration, IGenericData<Student> genericData)
    {
        _studentsData = studentsData;
        _configuration = configuration;
        _genericData = genericData;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(_genericData.GetAll(_configuration["OrdinamentoStudenti"] ?? "Cognome"));
        // return View(_studentsData.GetAll(_configuration["OrdinamentoStudenti"] ?? "Cognome" ));
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var student = _studentsData.Get(id);

        if (student != null)
            return View(student);
        else
            return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Create()
    {

        return View();
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {
        _genericData.Create(student);

        return RedirectToAction("Index", "Students");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var student = _studentsData.Get(id);

        if (student != null)
            return View(student);
        else
            return RedirectToAction("Index", "Students");
    }

    [HttpPost]
    public IActionResult Delete(Student student)
    {
        _studentsData.Delete(student.Id);
        return RedirectToAction("Index", "Students");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {

        var student = _studentsData.Get(id);
        if (student != null)
            return View(student);
        else
            return RedirectToAction("Index", "Students");
    }

    [HttpPost]
    public IActionResult Edit(Student student)
    {
        _studentsData.Edit(student);
        return RedirectToAction("Index", "Students");
    }
}
