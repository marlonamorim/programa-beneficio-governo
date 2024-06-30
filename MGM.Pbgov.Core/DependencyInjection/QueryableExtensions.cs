using MGM.Pbgov.Core.Handler;
using MGM.Pbgov.Core.Handler.Search;
using MGM.Pbgov.Core.Query;
using MGM.Pbgov.Core.ValueObjects;
using Microsoft.Extensions.DependencyInjection;

namespace MGM.Pbgov.Core.DependencyInjection
{
    public static class QueryableExtensions
    {
        public static IServiceCollection AddQueryables(this IServiceCollection services)
        {
            services.AddSingleton<IFamilyListAllQuery, FamilyListAllQuery>();
            services.AddSingleton<IFamilyGetByIdQuery, FamilyGetByIdQuery>();
            services.AddSingleton<IQueryHandler<IFamilyListAllQuery, List<FamilyVO>>, FamilyHandler>();
            services.AddSingleton<IQueryHandler<IFamilyGetByIdQuery, FamilyVO>, FamilyHandler>();

            return services;
        }
    }
}
