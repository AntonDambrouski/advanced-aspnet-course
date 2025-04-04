using DaniilJobAggregator.Domain.Entity;
using DaniilJobAggregator.Services.Interfaces;
using DaniilJobAggregatorAPI.Domain.ViewModels;
using DaniilJobAggregatorAPI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DaniilJobAggregatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [IEFilter]
    public class OrganisationController : ControllerBase
    {
        private readonly IOrganisationService _organisationService;
        private readonly IvacancyService _vacancyService;

        public OrganisationController(IOrganisationService organisationService, IvacancyService vacancyService)
        {
            _organisationService = organisationService;
            _vacancyService = vacancyService;
        }

        [HttpGet]
        [AddHeaderFilter("Custom-Header", "My value")]
        [AddHeaderResultFilter()]
        public IEnumerable<Organisation> Get()
        {
            return _organisationService.GetAllOrganisations();
        }

        [HttpGet("{id}")]
        public ActionResult<Organisation> Get(int id)
        {
            var organisation = _organisationService.GetOrganisationById(id);
            if (organisation == null)
            {
                return BadRequest();
            }
            return organisation;

        }

        [HttpPost]
        public ActionResult Post([FromBody] OrganisationViewModel organisationModel)
        {
            var organisations = _organisationService.GetAllOrganisations();
            var maxId = organisations.Count() > 0 ? organisations.Max(x => x.OrganisationId) : 0;
            maxId++;
            Organisation organisation = new Organisation { 
                OrganisationId = maxId,
                Name = organisationModel.Name,
                Vacancies = organisationModel.Vacancies};
               
            _organisationService.CreateOrganisation(organisation);

            return CreatedAtAction(nameof(Get), new { id = organisation.OrganisationId }, organisation);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] OrganisationViewModel organisation)
        {
            var savedOrganisation = _organisationService.GetOrganisationById(id);
            if (savedOrganisation == null)
            {
                return BadRequest();
            }

            Organisation updatedOrganisation = new Organisation
            {
                OrganisationId = id,
                Name = organisation.Name,
                Vacancies= organisation.Vacancies
            };
            _organisationService.EditOrganisation(updatedOrganisation);

            return Ok(updatedOrganisation);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var organisation = _organisationService.GetOrganisationById(id);
            if (organisation == null)
            {
                return BadRequest();
            }

            _organisationService.DeleteOrganisation(id);
            return NoContent();
        }

        [HttpGet("{organisationId:int}/vacancies")]
        public ActionResult<IEnumerable<Vacancy>> GetVacancies(int organisationId)
        {
            var vacancies = _vacancyService.GetVacanciesByOrganisationId(organisationId);
            return Ok(vacancies);
        }

        [HttpPost("{organisationId:int}/vacancies")]
        public ActionResult<Vacancy> AddVacancy(int organisationId, [FromBody] VacancyForOrganisationViewModel vacancyModel)
        {
            var organisations = _organisationService.GetOrganisationById(organisationId);
            if (organisations == null)
            {
                return NotFound();
            }

            var vacancies = _vacancyService.GetAllVacancies();
            var maxId = vacancies.Count() > 0 ? vacancies.Max(x => x.VacancyId) : 0;
            maxId++;
            Vacancy vacancy = new Vacancy(
                maxId,
                vacancyModel.Name,
                vacancyModel.Description,
                vacancyModel.Location,
                vacancyModel.Salary,
                organisationId,
                vacancyModel.Requirements,
                vacancyModel.Responsibilities,
                vacancyModel.Conditions,
                vacancyModel.ScheduleType
                );


            vacancy.IdOrganisation = organisationId;
            _vacancyService.CreateVacancy(vacancy);

            return CreatedAtAction(nameof(GetVacancies), new { organisationId }, vacancy);
        }
    }
}
