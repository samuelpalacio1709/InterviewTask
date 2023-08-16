using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class SpriteSheetController : MonoBehaviour
    {

        [SerializeField] Animator animator;
        [SerializeField] Sprite[] stillSprites;
        [SerializeField] SpriteRenderer characterSpriteRenderer;


        private void OnEnable()
        {
            PlayerInputHandler.OnInput += ChangeSpriteSheetAnimation;
        }
        private void OnDisable()
        {
            PlayerInputHandler.OnInput -= ChangeSpriteSheetAnimation;
        }
        private void ChangeSpriteSheetAnimation(Vector2 direction)
        {

            if (direction == Vector2.zero)
            {
               animator.SetBool("IsWalking", false);
               return;
            }
            animator.SetBool("IsWalking", true);
            animator.SetFloat("Axis_X", direction.x);
            animator.SetFloat("Axis_Y", direction.y);
            
        }

 


    }
}


