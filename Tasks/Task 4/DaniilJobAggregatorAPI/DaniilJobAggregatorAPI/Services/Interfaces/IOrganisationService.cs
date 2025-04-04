using DaniilJobAggregator.Domain.Entity;

namespace DaniilJobAggregator.Services.Interfaces
{
    public interface IOrganisationService
    {
        List<Organisation> GetAllOrganisations();
        Organisation? GetOrganisationById(int id);
        bool DeleteOrganisation(int id);
        Organisation? CreateOrganisation(Organisation organisation);
        Organisation? EditOrganisation(Organisation organisation);
    }
}
