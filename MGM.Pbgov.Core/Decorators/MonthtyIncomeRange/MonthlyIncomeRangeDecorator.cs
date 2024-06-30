using MGM.Pbgov.Core.Assertions;
using MGM.Pbgov.Core.Events;
using MGM.Pbgov.Entities.Family;
using MGM.Pbgov.Repository;

namespace MGM.Pbgov.Core.Decorators.MonthtyIncomeRange
{
    internal class MonthlyIncomeRangeDecorator(IMontlhyIncomeRangeAssertions montlhyIncomeRangeAssertions,
        IPointRangeRepository pointRangeRepository) : PopularHome, IMonthlyIncomeRangeDecorator
    {
        private readonly IMontlhyIncomeRangeAssertions _montlhyIncomeRangeAssertions = montlhyIncomeRangeAssertions;
        private readonly IPointRangeRepository _pointRangeRepository = pointRangeRepository;

        public override async Task<int> SeekPointsByAppliedRuleAsync(FamilyEntity familyEntity)
        {
            var range = await _pointRangeRepository.ListAllAsync();

            var points = _montlhyIncomeRangeAssertions.FamiliarTrackWasFound(range, familyEntity);

            if (!points.HasValue)
                return default;

            return points.Value;
        }
    }
}