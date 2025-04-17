using DaniilJobAggregator.Core.Entities;
using DaniilJobAggregator.Core.Interfaces;
using DaniilJobAggregator.Core.Interfaces.Repositories;


namespace DaniilJobAggregator.Core.Services
{
    public class OrganisationService : IOrganisationService
    {
        private readonly IOrganisationRepository _organisationRepository;

        public OrganisationService(IOrganisationRepository organisationRepository)
        {
            _organisationRepository = organisationRepository;
        }

        public async Task<Organisation?> CreateOrganisation(Organisation organisation)
        {
            var createdOrganisation = await _organisationRepository.CreateAsync(organisation);
            return createdOrganisation;
        }

        public async Task<bool> DeleteOrganisation(int id)
        {
            var isDelete = await _organisationRepository.DeleteAsync(id);
            return isDelete;
        }

        public async Task<Organisation?> EditOrganisation(Organisation organisation)
        {
            var edited = await _organisationRepository.UpdateAsync(organisation);
            return edited;
        }

        public async Task<List<Organisation>> GetAllOrganisations()
        {
            return await _organisationRepository.GetAllAsync();
        }

        public async Task<Organisation?> GetOrganisationById(int id)
        {
            return await _organisationRepository.GetByIdAsync(id);
        }
    }
}
