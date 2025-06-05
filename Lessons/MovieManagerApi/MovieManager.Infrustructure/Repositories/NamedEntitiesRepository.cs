using Microsoft.EntityFrameworkCore;
using MovieManager.Core.Entities;
using MovieManager.Core.Interfaces;
using MovieManager.Core.Interfaces.Repositories;
using MovieManager.Infrustructure.Data;

namespace MovieManager.Infrustructure.Repositories;
internal class NamedEntitiesRepository<TEntity>(MovieContext context) : RepositoryBase<TEntity>(context), INamedEntitiesRepository<TEntity>
    where TEntity : NamedEntity
{
    public async Task<NamedEntity?> SearchByNameAsync(string searchString) => await context.Set<TEntity>()
        .FirstOrDefaultAsync(e => e.Name.Contains(searchString));
}
