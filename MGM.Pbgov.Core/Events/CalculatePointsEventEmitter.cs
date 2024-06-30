using MGM.Pbgov.Core.Decorators.DependentQuantityRange;
using MGM.Pbgov.Core.Decorators.MonthtyIncomeRange;
using MGM.Pbgov.Entities.Family;

namespace MGM.Pbgov.Core.Events
{
    public class CalculatePointsEventEmitter(IMonthlyIncomeRangeDecorator monthlyIncomeRangeDecorator,
        IDependentQuantityRangeDecorator dependentQuantityRangeDecorator)
    {
        private readonly IMonthlyIncomeRangeDecorator _monthlyIncomeRangeDecorator = monthlyIncomeRangeDecorator;
        private readonly IDependentQuantityRangeDecorator _dependentQuantityRangeDecorator = dependentQuantityRangeDecorator;

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

        public void EmptyPoints()
            => CalculatePoints = 0;

        private void Calculate(int points)
        {
            var calculatePointsEvent = new CalculatePointsEvent();

            calculatePointsEvent.ScoreCompleted += Ev_CalculatePoints;
            calculatePointsEvent.StartProcess(points);
        }

        private void Ev_CalculatePoints(object sender, int Points)
            => CalculatePoints += Points;
    }
}
