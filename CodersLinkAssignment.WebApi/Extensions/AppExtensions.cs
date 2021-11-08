using CodersLinkAssignment.WebApi.Middleware;
using Microsoft.AspNetCore.Builder;

namespace CodersLinkAssignment.WebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandleMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandleMiddleware>();
        }
    }
}
