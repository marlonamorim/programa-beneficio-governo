using MGM.Pbgov.Core.Converters;
using MGM.Pbgov.Core.Events;
using MGM.Pbgov.Core.ValueObjects;
using MGM.Pbgov.Repository;

namespace MGM.Pbgov.Core.Query
{
    public class FamilyListAllQuery(IPopularRegistrationRepository popularRegistrationRepository,
        CalculatePointsEventEmitter calculatePointsEventEmitter) : IFamilyListAllQuery
    {
        private readonly IPopularRegistrationRepository _popularRegistrationRepository = popularRegistrationRepository;
        private readonly CalculatePointsEventEmitter _calculatePointsEventEmitter = calculatePointsEventEmitter;

        public async Task<List<FamilyVO>?> ExecuteAsync()
        {
            var families = await _popularRegistrationRepository.ListAllFamilyAsync();

            IList<FamilyVO> filteredFamilies = [];

            foreach (var family in families)
            {
                await _calculatePointsEventEmitter.ApplyMontlhyIncomeRangeRule(family);

                await _calculatePointsEventEmitter.ApplyDependentQuantityRangeRule(family);

                filteredFamilies.Add(family.ToValueObject(_calculatePointsEventEmitter.CalculatePoints));

                _calculatePointsEventEmitter.EmptyPoints();
            }

            filteredFamilies = [.. filteredFamilies.OrderByDescending(c => c.Points)];

            return !filteredFamilies.Any() ? default :
                [.. filteredFamilies];
        }
    }
}
