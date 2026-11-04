using UnityEngine;

namespace GAME.Scripts.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        public void FaceTowards(Vector3 target)
        {
            float direction = target.x - transform.position.x;

            if (direction == 0f) return;

            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * -Mathf.Sign(direction);
            transform.localScale = scale;
        }
    }
}
