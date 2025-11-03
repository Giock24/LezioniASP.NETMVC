

using DemoMVC.Core.Entities;
using DemoMVC.Core.Interfaces;

namespace DemoMVC.Infrastructure.Services;

public class StudentService : IGenericData<Student, int>
{
    private static List<Student> list = new(){new Student
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
    public async Task CreateAsync(Student item)
    {
        await Task.Delay(1000);

        if (list.Count() > 0)
        {
            item.Id = list.Max(x => x.Id) + 1;
        }
        else
        {
            item.Id = 1;
        }

        list.Add(item);
    }

    public async Task DeleteAsync(int id)
    {
        await Task.Delay(1000);

        var student = list.Find(x => x.Id == id);

        if (student != null)
        {
            list.Remove(student);
        }
    }

    public async Task EditAsync(Student item)
    {
        await Task.Delay(1000);

        var studentDatabase = list.Find(x => x.Id == item.Id);

        if (studentDatabase != null)
        {
            studentDatabase.Nome = item.Nome;
            studentDatabase.Cognome = item.Cognome;
            studentDatabase.CodiceFiscale = item.CodiceFiscale;

            if (item.Indirizzo != null)
            {
                studentDatabase.Indirizzo = item.Indirizzo;
            }
        }
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        await Task.Delay(100);
        return list;
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        await Task.Delay(1000);

        return list.Find(x => x.Id == id);
    }
}
