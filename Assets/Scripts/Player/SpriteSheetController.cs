using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    public class SpriteSheetController : MonoBehaviour
    {

        public Animator animator;
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
            animator.SetFloat("Axis_X", direction.x);
            animator.SetFloat("Axis_Y", direction.y);
        }
    }
}


