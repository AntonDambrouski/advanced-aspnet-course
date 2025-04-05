using DaniilJobAggregator.Domain.Entity;

namespace DaniilJobAggregator.DAL.Repositories.Interfaces
{
    public interface IOrganisationRepository
    {
        List<Organisation> GetAllOrganisations();
        Organisation GetOrganisationById(int id);
        bool DeleteOrganisation(int id);
        bool CreateOrganisation(Organisation organisation);
        bool EditOrganisation(Organisation organisation);
    }
}
