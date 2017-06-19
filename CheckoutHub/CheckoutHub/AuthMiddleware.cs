using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutHub
{
    /// <summary>
    /// Authorization example, whould have chosen to use basic auth or identityServer but to integrate with the sdk
    /// provided used a copy of the secret string. In proper implementation string would not be hardcoded but read from app settings.
    /// More just an example
    /// </summary>
    public class AuthMiddleware
    {
        private const string authenticationKey = "sk_test_32b9cb39-1cd6-4f86-b750-7069a133667d";
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null && authHeader == authenticationKey)
            {
                await _next.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = 401; //Unauthorized
                return;
            }
        }
    }
}
