using Microsoft.AspNetCore.Mvc;
using DemoMVC.Core.Entities;

namespace DemoMVC.Controllers;

public class StudentsController : Controller
{
    public IActionResult Index()
    {
        var students = new List<Student>
        {
            new Student
            {
                Id = 1,
                Matricola = "MAT001",
                Nome = "Mario",
                Cognome = "Rossi",
                DataNascita = new DateTime(2000, 1, 15),
                CodiceFiscale = "MRARSS00A15H501U"
            },
            new Student
            {
                Id = 2,
                Matricola = "MAT002",
                Nome = "Luigi",
                Cognome = "Verdi",
                DataNascita = new DateTime(1999, 5, 22),
                CodiceFiscale = "LGVGRD99E22H501U"
            },
            new Student
            {
                Id = 3,
                Matricola = "MAT003",
                Nome = "Giulia",
                Cognome = "Bianchi",
                DataNascita = new DateTime(2001, 3, 10),
                CodiceFiscale = "GLBNC01C10H501U"
            }
        };

        return View(students);
    }
}
