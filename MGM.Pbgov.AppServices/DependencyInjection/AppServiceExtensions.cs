using MGM.Pbgov.AppServices.Services.Search;
using Microsoft.Extensions.DependencyInjection;

namespace MGM.Pbgov.AppServices.DependencyInjection
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddSingleton<IFamilyQueryAppService, FamilyQueryAppService>();
            return services;
        }
    }
}
