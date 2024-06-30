using MGM.Pbgov.Entities.DependentRange;
using MGM.Pbgov.Entities.Family;

namespace MGM.Pbgov.Core.Assertions
{
    internal class DependentQuantityRangeAssertions : IDependentQuantityRangeAssertions
    {
        private const int AgeNotDependent = 18;

        public int? FamiliarTrackWasFound(IEnumerable<DependentRangeEntity> dependentRangeEntities, FamilyEntity familyEntity)
        {
            var dependentQuantity = familyEntity.Persons.Where(c => c.Age <= AgeNotDependent).Count();

            var familiarTrackFound = dependentRangeEntities.FirstOrDefault(c => dependentQuantity > 0 && dependentQuantity >= c.From && dependentQuantity <= c.To);

            if (familiarTrackFound is null)
                return null;

            return familiarTrackFound.Points;
        }
    }
}
