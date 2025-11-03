namespace DemoMVC.Core.Interfaces;

public interface IGenericData<TEntity, TKey> where TEntity : class, IGenericEntity<TKey>, new()
{
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity?> GetByIdAsync(TKey id);

    Task CreateAsync(TEntity item);

    Task DeleteAsync(TKey id);

    Task EditAsync(TEntity item);

    // string GetLastInserted();
}
