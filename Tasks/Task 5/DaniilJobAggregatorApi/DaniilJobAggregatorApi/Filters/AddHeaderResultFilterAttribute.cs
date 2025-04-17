using Microsoft.AspNetCore.Mvc.Filters;


namespace DaniilJobAggregatorApi.Filters
{
    public class AddHeaderResultFilterAttribute : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            foreach (var item in context.HttpContext.Response.Headers) 
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("Result-Filter", "Result header");
        }
    }
}
