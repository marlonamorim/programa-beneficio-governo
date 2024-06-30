using MGM.Pbgov.Entities.Family;
using MGM.Pbgov.Entities.Score;

namespace MGM.Pbgov.Core.Assertions
{
    public interface IMontlhyIncomeRangeAssertions
    {
        int? FamiliarTrackWasFound(IEnumerable<PointRangeEntity> pointRangeEntities, FamilyEntity familyEntity);
    }
}
