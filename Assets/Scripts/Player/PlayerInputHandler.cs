using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private CustomPlayerActions input;
        public static Action<Vector2> OnInputMovement;
        public static Action OnInputInteraction;
        private void Awake()
        {
            input= new CustomPlayerActions();
        }
        private void OnEnable()
        {
            input.Enable();
            input.Player.Movement.performed += HandleInputMovementPerformed;
            input.Player.Movement.canceled += HandleInputMovementCanceled;
            input.Player.Interact.performed += HandleInputInteractionPerformed;
        }
        private void OnDisable()
        {
            input.Disable();
            input.Player.Movement.performed -= HandleInputMovementPerformed;
            input.Player.Movement.canceled -= HandleInputMovementCanceled;
            input.Player.Interact.performed -= HandleInputInteractionPerformed;
        }
    
        private void HandleInputMovementPerformed(InputAction.CallbackContext context)
        {
            OnInputMovement?.Invoke(context.ReadValue<Vector2>());
        }
        private void HandleInputMovementCanceled(InputAction.CallbackContext context)
        {
            OnInputMovement?.Invoke(Vector2.zero);
        }

        private void HandleInputInteractionPerformed(InputAction.CallbackContext context)
        {
            OnInputInteraction?.Invoke();
        }

    }

}

