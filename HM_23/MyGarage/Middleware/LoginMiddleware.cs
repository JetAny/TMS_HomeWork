﻿using System.ComponentModel.DataAnnotations;
using MyGarageMVC.Validation;
namespace MyGarageMVC.Middleware
{
    public class LoginMiddleware
    {
      
        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var login = context.Request.Query["login"];
            if (login != "pp" && login != "ss")
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Login is invalid");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
