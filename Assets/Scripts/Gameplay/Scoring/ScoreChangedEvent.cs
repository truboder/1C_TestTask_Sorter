namespace Gameplay.Scoring
{
    public struct ScoreChangedEvent
    {
        public readonly int CurrentScore;

        public ScoreChangedEvent(int currentScore)
        {
            CurrentScore = currentScore;
        }
    }
}