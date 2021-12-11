using GamingHub2.WebApp2.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.WebApp2.Middleware
{
    public class ApiErrorMiddleWare
    {
        private readonly RequestDelegate next;

        public ApiErrorMiddleWare(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception is ApiAuthenticationException)
            {
                context.Response.Redirect("/Login");
            }

            if (exception is ApiAuthorizationException)
            {
                context.Response.Redirect("/Login/AccessDenied");
            }
        }

    }
}
