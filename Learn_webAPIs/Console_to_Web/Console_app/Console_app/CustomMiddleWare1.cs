using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Console_app
{
    public class CustomMiddleWare1 : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("\n New file msg 1 ");
            await next(context);
            await context.Response.WriteAsync("\n New file msg 2");
        }
    }
}
