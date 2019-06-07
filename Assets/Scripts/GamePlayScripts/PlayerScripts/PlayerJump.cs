using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class PlayerJump : ScriptableObject, IPlayerCommand
    {
        private float JUMP_FACTOR;
        private bool Grounded;
        private Rigidbody2D RB;

        public void ButtonDown(GameObject gameobject)
        {
            // How much force is applied to player for jump.
            JUMP_FACTOR = gameobject.GetComponent<ADSRManager>().GetJump();

            // Checks whether Player is grounded.
            Grounded = gameobject.GetComponent<ADSRManager>().GetGrounded();

            // Only jump if grounded.
            RB = gameobject.GetComponent<Rigidbody2D>();


            // Adding a force to simulate a jump.
            if (Grounded)
            {
                RB.AddForce(new Vector2(0.0f, JUMP_FACTOR), ForceMode2D.Impulse);
            }
        }
        public void ButtonHold(GameObject gameobject)
        {
            // Here to satisfy the interface.
        }
        public void ButtonUp(GameObject gameobject)
        {
            // Here to satisfy the interface.
        }
    }
}