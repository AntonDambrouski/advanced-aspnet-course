using DaniilJobAggregator.DAL.Repositories.Interfaces;
using DaniilJobAggregator.Domain.Entity;

namespace DaniilJobAggregator.DAL.Repositories.Implementations
{
    public class OrganisationRepository : IOrganisationRepository
    {
        private static readonly List<Organisation> _organisations = [];
        static OrganisationRepository()
        {
            _organisations.Add(new Organisation { OrganizationId = 1, Name = "ItAcademy", Vacancies = new List<Vacancy>() });
            _organisations.Add(new Organisation { OrganizationId = 2, Name = "BelTech", Vacancies = new List<Vacancy>() });
            _organisations.Add(new Organisation { OrganizationId = 3, Name = "Lada", Vacancies = new List<Vacancy>() });
        }

        public bool CreateOrganisation(Organisation organisation)
        {
            try
            {
                _organisations.Add(organisation);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteOrganisation(int id)
        {
            try
            {
                _organisations.Remove(GetOrganisationById(id));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditOrganisation(Organisation organisation)
        {
            try
            {
                Organisation oldOrganisation = GetOrganisationById(organisation.OrganizationId);
                _organisations.Remove(oldOrganisation);
                _organisations.Add(organisation);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Organisation> GetAllOrganisations()
        {
            return _organisations;
        }

        public Organisation GetOrganisationById(int id)
        {
            return _organisations.FirstOrDefault(x  => x.OrganizationId == id);
        }
    }
}
