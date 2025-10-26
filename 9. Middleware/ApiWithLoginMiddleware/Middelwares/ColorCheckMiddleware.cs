using ApiWithLoginMiddleware.Models;
using Microsoft.AspNetCore.Identity;

namespace ApiWithLoginMiddleware.Middlewares;

public class ColorCheckMiddleware
{
    private readonly RequestDelegate _next;

    public ColorCheckMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, UserManager<User> userManager)
    {
        if (context.Request.Path.StartsWithSegments("/persons"))
        {
            // if (!context.User.Identity?.IsAuthenticated ?? true)
            // {
            //     context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //     await context.Response.WriteAsJsonAsync(new
            //     {
            //         message = "User must be logged in"
            //     });
            //     return;
            // }

            User? user = await userManager.GetUserAsync(context.User);

            if (user == null || string.IsNullOrEmpty(user.Color))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsJsonAsync(new
                {
                    message = "User must have the Color property set"
                });
                return;
            }
        }

        await _next(context);
    }

}