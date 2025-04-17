using DaniilJobAggregator.Core.Entities;
using DaniilJobAggregator.Core.Interfaces.Repositories;
using DaniilJobAggregator.Infrastructure.Data;


namespace DaniilJobAggregator.Infrastructure.Repositories
{
    public class OrganisationRepository(AppDbContext appDbContext)
        : BaseRepository<Organisation>(appDbContext), IOrganisationRepository
    {
       
    }
}
