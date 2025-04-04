using DaniilJobAggregator.Domain.Entity;
using DaniilJobAggregator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DaniilJobAggregatorAPI.Filters
{
    public class OrganisationIdAttribute : Attribute, IAsyncActionFilter
    {
        private readonly IOrganisationService _organisationService;

        public OrganisationIdAttribute(IOrganisationService organisationService)
        {
            _organisationService = organisationService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ActionArguments.ContainsKey("vacancyModel"))
            {
                var contextVacancy = context.ActionArguments["vacancyModel"];
                if (contextVacancy is Vacancy vacancy)
                {
                    if (_organisationService.GetOrganisationById((int)vacancy.IdOrganisation) is null)
                    {
                        context.Result = new BadRequestObjectResult("There is no such IdOrganisation");
                        return;
                    }
                }
            }
            else
            {
                context.Result = new BadRequestObjectResult("Vacancy is required");
                return;
            }
            await next();
        }
    }
}
