
public class TimeMiddleware
{
    // se crea un objeto de tipo RequestDelegate
    private readonly RequestDelegate _next;

    // se crea un constructor que recibe un objeto de tipo RequestDelegate

    public TimeMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    // se crea un metodo que recibe un objeto de tipo HttpContext

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Query.Any(x => x.Key == "time"))
        {
            await context.Response.WriteAsync($"Time: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
        }
        else
        {
            await _next(context);
        }
    }
}

public static class timeMiddlewareExtension
{
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TimeMiddleware>();
    }
}