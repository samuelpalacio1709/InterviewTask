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
        public static string lastKeywordPressed;
        private void OnEnable()
        {
            playerRigidbody.gravityScale=0;
            PlayerInputHandler.OnInput += ChangePlayerDirection;
        }
        private void OnDisable()
        {
            PlayerInputHandler.OnInput -= ChangePlayerDirection;
        }
        private void Update()
        {
            Vector3 movement = inputDirection * movementSpeed;
            playerRigidbody.velocity = movement;
        }
       
        private void ChangePlayerDirection(Vector2 direction)
        {
            inputDirection = direction;
        }
      
    }
   
}


      