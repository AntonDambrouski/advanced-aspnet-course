using MovieManager.Core.Entities;

namespace MovieManager.Core.Interfaces.Repositories;
public interface IRepositoryBase<TEntity> where TEntity : Entity
{
    ValueTask<TEntity> CreateAsync(TEntity movie);
    ValueTask<bool> DeleteAsync(int id);
    ValueTask<List<TEntity>> GetAllAsync();
    ValueTask<TEntity?> GetAsync(int id);
    ValueTask<TEntity> UpdateAsync(TEntity entity);
}