using Microsoft.EntityFrameworkCore;
using MovieManager.Core.Entities;
using MovieManager.Core.Interfaces.Repositories;
using MovieManager.Infrustructure.Data;

namespace MovieManager.Infrustructure.Repositories;
internal class RepositoryBase<TEntity>(MovieContext context) 
    : IRepositoryBase<TEntity> where TEntity : Entity
{
    public async ValueTask<TEntity> CreateAsync(TEntity movie)
    {
        context.Set<TEntity>().Add(movie);
        await context.SaveChangesAsync();

        return movie;
    }

    public async ValueTask<bool> DeleteAsync(int id)
    {
        var entity = await GetAsync(id);
        if (entity != null)
        {
            context.Set<TEntity>().Remove(entity);
            return await context.SaveChangesAsync() > 0;
        }

        return false;
    }

    public async ValueTask<List<TEntity>> GetAllAsync()
    {
        return await context.Set<TEntity>().ToListAsync();
    }

    public async ValueTask<TEntity?> GetAsync(int id)
    {
        return await context.Set<TEntity>()
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async ValueTask<TEntity> UpdateAsync(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
        await context.SaveChangesAsync();

        return entity;
    }
}
