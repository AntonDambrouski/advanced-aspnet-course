using DaniilJobAggregator.Domain.Entity;
using DaniilJobAggregator.Services.Interfaces;
using DaniilJobAggregatorAPI.Domain.ViewModels;
using DaniilJobAggregatorAPI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DaniilJobAggregatorAPI.Controllers
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
        public IEnumerable<Vacancy> Get()
        {
            return _vacancyService.GetAllVacancies();
        }

        [HttpGet("{id}")]
        public ActionResult<Vacancy> Get(int id)
        {
            var Vacancy = _vacancyService.GetVacancyById(id);
            if (Vacancy == null)
            {
                return BadRequest();
            }
            return Vacancy;
        }

        [HttpPost]
        [TypeFilter(typeof(OrganisationIdAttribute))]
        public ActionResult Post([FromBody] VacancyViewModel vacancyModel)
        {
            var vacancies = _vacancyService.GetAllVacancies();
            var maxId = vacancies.Count() > 0 ? vacancies.Max(x => x.VacancyId) : 0;
            maxId++;
            Vacancy vacancy = new Vacancy(
                maxId,
                vacancyModel.Name,
                vacancyModel.Description,
                vacancyModel.Location,
                vacancyModel.Salary,
                vacancyModel.IdOrganisation,
                vacancyModel.Requirements,
                vacancyModel.Responsibilities,
                vacancyModel.Conditions,
                vacancyModel.ScheduleType

                );
            _vacancyService.CreateVacancy(vacancy);
            return CreatedAtAction(nameof(Get), new { id = vacancy.VacancyId }, vacancy);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] VacancyViewModel vacancy)
        {
            var savedVacancy = _vacancyService.GetVacancyById(id);
            if (savedVacancy == null)
            {
                return BadRequest();
            }

            Vacancy updatedVacancy = new Vacancy
            {
                VacancyId = id,
                Name = vacancy.Name,
                Description = vacancy.Description,
                Location = vacancy.Location,
                Salary = vacancy.Salary,
                IdOrganisation = vacancy.IdOrganisation,
                Requirements = vacancy.Requirements,
                Responsibilities = vacancy.Responsibilities,
                Conditions = vacancy.Conditions,
                ScheduleType = vacancy.ScheduleType
            };
            _vacancyService.EditVacancy(updatedVacancy);
            return Ok(updatedVacancy);
        }

      
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var vacancy = _vacancyService.GetVacancyById(id);
            if (vacancy == null)
            {
                return BadRequest();
            }
            _vacancyService.DeleteVacancy(id);
            return NoContent();
        }

    }
}
