using MGM.Pbgov.Infrastructure.Api.ErrorHandling;
using MGM.Pbgov.Infrastructure.Api.ErrorHandling.HttpExceptions;
using MGM.Pbgov.Infrastructure.Api.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace MGM.Pbgov.Infrastructure.DependencyInjection
{
    public static class ErrorHandlingServiceExtensions
    {
        public static IServiceCollection AddErrorHandlerServices(this IServiceCollection services)
        {
            services.AddSingleton<IErrorFactory, ErrorFactory>();
            services.AddSingleton<IActionResultErrorBuilder, ActionResultErrorBuilder>();
            services.AddSingleton<IDefaultHttpClientErrorResponseHandler, DefaultHttpClientErrorResponseHandler>();
            services.AddSingleton<ExceptionFilter>();

            return services;
        }
    }
}
