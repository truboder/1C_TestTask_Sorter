using Common.Events;
using Gameplay.Health;
using TMPro;
using UnityEngine;
using Zenject;

namespace Gameplay.UI
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthText;
        
        private EventBus _eventBus;

        [Inject]
        public void Construct(EventBus eventBus)
        {
            _eventBus = eventBus;
            _eventBus.Subscribe<HealthChangedEvent>(UpdateHealthDisplay);
        }

        private void UpdateHealthDisplay(HealthChangedEvent evt)
        {
            _healthText.text = $"Health: {evt.CurrentHealth}";
        }

        private void OnDestroy()
        {
            _eventBus.Unsubscribe<HealthChangedEvent>(UpdateHealthDisplay);
        }
    }
}