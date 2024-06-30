namespace MGM.Pbgov.Core.Events
{
    public class CalculatePointsEvent
    {
        public event EventHandler<int> ScoreCompleted;

        public void StartProcess(int points)
        {
            try
            {
                OnProcessCompleted(points);
            }
            catch
            {
                OnProcessCompleted(0);
            }
        }

        protected virtual void OnProcessCompleted(int Points)
        {
            ScoreCompleted?.Invoke(this, Points);
        }
    }
}
