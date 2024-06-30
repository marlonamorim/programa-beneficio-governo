using MGM.Pbgov.Entities.Family;

namespace MGM.Pbgov.Core.Decorators
{
    internal abstract class PopularHome : IPopularHome
    {
        private const decimal MonthlyIncomeLimit = 1500m;

        public bool FamilyIsAuthorized(FamilyEntity familyEntity)
            => familyEntity.MonthlyIncome <= MonthlyIncomeLimit;

        public async Task<int> AppliedRuleAsync(FamilyEntity familyEntity)
        {
            if (!FamilyIsAuthorized(familyEntity))
                return default;

            var points = await SeekPointsByAppliedRuleAsync(familyEntity);

            return points;
        }

        public abstract Task<int> SeekPointsByAppliedRuleAsync(FamilyEntity familyEntity);
    }
}
