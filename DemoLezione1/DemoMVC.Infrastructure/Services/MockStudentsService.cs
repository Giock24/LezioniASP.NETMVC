using DemoMVC.Core.Entities;
using DemoMVC.Core.Interfaces;

namespace DemoMVC.Infrastructure.Services;

public class MockStudentsService : IStudentsData
{
    private static List<Student> students = new (){new Student
            {
                Id = 1,
                Matricola = "MAT001",
                Nome = "Mario",
                Cognome = "Rossi",
                DataDiNascita = new DateTime(2000, 1, 15),
                CodiceFiscale = "MRARSS00A15H501U"
            },
            new Student
            {
                Id = 2,
                Matricola = "MAT002",
                Nome = "Luigi",
                Cognome = "Verdi",
                DataDiNascita = new DateTime(1999, 5, 22),
                CodiceFiscale = "LGVGRD99E22H501U"
            },
            new Student
            {
                Id = 3,
                Matricola = "MAT003",
                Nome = "Giulia",
                Cognome = "Bianchi",
                DataDiNascita = new DateTime(2001, 3, 10),
                CodiceFiscale = "GLBNC01C10H501U"
            },
            new Student
            {
                Id = 4,
                Matricola = "MAT004",
                Nome = "Andrea",
                Cognome = "Fabbri",
                CodiceFiscale = "FBBNFGTTYHHFD"
            }
        };

    public void Create(Student student)
    {
        if (students.Count() > 0)
        {
            student.Id = students.Max(x => x.Id) + 1;
        }
        else
        {
            student.Id = 1;
        }

        students.Add(student);

        return;
    }

    public void Delete(int id)
    {
        var student = students.Find(x => x.Id == id);

        if (student != null)
        {
            students.Remove(student);
        }
    }

    public void Edit(Student student)
    {
        var studentDatabase = students.Find(x => x.Id == student.Id);

        if (studentDatabase != null)
        {
            studentDatabase.Nome = student.Nome;
            studentDatabase.Cognome = student.Cognome;
            studentDatabase.CodiceFiscale = student.CodiceFiscale;

            if (student.Indirizzo != null)
            {
                studentDatabase.Indirizzo = student.Indirizzo;
            }
        }
    }

    public Student? Get(int id)
    {
        return students.Find(x => x.Id == id);
    }

    public IEnumerable<Student> GetAll(string orderBy)
    {
        switch (orderBy)
        {
            case "Cognome":
            default:
                return students.OrderBy(s => s.Cognome);
            case "Matricole":
                return students.OrderBy(s => s.Matricola);
            case "Nome":
                return students.OrderBy(s => s.Nome);
        }
    }

    public string GetLastInserted()
    {
        var lastStudent = students.OrderByDescending(x => x.Id).FirstOrDefault();

        if (lastStudent != null)
        {
            return lastStudent.Nome + " " + lastStudent.Cognome;
        }
        else
        {
            return "Non ci sono studenti nel database";
        }
    }
}
