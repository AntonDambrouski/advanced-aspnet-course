using DaniilJobAggregator.Domain.Entity;
using DaniilJobAggregator.Domain.ViewModels;
using DaniilJobAggregator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DaniilJobAggregator.Controllers
{
    public class OrganisationController : Controller
    {
        private readonly IOrganisationService _organisationService;
        private readonly IvacancyService _vacancyService;
        public OrganisationController(IOrganisationService organisationService, IvacancyService vacancyService)
        {
            _organisationService = organisationService;
            _vacancyService = vacancyService;
        }
        public IActionResult Organisations()
        {
            return View(_organisationService.GetAllOrganisations());
        }

        [HttpGet]
        public IActionResult CreateOrganisation()
        {
            return View(new Organisation());
        }

        [HttpPost]
        public IActionResult CreateOrganisation(Organisation organisation)
        {
            _organisationService.CreateOrganisation(organisation);
            return RedirectToAction("Organisations");
        }

        public IActionResult DeleteOrganisation(int idDeleteOrganisation) 
        {
            _organisationService.DeleteOrganisation(idDeleteOrganisation);
            return RedirectToAction("Organisations");
        }

        public IActionResult DetailsOrganisation(int organisationId)
        {
            Organisation organisation = _organisationService.GetOrganisationById(organisationId);
            List<Vacancy> vacancies = _vacancyService.GetVacanciesByOrganisationId(organisationId);
            OrganisationVacanciesViewModel viewModel = new OrganisationVacanciesViewModel(organisation, vacancies);
            return View(viewModel);
        }

        public IActionResult EditOrganisation(int id) 
        {
            return View(_organisationService.GetOrganisationById(id));
        }
        [HttpPost]
        public IActionResult EditOrganisation(Organisation organisation)
        {
            _organisationService.EditOrganisation(organisation);
            return RedirectToAction("Organisations");
        }


    }
}
