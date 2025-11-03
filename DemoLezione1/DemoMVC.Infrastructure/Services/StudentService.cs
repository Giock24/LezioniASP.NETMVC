

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
    public Task CreateAsync(Student item)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task EditAsync(Student item)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        await Task.Delay(100);
        return list;
    }

    public Task<Student?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
