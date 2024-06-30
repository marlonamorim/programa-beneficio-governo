using MGM.Pbgov.Entities.DependentRange;
using MGM.Pbgov.Entities.Family;

namespace MGM.Pbgov.Core.Assertions
{
    public interface IDependentQuantityRangeAssertions
    {
        int? FamiliarTrackWasFound(IEnumerable<DependentRangeEntity> dependentRangeEntities, FamilyEntity familyEntity);
    }
}
