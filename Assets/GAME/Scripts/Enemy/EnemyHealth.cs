using UnityEngine;

namespace GAME.Scripts.Enemy
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private float currentHealth;
        [SerializeField] private float maxHealth = 100f;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(float amount)
        {
            if (currentHealth <= 0f) return;

            currentHealth = Mathf.Max(currentHealth - amount, 0f);

            if (currentHealth <= 0f)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
