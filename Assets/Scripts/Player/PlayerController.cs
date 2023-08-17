using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public Rigidbody2D playerRigidbody;
        public float movementSpeed = 5f;
        private Vector2 inputDirection;
        public GameManager gameManager => GameManager.Instance;

        private void OnEnable()
        {
            playerRigidbody.gravityScale=0;
            PlayerInputHandler.OnInputMovement += ChangePlayerDirection;
        }
        private void OnDisable()
        {
            PlayerInputHandler.OnInputMovement -= ChangePlayerDirection;
        }
        private void Update()
        {
            if (gameManager.gameState != GameManager.GameState.Free) 
            {
                playerRigidbody.velocity = Vector2.zero;
                return;
            }
            Vector3 movement = inputDirection * movementSpeed;
            playerRigidbody.velocity = movement;
        }
       
        private void ChangePlayerDirection(Vector2 direction)
        {
            inputDirection = direction;
        }
      
    }
   
}


      