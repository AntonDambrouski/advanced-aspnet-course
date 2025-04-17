using DaniilJobAggregator.Core.Entities;


namespace DaniilJobAggregator.Core.Interfaces
{
    public interface IOrganisationService
    {
        Task<List<Organisation>> GetAllOrganisations();
        Task<Organisation?> GetOrganisationById(int id);
        Task<bool> DeleteOrganisation(int id);
        Task<Organisation?> CreateOrganisation(Organisation organisation);
        Task<Organisation?> EditOrganisation(Organisation organisation);
    }
}
