using UnityEngine;
using UnityEngine.UI;

namespace GAME.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        private const string PlayerWinsMessage = "You Win";
        private const string EnemyWinsMessage = "Enemy Wins";

        [Header("Health Bars")]
        [SerializeField] private Image playerHealthFill;
        [SerializeField] private Image enemyHealthFill;

        [Header("Result")]
        [SerializeField] private GameObject resultPanel;
        [SerializeField] private Text resultText;

        private void Awake()
        {
            resultPanel.SetActive(false);
        }

        private void OnEnable()
        {
            GameEvents.PlayerHealthChanged += OnPlayerHealthChanged;
            GameEvents.EnemyHealthChanged += OnEnemyHealthChanged;
            GameEvents.PlayerDied += OnPlayerDied;
            GameEvents.EnemyDied += OnEnemyDied;
        }

        private void OnDisable()
        {
            GameEvents.PlayerHealthChanged -= OnPlayerHealthChanged;
            GameEvents.EnemyHealthChanged -= OnEnemyHealthChanged;
            GameEvents.PlayerDied -= OnPlayerDied;
            GameEvents.EnemyDied -= OnEnemyDied;
        }

        private void OnPlayerHealthChanged(int currentHealth, int maxHealth)
        {
            playerHealthFill.fillAmount = (float)currentHealth / maxHealth;
        }

        private void OnEnemyHealthChanged(int currentHealth, int maxHealth)
        {
            enemyHealthFill.fillAmount = (float)currentHealth / maxHealth;
        }

        private void OnPlayerDied()
        {
            ShowResult(EnemyWinsMessage);
        }

        private void OnEnemyDied()
        {
            ShowResult(PlayerWinsMessage);
        }

        private void ShowResult(string message)
        {
            if (resultPanel.activeSelf) return;

            resultText.text = message;
            resultPanel.SetActive(true);
        }
    }
}
