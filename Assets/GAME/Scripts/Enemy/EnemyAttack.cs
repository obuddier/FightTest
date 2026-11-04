using System.Collections;
using UnityEngine;

namespace GAME.Scripts.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [Header("Attack Settings")]
        [SerializeField] private float damage = 10f;
        [SerializeField] private float attackRadius = 0.25f;
        [SerializeField] private float attackCooldown = 1f;
        [SerializeField] private float indicatorDuration = 0.2f;
        [SerializeField] private LayerMask targetLayer;

        [Header("Object References")]
        [SerializeField] private GameObject attackIndicator;

        // Our own hurtbox can fill one slot, so a single result could hide the opponent.
        private readonly Collider2D[] _hits = new Collider2D[2];
        private ContactFilter2D _targetFilter;
        private Coroutine _indicatorRoutine;
        private float _nextAttackTime;

        private void Awake()
        {
            _targetFilter.SetLayerMask(targetLayer);
            _targetFilter.useTriggers = true;

            attackIndicator.SetActive(false);
        }

        public void Attack()
        {
            if (Time.time < _nextAttackTime) return;

            _nextAttackTime = Time.time + attackCooldown;

            DamageTarget();

            if (_indicatorRoutine != null)
            {
                StopCoroutine(_indicatorRoutine);
            }

            _indicatorRoutine = StartCoroutine(ShowIndicator());
        }

        private void DamageTarget()
        {
            int hitCount = Physics2D.OverlapCircle(attackIndicator.transform.position, attackRadius, _targetFilter, _hits);

            for (int i = 0; i < hitCount; i++)
            {
                if (_hits[i].transform.IsChildOf(transform)) continue;

                IDamageable targetPlayer = _hits[i].GetComponentInParent<IDamageable>();

                if (targetPlayer != null)
                {
                    targetPlayer.TakeDamage(damage);
                    return;
                }
            }
        }

        private IEnumerator ShowIndicator()
        {
            attackIndicator.SetActive(true);
            yield return new WaitForSeconds(indicatorDuration);
            attackIndicator.SetActive(false);
        }
    }
}
