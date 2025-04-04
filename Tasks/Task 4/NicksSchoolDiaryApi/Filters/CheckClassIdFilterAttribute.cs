using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NicksSchoolDiaryApi.Middleware;
using NicksSchoolDiaryApi.Models;
using NicksSchoolDiaryApi.Services;

namespace NicksSchoolDiaryApi.Filters
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
                    if ( _studentClassService.GetClass(studentObj.StudentClassId) is null )
                    {
                        studentObj.StudentClassId = _studentClassService.GetStudentClasses().First().Id;
                        if (studentObj.StudentClassId <= 0)
                        {
                            context.Result = new BadRequestObjectResult("Class id must be greater than 0");
                            return;
                        }
                        context.ActionArguments["student"] = studentObj;
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
