using Microsoft.EntityFrameworkCore;
using MovieManager.Core.Entities;
using MovieManager.Core.Interfaces.Repositories;
using MovieManager.Infrustructure.Data;

namespace MovieManager.Infrustructure.Repositories;
internal class RepositoryBase<TEntity>(MovieContext context) 
    : IRepositoryBase<TEntity> where TEntity : Entity
{
    public async Task<TEntity> CreateAsync(TEntity movie)
    {
        context.Set<TEntity>().Add(movie);
        await context.SaveChangesAsync();

        return movie;
    }

    protected IQueryable<TEntity> GetAllAsync(string searchTerm, Func<string[]> searchableFieldsSelector)
    {
        var query = context.Set<TEntity>().AsQueryable();
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            var searchableFields = searchableFieldsSelector();
            foreach (var field in searchableFields)
            {
                query = query.Where(e => EF.Property<string>(e, field).Contains(searchTerm));
            }
        }

        return query;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await GetAsync(id);
        if (entity != null)
        {
            context.Set<TEntity>().Remove(entity);
            return await context.SaveChangesAsync() > 0;
        }

        return false;
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetAsync(int id)
    {
        return await context.Set<TEntity>()
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
        await context.SaveChangesAsync();

        return entity;
    }
}
