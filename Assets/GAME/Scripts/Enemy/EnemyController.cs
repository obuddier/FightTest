using UnityEngine;

namespace GAME.Scripts.Enemy
{
    [RequireComponent(typeof(EnemyHealth), typeof(EnemyMovement), typeof(EnemyAttack))]
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float attackRange = 1.5f;
        [SerializeField] private Transform player;

        private EnemyMovement _movement;
        private EnemyAttack _attack;

        private void Awake()
        {
            _movement = GetComponent<EnemyMovement>();
            _attack = GetComponent<EnemyAttack>();
        }

        private void Update()
        {
            if (player == null) return;

            _movement.FaceTowards(player.position);

            if (IsPlayerInRange())
            {
                _attack.Attack();
            }
        }

        private bool IsPlayerInRange()
        {
            return Vector2.Distance(transform.position, player.position) <= attackRange;
        }
    }
}
