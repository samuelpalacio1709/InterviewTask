using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private CustomPlayerActions input;
        public static Action<Vector2> OnInput;
        private void Awake()
        {
            input= new CustomPlayerActions();
        }
        private void OnEnable()
        {
            input.Enable();
            input.Player.Movement.performed += HandleInputPerformed;
            input.Player.Movement.canceled += HandleInputCanceled;

        }

        private void OnDisable()
        {
            input.Disable();
            input.Player.Movement.performed -= HandleInputPerformed;
            input.Player.Movement.canceled -= HandleInputCanceled;
        }
    
        private void HandleInputPerformed(InputAction.CallbackContext context)
        {
            OnInput?.Invoke(context.ReadValue<Vector2>());
        }
        private void HandleInputCanceled(InputAction.CallbackContext context)
        {
            OnInput?.Invoke(Vector2.zero);
        }
    }

}

