using UnityEngine;

namespace GAME.Scripts.Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int currentHealth;
        [SerializeField] private int maxHealth = 100;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            if (currentHealth <= 0) return;

            currentHealth = Mathf.Max(currentHealth - amount, 0);
            GameEvents.RaisePlayerHealthChanged(currentHealth, maxHealth);

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            GameEvents.RaisePlayerDied();
            Destroy(gameObject);
        }
    }
}
