using UnityEngine;
using UnityEngine.InputSystem;

namespace GAME.Scripts.Player
{
    [RequireComponent(typeof(PlayerHealth), typeof(PlayerMovement), typeof(PlayerAttack))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Input Actions")]
        [SerializeField] private InputActionReference moveAction;
        [SerializeField] private InputActionReference jumpAction;
        [SerializeField] private InputActionReference attackAction;

        private PlayerMovement _movement;
        private PlayerAttack _attack;

        private void Awake()
        {
            _movement = GetComponent<PlayerMovement>();
            _attack = GetComponent<PlayerAttack>();
        }

        private void OnEnable()
        {
            moveAction.action.Enable();
            jumpAction.action.Enable();
            attackAction.action.Enable();
        }

        private void OnDisable()
        {
            moveAction.action.Disable();
            jumpAction.action.Disable();
            attackAction.action.Disable();
        }

        private void Update()
        {
            _movement.SetMoveInput(moveAction.action.ReadValue<Vector2>().x);

            if (jumpAction.action.WasPressedThisFrame())
            {
                _movement.Jump();
            }

            if (attackAction.action.WasPressedThisFrame())
            {
                _attack.Attack();
            }
        }
    }
}
