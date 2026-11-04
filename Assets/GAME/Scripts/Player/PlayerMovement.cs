using UnityEngine;

namespace GAME.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private float fallGravityScale = 3f;

        [Header("Ground Check")]
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundCheckRadius = 0.1f;
        [SerializeField] private LayerMask groundLayer;

        private Rigidbody2D _rigidbody;
        private float _moveInput;
        private float _defaultGravityScale;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _defaultGravityScale = _rigidbody.gravityScale;
        }

        private void FixedUpdate()
        {
            _rigidbody.linearVelocityX = _moveInput * moveSpeed;
            _rigidbody.gravityScale = _rigidbody.linearVelocityY < 0f ? fallGravityScale : _defaultGravityScale;
        }

        public void SetMoveInput(float direction)
        {
            _moveInput = direction;

            if (direction != 0f)
            {
                Face(direction);
            }
        }

        public void Jump()
        {
            if (!IsGrounded()) return;

            _rigidbody.linearVelocityY = jumpForce;
        }

        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer) != null;
        }

        private void Face(float direction)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * Mathf.Sign(direction);
            transform.localScale = scale;
        }
    }
}
