using MGM.Pbgov.Entities.Family;
using MGM.Pbgov.Entities.Score;

namespace MGM.Pbgov.Core.Assertions
{
    internal class MontlhyIncomeRangeAssertions : IMontlhyIncomeRangeAssertions
    {
        public int? FamiliarTrackWasFound(IEnumerable<PointRangeEntity> pointRangeEntities, FamilyEntity familyEntity)
        {
            var familiarTrackFound = pointRangeEntities.FirstOrDefault(c => familyEntity.MonthlyIncome >= c.From && familyEntity.MonthlyIncome <= c.To);
        
            if(familiarTrackFound is null)
                return null;

            return familiarTrackFound.Points;
        }
    }
}
