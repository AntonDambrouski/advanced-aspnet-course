using DaniilJobAggregator.Core.Entities;


namespace DaniilJobAggregator.Core.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
