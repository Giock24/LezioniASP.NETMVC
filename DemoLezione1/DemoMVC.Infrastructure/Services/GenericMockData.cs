using DemoMVC.Core.Interfaces;

namespace DemoMVC.Infrastructure.Services;

public class GenericMockData<T> : IGenericData<T> where T : IGenericEntity<int>
{
    private static List<T> list = new List<T>();

    public void Create(T item)
    {
        if (list.Count() > 0)
        {
            item.Id = list.Max(x => x.Id) + 1;
        }
        else
        {
            item.Id = 1;
        }

        list.Add(item);

        return;
    }

    public void Delete(int id)
    {
        var item = list.Find(x => x.Id == id);

        if (item != null)
        {
            list.Remove(item);
        }
    }

    public void Edit(T item)
    {
        var itemDatabase = list.Find(x => x.Id == item.Id);

        if (itemDatabase != null)
        {
            list.Remove(itemDatabase);
            list.Add(item);
        }
    }

    public T? Get(int id)
    {
        return list.Find(x => x.Id == id);
    }

    public IEnumerable<T> GetAll(string orderBy)
    {
        return list;
    }

    public string GetLastInserted()
    {
        var lastItem = list.OrderByDescending(x => x.Id).FirstOrDefault();

        if (lastItem != null)
        {
            return lastItem.Nome + " " + lastItem.Cognome;
        }
        else
        {
            return "Non ci sono studenti nel database";
        }
    }
}
