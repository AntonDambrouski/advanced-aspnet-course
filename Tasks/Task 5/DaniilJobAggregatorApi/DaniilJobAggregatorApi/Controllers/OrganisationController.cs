using DaniilJobAggregator.Core.Entities;
using DaniilJobAggregator.Core.Interfaces;
using DaniilJobAggregatorApi.Filters;
using DaniilJobAggregatorApi.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace DaniilJobAggregatorApi.Controllers
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
        public async Task<IEnumerable<Organisation>> Get()
        {
            return await _organisationService.GetAllOrganisations();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Organisation>> Get(int id)
        {
            var organisation = await _organisationService.GetOrganisationById(id);
            if (organisation == null)
            {
                return BadRequest();
            }
            return organisation;

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OrganisationViewModel organisationModel)
        {
            var organisations = await _organisationService.GetAllOrganisations();
            var maxId = organisations.Count() > 0 ? organisations.Max(x => x.Id) : 0;
            maxId++;
            Organisation organisation = new Organisation { 
                Id = maxId,
                Name = organisationModel.Name,
                Vacancies = organisationModel.Vacancies};
               
            await _organisationService.CreateOrganisation(organisation);

            return CreatedAtAction(nameof(Get), new { id = organisation.Id }, organisation);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] OrganisationViewModel organisation)
        {
            var savedOrganisation = await _organisationService.GetOrganisationById(id);
            if (savedOrganisation == null)
            {
                return BadRequest();
            }

            Organisation updatedOrganisation = new Organisation
            {
                Id = id,
                Name = organisation.Name,
                Vacancies= organisation.Vacancies
            };
            await _organisationService.EditOrganisation(updatedOrganisation);

            return Ok(updatedOrganisation);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var organisation = await _organisationService.GetOrganisationById(id);
            if (organisation == null)
            {
                return BadRequest();
            }

            await _organisationService.DeleteOrganisation(id);
            return NoContent();
        }

        [HttpGet("{organisationId:int}/vacancies")]
        public async Task<ActionResult<IEnumerable<Vacancy>>> GetVacancies(int organisationId)
        {
            var vacancies = await _vacancyService.GetVacanciesByOrganisationId(organisationId);
            return Ok(vacancies);
        }

        [HttpPost("{organisationId:int}/vacancies")]
        public async Task<ActionResult<Vacancy>> AddVacancy(int organisationId, [FromBody] VacancyForOrganisationViewModel vacancyModel)
        {
            var organisations = await _organisationService.GetOrganisationById(organisationId);
            if (organisations == null)
            {
                return NotFound();
            }

            var vacancies = await _vacancyService.GetAllVacancies();
            var maxId = vacancies.Count() > 0 ? vacancies.Max(x => x.Id) : 0;
            maxId++;
            Vacancy vacancy = new Vacancy();
            vacancy.Id = maxId;
            vacancy.Name = vacancyModel.Name;
            vacancy.Description = vacancyModel.Description;
            vacancy.Location = vacancyModel.Location;
            vacancy.Salary = vacancyModel.Salary;
            vacancy.IdOrganisation = organisationId;
            vacancy.Requirements = vacancyModel.Requirements;
            vacancy.Responsibilities = vacancyModel.Responsibilities;
            vacancy.Conditions = vacancyModel.Conditions;
            vacancy.ScheduleType = vacancyModel.ScheduleType;   
            vacancy.IdOrganisation = organisationId;
            await _vacancyService.CreateVacancy(vacancy);

            return CreatedAtAction(nameof(GetVacancies), new { organisationId }, vacancy);
        }
    }
}
