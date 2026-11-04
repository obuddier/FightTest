using UnityEngine;

namespace GAME.Scripts.Enemy
{
    public class EnemyHealth : MonoBehaviour, IDamageable
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
            GameEvents.RaiseEnemyHealthChanged(currentHealth, maxHealth);

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            GameEvents.RaiseEnemyDied();
            Destroy(gameObject);
        }
    }
}
