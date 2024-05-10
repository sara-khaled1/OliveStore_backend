using sda_onsite_2_csharp_backend_teamwork.src.Exceptions;

namespace sda_onsite_2_csharp_backend_teamwork.src.Middlewares
{
    public class CustomErrorMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (CustomErrorException e)
            {
                context.Response.StatusCode = e.StatusCode;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(e.InnerException.Message);
            }
            catch (NullReferenceException e)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "text/plain";
                // await context.Response.WriteAsync(e.Message);
                await context.Response.WriteAsync(e.InnerException.Message);

            }
            catch (ArgumentException e)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "text/plain";
                // await context.Response.WriteAsync(e.Message);
                await context.Response.WriteAsync(e.InnerException.Message);

            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "text/plain";
                // await context.Response.WriteAsync(e.Message);
                await context.Response.WriteAsync(e.InnerException.Message);
                // Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}