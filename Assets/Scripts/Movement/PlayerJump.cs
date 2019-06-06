using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class PlayerJump : ScriptableObject, IPlayerCommand
    {
        private float JUMP_FACTOR;
        public void ButtonDown(GameObject gameobject)
        {
            // How much force is applied to player for jump.
            JUMP_FACTOR = gameobject.GetComponent<ADSRManager>().GetJump();

            // Adding a force to simulate a jump.
            gameobject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, JUMP_FACTOR),ForceMode2D.Impulse);
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