using MGM.Pbgov.Infrastructure.DataSettings;
using MGM.Pbgov.Infrastructure.Repositories;
using MGM.Pbgov.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MGM.Pbgov.Infrastructure.DependencyInjection
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PopularRegistrationStoreDatabaseSettings>(
                configuration.GetSection("PopularRegistrationStoreDatabase"));

            services.AddSingleton<IPopularRegistrationRepository, PopularRegistrationRepository>();
            services.AddSingleton<IPointRangeRepository, PointRangeRepository>();
            services.AddSingleton<IDependentRangeRepository, DependentRangeRepository>();

            return services;
        }
    }
}
