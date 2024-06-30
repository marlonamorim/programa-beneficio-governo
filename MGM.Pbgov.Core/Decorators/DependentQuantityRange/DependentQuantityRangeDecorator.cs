using MGM.Pbgov.Core.Assertions;
using MGM.Pbgov.Entities.Family;
using MGM.Pbgov.Repository;

namespace MGM.Pbgov.Core.Decorators.DependentQuantityRange
{
    internal class DependentQuantityRangeDecorator(IDependentQuantityRangeAssertions dependentQuantityRangeAssertions,
        IDependentRangeRepository dependentRangeRepository) : PopularHome, IDependentQuantityRangeDecorator
    {
        private readonly IDependentQuantityRangeAssertions _dependentQuantityRangeAssertions = dependentQuantityRangeAssertions;
        private readonly IDependentRangeRepository _dependentRangeRepository = dependentRangeRepository;

        public override async Task<int> SeekPointsByAppliedRuleAsync(FamilyEntity familyEntity)
        {
            var range = await _dependentRangeRepository.ListAllAsync();

            var points = _dependentQuantityRangeAssertions.FamiliarTrackWasFound(range, familyEntity);

            if (!points.HasValue)
                return default;

            return points.Value;
        }
    }
}
