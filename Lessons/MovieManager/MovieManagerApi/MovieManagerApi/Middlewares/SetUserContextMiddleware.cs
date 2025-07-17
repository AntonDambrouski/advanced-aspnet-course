using MovieManager.Core.Contexts;
using MovieManagerApi.Middlewares;
using System.Security.Claims;

namespace MovieManagerApi.Middlewares
{
    public class SetUserContextMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context, UserContext userContext)
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (int.TryParse(userId, out var id))
                {
                    userContext.UserId = id;
                }
            }

            await next(context);
        }
    }
}

public static class SetUserContextMiddlewareExtensions
{
    public static IApplicationBuilder UseSetUserContext(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SetUserContextMiddleware>();
    }
}

