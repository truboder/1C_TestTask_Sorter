namespace Gameplay.Health
{
    public struct HealthChangedEvent
    {
        public readonly int CurrentHealth;

        public HealthChangedEvent(int currentHealth)
        {
            CurrentHealth = currentHealth;
        }
    }
}