using MovieManager.Core.Entities;

namespace MovieManager.Core.Interfaces.Repositories;
public interface INamedEntitiesRepository<TEntity> : IRepositoryBase<TEntity>
    where TEntity : NamedEntity
{
}
