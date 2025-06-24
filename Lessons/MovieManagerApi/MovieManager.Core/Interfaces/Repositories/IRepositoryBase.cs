using MovieManager.Core.Entities;

namespace MovieManager.Core.Interfaces.Repositories;
public interface IRepositoryBase<TEntity> where TEntity : Entity
{
    Task<TEntity> CreateAsync(TEntity movie);
    Task<bool> DeleteAsync(int id);
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetAsync(int id);
    Task<TEntity> UpdateAsync(TEntity entity);
}