using DaniilJobAggregator.Domain.Entity;

namespace DaniilJobAggregator.DAL.Repositories.Interfaces
{
    public interface IOrganisationRepository
    {
        List<Organisation> GetAllOrganisations();
        Organisation? GetOrganisationById(int id);
        bool DeleteOrganisation(int id);
        Organisation? CreateOrganisation(Organisation organisation);
        Organisation? EditOrganisation(Organisation organisation);
    }
}
