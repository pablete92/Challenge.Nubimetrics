using Challenge.Nubimetrics.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Challenge.Nubimetrics.Infrastructure.Extensions
{
    public static class ApplicationBuilderMiddlewareExtensions
    {
        /// <summary>
        /// Error middleware extension
        /// </summary>
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
            => builder.UseMiddleware<ErrorHandlingMiddleware>();
    }
}
