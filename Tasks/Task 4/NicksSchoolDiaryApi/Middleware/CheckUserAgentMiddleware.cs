using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace NicksSchoolDiaryApi.Middleware
{
    public class CheckUserAgentMiddleware
    {
        public readonly RequestDelegate _next;
        private readonly string _useragent;

        public CheckUserAgentMiddleware(RequestDelegate next, string useragent)
        {
            _next = next;
            _useragent = useragent;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string browser = context.Request.Headers.UserAgent.ToString();
            if (!browser.Contains(_useragent))
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"User-Agent: {browser} is not accepted.\nUse: {_useragent}");
                return;
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }

    public static class CheckUserAgentExtensions
    {
        public static IApplicationBuilder UseCheckUserAgent(this IApplicationBuilder builder, string useragent)
        {
            return builder.UseMiddleware<CheckUserAgentMiddleware>(useragent);
        }
    }

}
