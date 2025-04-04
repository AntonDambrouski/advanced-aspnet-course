using DaniilJobAggregator.DAL.Repositories.Interfaces;
using DaniilJobAggregator.Domain.Entity;

namespace DaniilJobAggregator.DAL.Repositories.Implementations
{
    public class OrganisationRepository : IOrganisationRepository
    {
        private static readonly List<Organisation> _organisations = [];
        static OrganisationRepository()
        {
            _organisations.Add(new Organisation { OrganisationId = 1, Name = "ItAcademy", Vacancies = new List<Vacancy>() });
            _organisations.Add(new Organisation { OrganisationId = 2, Name = "BelTech", Vacancies = new List<Vacancy>() });
            _organisations.Add(new Organisation { OrganisationId = 3, Name = "Lada", Vacancies = new List<Vacancy>() });
        }

        public Organisation? CreateOrganisation(Organisation organisation)
        {
            _organisations.Add(organisation);
            return GetOrganisationById(organisation.OrganisationId);
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

        public Organisation? EditOrganisation(Organisation organisation)
        {
            Organisation oldOrganisation = GetOrganisationById(organisation.OrganisationId);
            _organisations.Remove(oldOrganisation);
            _organisations.Add(organisation);
            return GetOrganisationById(organisation.OrganisationId);
        }

        public List<Organisation> GetAllOrganisations()
        {
            return _organisations;
        }

        public Organisation? GetOrganisationById(int id)
        {
            return _organisations.FirstOrDefault(x => x.OrganisationId == id);
        }
    }
}
