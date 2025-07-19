using Common.Events;

namespace Gameplay.Scoring
{
    public class ScoreService
    {
        private readonly EventBus _eventBus;
        private int _currentScore;

        public int CurrentScore => _currentScore;

        public ScoreService(EventBus eventBus)
        {
            _eventBus = eventBus;
            _currentScore = 0;
        }

        public void AddScore(int amount)
        {
            _currentScore += amount;
            _eventBus.Publish(new ScoreChangedEvent(_currentScore));
        }

        public void Reset()
        {
            _currentScore = 0;
            _eventBus.Publish(new ScoreChangedEvent(_currentScore));
        }
    }
}