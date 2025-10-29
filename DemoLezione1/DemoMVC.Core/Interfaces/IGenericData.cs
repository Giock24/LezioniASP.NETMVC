namespace DemoMVC.Core.Interfaces;

public interface IGenericData<T> where T : IGenericEntity<int>
{
    IEnumerable<T> GetAll(string orderBy);

    T? Get(int id);

    void Create(T item);

    void Delete(int id);

    void Edit(T item);

    string GetLastInserted();
}
