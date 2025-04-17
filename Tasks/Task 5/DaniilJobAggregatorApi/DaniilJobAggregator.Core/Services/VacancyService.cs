using DaniilJobAggregator.Core.Entities;
using DaniilJobAggregator.Core.Interfaces;
using DaniilJobAggregator.Core.Interfaces.Repositories;


namespace DaniilJobAggregator.Core.Services
{
    public class VacancyService : IvacancyService
    {
        private readonly IVacancyRepository _vacancyRepository;

        public VacancyService(IVacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }
        public async Task<Vacancy?> CreateVacancy(Vacancy vacancy)
        {
            var createdVacancy = await _vacancyRepository.CreateAsync(vacancy);
            return createdVacancy;
        }

        public async Task<bool> DeleteVacancy(int idVacancy)
        {
            var isDelete = await _vacancyRepository.DeleteAsync(idVacancy);
            return isDelete;
        }

        public async Task<List<Vacancy>> GetAllVacancies()
        {
            return await _vacancyRepository.GetAllAsync();
        }

        public async Task<Vacancy?> GetVacancyById(int idVacancy)
        {
            return await _vacancyRepository.GetByIdAsync(idVacancy);
        }

        public async Task<Vacancy?> EditVacancy(Vacancy vacancy)
        {
            var editedVacancy = await _vacancyRepository.UpdateAsync(vacancy);
            return editedVacancy;
        }
        public async Task<List<Vacancy>> GetVacanciesByOrganisationId(int organisationId)
        {
            return await _vacancyRepository.GetVacanciesByOrganisationIdAsync(organisationId);
            
        }
    }
}
