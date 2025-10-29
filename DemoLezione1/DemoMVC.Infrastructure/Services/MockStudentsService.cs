using DemoMVC.Core.Entities;
using DemoMVC.Core.Interfaces;

namespace DemoMVC.Infrastructure.Services;

public class MockStudentsService : IStudentsData
{
    private static List<Student> _students = new(){new Student
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
            },
            new Student
            {
                Id = 4,
                Matricola = "MAT004",
                Nome = "Andrea",
                Cognome = "Fabbri",
                CodiceFiscale = "GLBNC01C10H501U"
            }
    };

    public Student? Get(int id)
    {
        return _students.Find(s => s.Id == id);
    }

    public IEnumerable<Student> GetAll(string orderBy)
    {
        switch (orderBy.ToLower())
        {
            case "nome":
                return _students.OrderBy(s => s.Nome);
            case "cognome":
            default:
                return _students.OrderBy(s => s.Cognome);
            case "datanascita":
                return _students.OrderBy(s => s.DataNascita);
        }
    }

    public void Create(Student student)
    {
        if (_students.Count() > 0)
        {
            student.Id = _students.Max(s => s.Id) + 1;

        }
        else
        {
            student.Id = 1;
        }

        _students.Add(student);
        return;
    }

    public void Delete(int id)
    {
        var student = _students.Find(s => s.Id == id);
        if (student != null)
        {
            _students.Remove(student);
        }
    }

    public void Edit(Student student)
    {
        var studentDatabase = _students.Find(s => s.Id == student.Id);
        if (studentDatabase != null)
        {
            studentDatabase.Matricola = student.Matricola;
            studentDatabase.Nome = student.Nome;
            studentDatabase.Cognome = student.Cognome;
            studentDatabase.DataNascita = student.DataNascita;
            studentDatabase.Id_CAP = student.Id_CAP;
            if (student.Indirizzo != null)
                studentDatabase.Indirizzo = student.Indirizzo;
            studentDatabase.NumeroCivico = student.NumeroCivico;
            studentDatabase.CodiceFiscale = student.CodiceFiscale;
        }
    }

    public string GetLastInserted()
    {
        var student = _students.OrderByDescending(s => s.Id).FirstOrDefault();
        if (student != null)
        {
            return $"{student.Nome} {student.Cognome}";
        }
        else
        {
            return "Non ci sono studenti nel database";
        }
    }

}
