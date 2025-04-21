using Microsoft.AspNetCore.Mvc.Filters;

namespace HotelManagerApi.Filters;

public class AddHeaderFilterAttribute(string headerName, string headerValue):Attribute, IResourceFilter
{
    public void OnResourceExecuted(ResourceExecutedContext context)
    {
      //  context.HttpContext.Response.Headers.Append(headerName, headerValue);
    }

    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        context.HttpContext.Response.Headers.Append(headerName, headerValue);
    }
}
