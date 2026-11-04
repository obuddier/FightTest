using System;

namespace GAME.Scripts
{
    public static class GameEvents
    {
        public static event Action<int, int> PlayerHealthChanged;
        public static event Action<int, int> EnemyHealthChanged;
        public static event Action PlayerDied;
        public static event Action EnemyDied;

        public static void RaisePlayerHealthChanged(int currentHealth, int maxHealth)
        {
            PlayerHealthChanged?.Invoke(currentHealth, maxHealth);
        }

        public static void RaiseEnemyHealthChanged(int currentHealth, int maxHealth)
        {
            EnemyHealthChanged?.Invoke(currentHealth, maxHealth);
        }

        public static void RaisePlayerDied()
        {
            PlayerDied?.Invoke();
        }

        public static void RaiseEnemyDied()
        {
            EnemyDied?.Invoke();
        }
    }
}
