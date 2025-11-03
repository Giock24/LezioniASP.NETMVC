using DemoMVC.Core.Interfaces;

namespace DemoMVC.Infrastructure.Services;

public class GenericMockData<TEntity, TKey> : IGenericData<TEntity, TKey> where TEntity : class, IGenericEntity<TKey>, new()
{
    private static List<TEntity> list = new List<TEntity>();

    public async Task CreateAsync(TEntity item)
    {
        await Task.Delay(100); // Simula un'operazione asincrona
        //if (list.Count() > 0)
        //{
        //    var x = list.LastOrDefault();
        //    if (x != null)
        //    {

        //    }
        //    else
        //    {
        //        item.Id = 1;
        //    }

        //    item.Id = list.LastOrDefault()?.Id + 1;
        //}
        //else
        //{
        //    item.Id = 1;
        //}

        list.Add(item);
    }

    public async Task DeleteAsync(TKey id)
    {
        await Task.Delay(100); // Simula un'operazione asincrona
        //var item = list.Find(x => x.Id == id);

        //if (item != null)
        //{
        //    list.Remove(item);
        //}
    }

    public async Task EditAsync(TEntity item)
    {
        await Task.Delay(100); // Simula un'operazione asincrona
        //var itemDatabase = list.Find(x => x.Id == item.Id);

        //if (itemDatabase != null)
        //{
        //    list.Remove(itemDatabase);
        //    list.Add(item);
        //}
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        await Task.Delay(100); // Simula un'operazione asincrona
        //return list.Find(x => x.Id == id);
        return new TEntity();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        await Task.Delay(100); // Simula un'operazione asincrona
        return list;
    }

    //public string GetLastInserted()
    //{
    //    var lastItem = list.OrderByDescending(x => x.Id).FirstOrDefault();

    //    if (lastItem != null)
    //    {
    //        return lastItem.Nome + " " + lastItem.Cognome;
    //    }
    //    else
    //    {
    //        return "Non ci sono studenti nel database";
    //    }
    //}
}
