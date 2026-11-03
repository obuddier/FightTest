using UnityEngine;

namespace GAME.Scripts.Enemy
{
    [RequireComponent(typeof(EnemyHealth), typeof(EnemyMovement), typeof(EnemyAttack))]
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float attackInterval = 1f;
        [SerializeField] private float flipInterval = 2f;

        private EnemyMovement _movement;
        private EnemyAttack _attack;

        private float _attackTimer;
        private float _flipTimer;

        private void Awake()
        {
            _movement = GetComponent<EnemyMovement>();
            _attack = GetComponent<EnemyAttack>();
        }

        private void Update()
        {
            AttackTimer();
            FlipTimer();
        }

        private void AttackTimer()
        {
            if (_attackTimer < attackInterval)
            {
                _attackTimer += Time.deltaTime;
            }
            else
            {
                _attack.Attack();
                _attackTimer = 0f;
            }
        }

        private void FlipTimer()
        {
            if (_flipTimer < flipInterval)
            {
                _flipTimer += Time.deltaTime;
            }
            else
            {
                _movement.Flip();
                _flipTimer = 0f;
            }
        }
    }
}
