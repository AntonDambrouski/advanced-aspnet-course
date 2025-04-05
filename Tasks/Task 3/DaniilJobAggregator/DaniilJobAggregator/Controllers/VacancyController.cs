using DaniilJobAggregator.Domain.Entity;
using DaniilJobAggregator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DaniilJobAggregator.Controllers
{
    public class VacancyController : Controller
    {

        private readonly IvacancyService _vacancyService; 
        private readonly IOrganisationService _organisationService;

        public VacancyController(IvacancyService vacancyService, IOrganisationService organisationService)
        {
            _vacancyService = vacancyService;
            _organisationService = organisationService;
        }

        public IActionResult Vacancies()
        {
            return View();
        }
        [HttpPost]
        public IActionResult VacanciesList()
        {
            List<Vacancy> vacancies = _vacancyService.GetAllVacancies();
            return PartialView(vacancies);
        }

        public IActionResult CreateVacancy(int organisationId)
        {
            ViewBag.OrganisationId = organisationId;
            return View(new Vacancy());
        }

        [HttpPost]
        public IActionResult CreateVacancy(Vacancy vacancy)
        {
            _vacancyService.CreateVacancy(vacancy);
            return RedirectToAction("DetailsOrganisation", "Organisation", new { organisationId = vacancy.IdOrganisation});
        }

        public IActionResult DetailsVacancy(int vacancyId)
        {
            Vacancy vacancy = _vacancyService.GetVacancyById(vacancyId);
            ViewBag.NameOrganisation = _organisationService.GetOrganisationById((int)vacancy.IdOrganisation).Name;
            return View(vacancy);
        }

        public IActionResult EditVacancy(int vacancyId)
        {
            return View(_vacancyService.GetVacancyById(vacancyId));
        }

        [HttpPost]
        public IActionResult EditVacancy(Vacancy vacancy)
        {
            _vacancyService.EditVacancy(vacancy);
            return RedirectToAction("DetailsVacancy", new { vacancyId = vacancy.VacancyId});
        }

        public IActionResult DeleteVacancy(int idDeleteVacancy)
        {
            int idOrganisation = (int)_vacancyService.GetVacancyById((int)idDeleteVacancy).IdOrganisation;
            _vacancyService.DeleteVacancy(idDeleteVacancy);
            return RedirectToAction("DetailsOrganisation", "Organisation", new { organisationId = idOrganisation });
        }
    }
}
