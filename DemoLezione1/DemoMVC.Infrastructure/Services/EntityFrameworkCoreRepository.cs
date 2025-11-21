using DemoMVC.Core.Interfaces;
using DemoMVC.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMVC.Infrastructure.Services;

public class EntityFrameworkCoreRepository<TEntity> : IData<TEntity> where TEntity : class, new()
{
    private readonly NorthwindContext context;
    private readonly DbSet<TEntity> dbSet;

    public EntityFrameworkCoreRepository(NorthwindContext context)
    {
        this.context = context;

        dbSet = context.Set<TEntity>();
    }

    public async Task CreateAsync(TEntity item)
    {
        context.Add(item);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await GetByIdAsync(id);

        if (item != null)
        {
            context.Remove(item);
            //dbSet.Remove(item);
            await context.SaveChangesAsync();
        }
    }

    public async Task EditAsync(TEntity item)
    {
        context.Update(item);
        await context.SaveChangesAsync();
    }

    public IQueryable<TEntity> GetAll()
    {
        dbSet.AsNoTracking();
        return dbSet;
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await dbSet.FindAsync(id);
    }
}
