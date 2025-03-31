using DaniilJobAggregator.Domain.Entity;

namespace DaniilJobAggregator.Services.Interfaces
{
    public interface IOrganisationService
    {
        List<Organisation> GetAllOrganisations();
        Organisation GetOrganisationById(int id);
        bool DeleteOrganisation(int id);
        bool CreateOrganisation(Organisation organisation);
        bool EditOrganisation(Organisation organisation);
    }
}
