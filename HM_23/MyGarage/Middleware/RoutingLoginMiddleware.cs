namespace MyGarageMVC.Middleware
{
    public class RoutingLoginMiddleware
    {
        readonly RequestDelegate next;
        public RoutingLoginMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        { 
                string log = context.Request.Query["login"];
                if (log == "pp")
                {
                    await context.Response.WriteAsync("Welcom User pp");
                }
                else if (log == "ss")
                {
                    await context.Response.WriteAsync("Welcom Admin ss");
                }
                else
                {
                    context.Response.StatusCode = 404;
                }
            
        }
    }
}
