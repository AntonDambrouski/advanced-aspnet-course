using Microsoft.AspNetCore.Mvc.Filters;

namespace DaniilJobAggregatorAPI.Filters
{
    public class AddHeaderFilterAttribute(string headerName, string headerValue) : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context) { }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Response.Headers.Append(headerName, headerValue);
        }
    }
}
