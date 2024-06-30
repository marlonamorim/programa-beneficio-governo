using MGM.Pbgov.Core.Decorators.DependentQuantityRange;
using MGM.Pbgov.Core.Decorators.MonthtyIncomeRange;
using MGM.Pbgov.Core.Events;
using Microsoft.Extensions.DependencyInjection;

namespace MGM.Pbgov.Core.DependencyInjection
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<CalculatePointsEventEmitter>();
            services.AddSingleton<IMonthlyIncomeRangeDecorator, MonthlyIncomeRangeDecorator>();
            services.AddSingleton<IDependentQuantityRangeDecorator, DependentQuantityRangeDecorator>();
            return services;
        }
    }
}
