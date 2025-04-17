using DaniilJobAggregator.Core.Entities;
using DaniilJobAggregator.Core.Interfaces.Repositories;
using DaniilJobAggregator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace DaniilJobAggregator.Infrastructure.Repositories
{
    public class BaseRepository<TEntity>(AppDbContext appDbContext) 
        : IBaseRepository<TEntity> where TEntity : Entity
    {
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await appDbContext.Set<TEntity>()
                                        .ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await appDbContext.Set<TEntity>()
                                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            appDbContext.Set<TEntity>().Add(entity);
            await appDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            appDbContext.Set<TEntity>().Update(entity);
            await appDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = GetByIdAsync(id);
            if (entity != null)
            {
                appDbContext.Set<TEntity>().Remove(await entity);
                return await appDbContext.SaveChangesAsync() > 0;
            }
            return false;
        }       
    }
}
