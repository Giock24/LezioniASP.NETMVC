using DemoMVC.Core.Entities;
using DemoMVC.Core.Interfaces;

namespace DemoMVC.Infrastructure.Services;

public class GenericMockData<T> : IGenericData<T> where T : IGenericEntity<int>
{
    private List<T> _list = new List<T>();

    public void Create(T item)
    {
        if (_list.Count() > 0)
        {
            item.Id = _list.Max(s => s.Id) + 1;
        }
        else
        {
            item.Id = 1;
        }

        _list.Add(item);
        return;
    }

    public void Delete(int id)
    {
        var item = _list.Find(s => s.Id == id);
        if (item != null)
        {
            _list.Remove(item);
        }
    }

    public void Edit(T item)
    {
        var itemDatabase = _list.Find(s => s.Id == item.Id);
        if (itemDatabase != null)
        {
            _list.Remove(itemDatabase);
            _list.Add(item);
        }
    }

    public T? Get(int id)
    {
        return _list.Find(s => s.Id == id);
    }

    public IEnumerable<T> GetAll(string orderBy)
    {
        return _list;
    }

    public string GetLastInserted()
    {
        var lastItem = _list.OrderByDescending(s => s.Id).FirstOrDefault();
        if (lastItem != null)
        {
            return $"{lastItem.Nome} {lastItem.Cognome}";
        }
        else
        {
            return "Non ci sono studenti nel database";
        }
    }
}
