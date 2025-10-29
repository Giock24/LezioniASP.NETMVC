using DemoMVC.Core.Entities;

namespace DemoMVC.Core.Interfaces;

public interface IStudentsData
{
    IEnumerable<Student> GetAll(string orderBy);
    Student? Get(int id);
    void Create(Student student);
    void Delete(int id);
    void Edit(Student student);
    string GetLastInserted();
}
