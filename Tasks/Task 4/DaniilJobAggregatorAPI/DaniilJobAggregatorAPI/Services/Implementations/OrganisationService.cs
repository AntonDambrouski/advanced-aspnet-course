using DaniilJobAggregator.DAL.Repositories.Interfaces;
using DaniilJobAggregator.Domain.Entity;
using DaniilJobAggregator.Services.Interfaces;

namespace DaniilJobAggregator.Services.Implementations
{
    public class OrganisationService : IOrganisationService
    {
        private readonly IOrganisationRepository _organisationRepository;

        public OrganisationService(IOrganisationRepository organisationRepository)
        {
            _organisationRepository = organisationRepository;
        }

        public Organisation? CreateOrganisation(Organisation organisation)
        {
            return _organisationRepository.CreateOrganisation(organisation);
        }

        public bool DeleteOrganisation(int id)
        {
            return _organisationRepository.DeleteOrganisation(id);
        }

        public Organisation? EditOrganisation(Organisation organisation)
        {
            return _organisationRepository.EditOrganisation(organisation);
        }

        public List<Organisation> GetAllOrganisations()
        {
            return _organisationRepository.GetAllOrganisations();
        }

        public Organisation? GetOrganisationById(int id)
        {
            return _organisationRepository.GetOrganisationById(id);
        }
    }
}
