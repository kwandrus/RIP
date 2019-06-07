using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class MovePlayerLeft : ScriptableObject, IPlayerCommand
    {
        private ADSRManager ADSR;
        public void ButtonDown(GameObject gameObject)
        {
            ADSR = gameObject.GetComponent<ADSRManager>();
            var Movement = ADSR.GetDirection();

            if (ADSRManager.Direction.None == Movement)
            {
                ADSR.ResetTimers();
                ADSR.SetPhase(ADSRManager.Phase.Attack);
                ADSR.SetInputDirection(-Time.deltaTime);

                // Sets direction to know that player is moving.
                ADSR.SetDirection(ADSRManager.Direction.Horizontal);
            }

            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        public void ButtonHold(GameObject gameObject)
        {
            ADSR = gameObject.GetComponent<ADSRManager>();
            var Movement = ADSR.GetDirection();

            // if statement fixes bug that caused player to be in None state when switching directions mid-jump
            // Changing to the None state prevented the player from moving in the opposite direction on the same button hold
            if (ADSRManager.Direction.None == Movement && ADSR.getInputDirection() > -0.8f)
            {
                ADSR.ResetTimers();
                ADSR.SetPhase(ADSRManager.Phase.Attack);
                ADSR.SetInputDirection(-Time.deltaTime);

                // Sets direction to know that player is moving.
                ADSR.SetDirection(ADSRManager.Direction.Horizontal);
            }
            if (ADSR.getInputDirection() >= 0.85f)
            {
                ADSR.SetInputDirection(-0.15f);
            }
            ADSR.SetInputDirection(-Time.deltaTime);
        }
        public void ButtonUp(GameObject gameObject)
        {
            bool Grounded = ADSR.GetGrounded();
            ADSR = gameObject.GetComponent<ADSRManager>();

            ADSR.SetInputDirection(-Time.deltaTime);
            if (!Grounded)
            {
                // The player is mid-air so the envelope remains at Sustain.
                // Changing it release here could result in the player
                // completing the curve and dropping straight down because there
                // would be no more change in the x direction.
                ADSR.SetPhase(ADSRManager.Phase.Sustain);
            }
            else
            {
                // If it is grounded, then releasing the button means the plaer
                // is coming to a stop.
                ADSR.SetPhase(ADSRManager.Phase.Release);
                ADSR.SetDirection(ADSRManager.Direction.None);
            }
        }

    }

}
