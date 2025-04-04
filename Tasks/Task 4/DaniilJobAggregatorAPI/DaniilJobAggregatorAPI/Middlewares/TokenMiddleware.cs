﻿namespace DaniilJobAggregatorAPI.Middlewares
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        string pattern;

        public TokenMiddleware(RequestDelegate next, string pattern)
        {
            _next = next;
            this.pattern = pattern;
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            var token = context.Request.Query["token"];
            if (token != this.pattern)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token is invalid!");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
