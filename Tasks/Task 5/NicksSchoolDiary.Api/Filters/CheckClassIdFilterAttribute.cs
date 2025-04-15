using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NicksSchoolDiary.Api.Middleware;
using NicksSchoolDiary.Domain.Models;
using NicksSchoolDiary.Domain.Services;
using NicksSchoolDiary.Domain.Interfaces;

namespace NicksSchoolDiary.Api.Filters
{
    public class CheckClassIdFilterAttribute : Attribute, IAsyncActionFilter
    {
        private readonly IStudentClassService _studentClassService;
        public CheckClassIdFilterAttribute(IStudentClassService studentClassService)
        {
            _studentClassService = studentClassService;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            if (context.ActionArguments.ContainsKey("student"))
            {
                var student = context.ActionArguments["student"];
                if (student is Student studentObj)
                {
                    if (await _studentClassService.GetClassAsync(studentObj.StudentClassId) is null)
                    {
                        context.Result = new BadRequestObjectResult("Class id must be exist");
                        return;
                    }
                }
            }
            else
            {
                context.Result = new BadRequestObjectResult("Student is required");
                return;
            }
            await next();
        }
    }
}