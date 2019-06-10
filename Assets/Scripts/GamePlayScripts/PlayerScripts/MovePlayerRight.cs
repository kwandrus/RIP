using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GamePlay.Player.Command
{
    public class MovePlayerRight : ScriptableObject, IPlayerCommand
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
                ADSR.SetInputDirection(Time.deltaTime);

                // Sets direction to know that player is moving.
                ADSR.SetDirection(ADSRManager.Direction.Horizontal);
            }

            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        public void ButtonHold(GameObject gameObject)
        {
            ADSR = gameObject.GetComponent<ADSRManager>();
            var Movement = ADSR.GetDirection();
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

            // if statement fixes bug that caused player to be in None state when switching directions mid-jump
            // Changing to the None state prevented the player from moving in the opposite direction on the same button hold
            if (ADSRManager.Direction.None == Movement)
            {
                ADSR.ResetTimers();
                ADSR.SetPhase(ADSRManager.Phase.Attack);
                ADSR.SetInputDirection(Time.deltaTime);

                // Sets direction to know that player is moving.
                ADSR.SetDirection(ADSRManager.Direction.Horizontal);
            }
            ADSR = gameObject.GetComponent<ADSRManager>();

            if (ADSR.getInputDirection() <= -0.7f)
            {
                ADSR.SetInputDirection(0.3f);
            }
            ADSR.SetInputDirection(Time.deltaTime);
        }
        public void ButtonUp(GameObject gameObject)
        {
            ADSR = gameObject.GetComponent<ADSRManager>();
            bool Grounded = ADSR.GetGrounded();

            ADSR.SetInputDirection(Time.deltaTime);
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
