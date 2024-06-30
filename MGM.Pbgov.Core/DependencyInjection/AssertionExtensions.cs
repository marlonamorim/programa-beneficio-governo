using MGM.Pbgov.Core.Assertions;
using Microsoft.Extensions.DependencyInjection;

namespace MGM.Pbgov.Core.DependencyInjection
{
    public static class AssertionExtensions
    {
        public static IServiceCollection AddAssertions(this IServiceCollection services)
        {
            services.AddSingleton<IFamilyAssertions, FamilyAssertions>();
            services.AddSingleton<IMontlhyIncomeRangeAssertions, MontlhyIncomeRangeAssertions>();
            services.AddSingleton<IDependentQuantityRangeAssertions, DependentQuantityRangeAssertions>();
            return services;
        }
    }
}
