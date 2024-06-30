using MGM.Pbgov.Core.Decorators.DependentQuantityRange;
using MGM.Pbgov.Core.Decorators.MonthtyIncomeRange;
using MGM.Pbgov.Entities.Family;

namespace MGM.Pbgov.Core.Events
{
    public class CalculatePointsEventEmitter(IMonthlyIncomeRangeDecorator monthlyIncomeRangeDecorator,
        IDependentQuantityRangeDecorator dependentQuantityRangeDecorator,
        CalculatePointsEvent calculatePointsEvent)
    {
        private readonly IMonthlyIncomeRangeDecorator _monthlyIncomeRangeDecorator = monthlyIncomeRangeDecorator;
        private readonly IDependentQuantityRangeDecorator _dependentQuantityRangeDecorator = dependentQuantityRangeDecorator;
        private readonly CalculatePointsEvent _calculatePointsEvent = calculatePointsEvent;

        internal int CalculatePoints { get; private set; }

        public async Task ApplyMontlhyIncomeRangeRule(FamilyEntity family)
        {
            var pointsByMonthlyIncomeRange = await _monthlyIncomeRangeDecorator.AppliedRuleAsync(family);
            Calculate(pointsByMonthlyIncomeRange);
        }

        public async Task ApplyDependentQuantityRangeRule(FamilyEntity family)
        {
            var pointsByDependentQuantityRange = await _dependentQuantityRangeDecorator.AppliedRuleAsync(family);
            Calculate(pointsByDependentQuantityRange);
        }

        private void Calculate(int points)
        {
            _calculatePointsEvent.ScoreCompleted += Ev_CalculatePoints;
            _calculatePointsEvent.StartProcess(points);
        }

        private void Ev_CalculatePoints(object sender, int Points)
            => CalculatePoints += Points;
    }
}
