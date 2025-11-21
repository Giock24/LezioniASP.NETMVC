using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMVC.Core.Interfaces;

public interface IData<TEntity> where TEntity : class, new()
{
    IQueryable<TEntity> GetAll();

    Task<TEntity?> GetByIdAsync(int id);

    Task CreateAsync(TEntity item);

    Task DeleteAsync(int id);

    Task EditAsync(TEntity item);
}
