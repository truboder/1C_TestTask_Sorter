using Common.Events;
using Gameplay.StaticData;
using UnityEngine;

namespace Gameplay.Health
{
    public class HealthService
    {
        private readonly EventBus _eventBus;
        private readonly int _maxHealth;
        private int _currentHealth;

        public int CurrentHealth => _currentHealth;
        public bool IsAlive => _currentHealth > 0;
        
        public HealthService(GameSettings settings, EventBus eventBus)
        {
            _eventBus = eventBus;
            _maxHealth = settings.PlayerHealth;
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(int amount)
        {
            if (!IsAlive) return;

            _currentHealth = Mathf.Max(0, _currentHealth - amount);
            _eventBus.Publish(new HealthChangedEvent(_currentHealth));

            if (_currentHealth <= 0)
                _eventBus.Publish(new PlayerDefeatedEvent());
        }

        public void Reset()
        {
            _currentHealth = _maxHealth;
            _eventBus.Publish(new HealthChangedEvent(_currentHealth));
        }
    }
}