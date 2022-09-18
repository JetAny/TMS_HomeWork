namespace MyGarageMVC
{
    public class PasswordMiddleware
    {
        
        private readonly RequestDelegate _next;

        public PasswordMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var password = context.Request.Query["password"];
            if (password != "1")
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Password is invalid");
                
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
