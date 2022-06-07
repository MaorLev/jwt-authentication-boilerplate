using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwt_authentication_boilerplate.Data
{
    public class AllowedCorsMiddleware
    {
        private readonly RequestDelegate _next;
        public AllowedCorsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //Fill according your roles
            context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "*" });


            context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "*" });


            await _next(context);

        }
    }
}
