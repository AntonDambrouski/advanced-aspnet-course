using DaniilJobAggregator.Core.Entities;
using DaniilJobAggregator.Core.Interfaces;
using DaniilJobAggregatorApi.Filters;
using DaniilJobAggregatorApi.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace DaniilJobAggregatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IvacancyService _vacancyService;
        public VacancyController(IvacancyService ivacancyService)
        {
            _vacancyService = ivacancyService;
        }

        [HttpGet]
        public async Task<IEnumerable<Vacancy>> Get()
        {
            return await _vacancyService.GetAllVacancies();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vacancy>> Get(int id)
        {
            var Vacancy = await _vacancyService.GetVacancyById(id);
            if (Vacancy == null)
            {
                return BadRequest();
            }
            return Vacancy;
        }

        [HttpPost]
        [TypeFilter(typeof(OrganisationIdAttribute))]
        public async Task<ActionResult> Post([FromBody] VacancyViewModel vacancyModel)
        {
            var vacancies = await _vacancyService.GetAllVacancies();
            var maxId = vacancies.Count() > 0 ? vacancies.Max(x => x.Id) : 0;
            maxId++;
            Vacancy vacancy = new Vacancy();
            vacancy.Id = maxId;
            vacancy.Name = vacancyModel.Name;
            vacancy.Description = vacancyModel.Description;
            vacancy.Location = vacancyModel.Location;
            vacancy.Salary = vacancyModel.Salary;
            vacancy.IdOrganisation = vacancyModel.IdOrganisation;
            vacancy.Requirements = vacancyModel.Requirements;
            vacancy.Responsibilities = vacancyModel.Responsibilities;
            vacancy.Conditions = vacancyModel.Conditions;
            vacancy.ScheduleType = vacancyModel.ScheduleType;

            await _vacancyService.CreateVacancy(vacancy);
            return CreatedAtAction(nameof(Get), new { id = vacancy.Id }, vacancy);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] VacancyViewModel vacancy)
        {
            var savedVacancy = await _vacancyService.GetVacancyById(id);
            if (savedVacancy == null)
            {
                return BadRequest();
            }

            Vacancy updatedVacancy = new Vacancy();
            updatedVacancy.Id = id;
            updatedVacancy.Name = vacancy.Name;
            updatedVacancy.Description = vacancy.Description;
            updatedVacancy.Location = vacancy.Location;
            updatedVacancy.Salary = vacancy.Salary;
            updatedVacancy.IdOrganisation = vacancy.IdOrganisation;
            updatedVacancy.Requirements = vacancy.Requirements;
            updatedVacancy.Responsibilities = vacancy.Responsibilities;
            updatedVacancy.Conditions = vacancy.Conditions;
            updatedVacancy.ScheduleType = vacancy.ScheduleType;

            await _vacancyService.EditVacancy(updatedVacancy);
            return Ok(updatedVacancy);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var vacancy = await _vacancyService.GetVacancyById(id);
            if (vacancy == null)
            {
                return BadRequest();
            }
            await _vacancyService.DeleteVacancy(id);
            return NoContent();
        }

    }
}
