using UnityEngine;

namespace GAME.Scripts.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        public void Flip()
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1f;
            transform.localScale = scale;
        }
    }
}
