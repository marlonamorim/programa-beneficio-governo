using MGM.Pbgov.Core.Assertions;
using MGM.Pbgov.Core.Converters;
using MGM.Pbgov.Core.Events;
using MGM.Pbgov.Core.ValueObjects;
using MGM.Pbgov.Repository;

namespace MGM.Pbgov.Core.Query
{
    internal class FamilyGetByIdQuery(IPopularRegistrationRepository popularRegistrationRepository,
        IFamilyAssertions familyAssertions,
        CalculatePointsEventEmitter calculatePointsEventEmitter) : IFamilyGetByIdQuery
    {
        private readonly IPopularRegistrationRepository _popularRegistrationRepository = popularRegistrationRepository;
        private readonly IFamilyAssertions _familyAssertions = familyAssertions;
        private readonly CalculatePointsEventEmitter _calculatePointsEventEmitter = calculatePointsEventEmitter;

        private string? Id;

        public void AddId(string id)
            => Id = id;

        public async Task<FamilyVO?> ExecuteAsync()
        {
            var family = await _popularRegistrationRepository.GetFamilyByIdAsync(Id!);

            _familyAssertions.FamilyNeedsToBeValid(family, Id!);

            await _calculatePointsEventEmitter.ApplyMontlhyIncomeRangeRule(family);

            await _calculatePointsEventEmitter.ApplyDependentQuantityRangeRule(family);

            return family is null ? default :
                    family.ToValueObject(_calculatePointsEventEmitter.CalculatePoints);
        }
    }
}
