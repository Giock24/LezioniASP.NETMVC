using DemoMVC.Core.Entities;
using DemoMVC.Core.Interfaces;

namespace DemoMVC.Infrastructure.Services;

public class TeacherService : IGenericData<Teacher, int>
{
    private static List<Teacher> list = new(){new Teacher
        {
            Id = 1,
            Nome = "Paolo",
            Cognome = "Mastro",
            Codice = "X0001",
            Materia = "Scienze"
        },
        new Teacher
        {
            Id = 2,
            Nome = "Luigino",
            Cognome = "Verdino",
            Codice = "X0002",
            Materia = "Grammatica"
        },
        new Teacher
        {
            Id = 3,
            Nome = "Giulietta",
            Cognome = "Gamba",
            Codice = "X0003",
            Materia = "Ginnastica"
        }
    };

    public Task CreateAsync(Teacher item)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task EditAsync(Teacher item)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Teacher>> GetAllAsync()
    {
        await Task.Delay(1000);

        return list.ToList();
    }

    public Task<Teacher?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
