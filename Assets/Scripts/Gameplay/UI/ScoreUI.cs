using Common.Events;
using Gameplay.Scoring;
using TMPro;
using UnityEngine;
using Zenject;

namespace Gameplay.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        
        private EventBus _eventBus;
        
        [Inject]
        public void Construct(EventBus eventBus)
        {
            _eventBus = eventBus;
            _eventBus.Subscribe<ScoreChangedEvent>(UpdateScoreDisplay);
        }
        
        private void UpdateScoreDisplay(ScoreChangedEvent evt)
        {
            _scoreText.text = $"Score: {evt.CurrentScore}";
        }

        private void OnDestroy()
        {
            _eventBus.Unsubscribe<ScoreChangedEvent>(UpdateScoreDisplay);
        }
    }
}